using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace CheHtmlToPdfConverter
{
    public class PdfConvertException : Exception
    {
        public PdfConvertException(string msg) : base(msg) { }
    }

    public class PdfConvertTimeoutException : PdfConvertException
    {
        public PdfConvertTimeoutException() : base("Процесс конвертирования HTML в PDF не может быть окончен за заданное время.") { }
    }

	public class PdfOutput
	{
		public string OutputFilePath { get; set; }
		public Stream OutputStream { get; set; }
		public Action<PdfDocument, byte[]> OutputCallback { get; set; }
	}

	public class PdfDocument
	{
		public string Url { get; set; }
		public string Html { get; set; }
		public string HeaderUrl { get; set; }
		public string FooterUrl { get; set; }
        public string HeaderLeft { get; set; }
        public string HeaderCenter { get; set; }
        public string HeaderRight { get; set; }
        public string FooterLeft { get; set; }
        public string FooterCenter { get; set; }
        public string FooterRight { get; set; }
		public object State { get; set; }
        public Dictionary<string, string> Cookies { get; set; }
        public Dictionary<string, string> ExtraParams { get; set; }
    }

	public class PdfConvertEnvironment
	{
		public string TempFolderPath { get; set; }
		public string WkHtmlToPdfPath { get; set; }
		public int Timeout { get; set; }
		public bool Debug { get; set; }
	}

    public class PdfConvert
    {
		static PdfConvertEnvironment _e;

		public static PdfConvertEnvironment Environment
		{
			get
			{
				if (_e == null)
					_e = new PdfConvertEnvironment
					{
						TempFolderPath = Path.GetTempPath(),
						WkHtmlToPdfPath = GetWkhtmlToPdfExeLocation(),
						Timeout = 60000
					};
				return _e;
			}
		}

        private static string GetWkhtmlToPdfExeLocation()
        {
            var programFilesPath = System.Environment.GetEnvironmentVariable("ProgramFiles");
            var filePath = Path.Combine(programFilesPath ?? throw new InvalidOperationException(), @"wkhtmltopdf\wkhtmltopdf.exe");

            if (File.Exists(filePath))
                return filePath;

            var programFilesx86Path = System.Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            filePath = Path.Combine(programFilesx86Path ?? throw new InvalidOperationException(), @"wkhtmltopdf\wkhtmltopdf.exe");

            if (File.Exists(filePath))
                return filePath;

            filePath = Path.Combine(programFilesPath, @"wkhtmltopdf\bin\wkhtmltopdf.exe");
            if (File.Exists(filePath))
                return filePath;

            return Path.Combine(programFilesx86Path, @"wkhtmltopdf\bin\wkhtmltopdf.exe");
        }

		public static void ConvertHtmlToPdf(PdfDocument document, PdfOutput output, bool hideWindow)
		{
			ConvertHtmlToPdf(document, null, output, hideWindow);
		}

		public static void ConvertHtmlToPdf(PdfDocument document, PdfConvertEnvironment environment, PdfOutput woutput, bool hideWindow)
        {
            if (document.Url == "-" && document.Html == null)
                throw new PdfConvertException(
                    string.Format("Вы должны указать HTML-строку, если указали url: {0}", document.Url)
                );

			if (environment == null)
				environment = Environment;

			string outputPdfFilePath;
			bool delete;
			if (woutput.OutputFilePath != null)
			{
				outputPdfFilePath = woutput.OutputFilePath;
				delete = false;
			}
			else
			{
				outputPdfFilePath = Path.Combine(environment.TempFolderPath, string.Format("{0}.pdf", Guid.NewGuid()));
				delete = true;
			}

			if (!File.Exists(environment.WkHtmlToPdfPath))
				throw new PdfConvertException(string.Format("Файл '{0}' не найден. Проверьте, что wkhtmltopdf приложение установлено.", environment.WkHtmlToPdfPath));
            
            var paramsBuilder = new StringBuilder();
            paramsBuilder.Append("--page-size A4 ");
            
			if (!string.IsNullOrEmpty(document.HeaderUrl))
            {
				paramsBuilder.AppendFormat("--header-html {0} ", document.HeaderUrl);
                paramsBuilder.Append("--margin-top 25 ");
                paramsBuilder.Append("--header-spacing 5 ");
            }
			if (!string.IsNullOrEmpty(document.FooterUrl))
            {
				paramsBuilder.AppendFormat("--footer-html {0} ", document.FooterUrl);
                paramsBuilder.Append("--margin-bottom 25 ");
                paramsBuilder.Append("--footer-spacing 5 ");
            }

            if (!string.IsNullOrEmpty(document.HeaderLeft))
                paramsBuilder.AppendFormat("--header-left \"{0}\" ", document.HeaderLeft);

            if (!string.IsNullOrEmpty(document.FooterCenter))
                paramsBuilder.AppendFormat("--header-center \"{0}\" ", document.HeaderCenter);

            if (!string.IsNullOrEmpty(document.FooterCenter))
                paramsBuilder.AppendFormat("--header-right \"{0}\" ", document.HeaderRight);

            if (!string.IsNullOrEmpty(document.FooterLeft))
                paramsBuilder.AppendFormat("--footer-left \"{0}\" ", document.FooterLeft);

            if (!string.IsNullOrEmpty(document.FooterCenter))
                paramsBuilder.AppendFormat("--footer-center \"{0}\" ", document.FooterCenter);

            if (!string.IsNullOrEmpty(document.FooterCenter))
                paramsBuilder.AppendFormat("--footer-right \"{0}\" ", document.FooterRight);

            if(document.ExtraParams != null)
                foreach (var extraParam in document.ExtraParams)
                    paramsBuilder.AppendFormat("--{0} {1} ", extraParam.Key, extraParam.Value);

            if (document.Cookies != null)
                foreach (var cookie in document.Cookies)
                    paramsBuilder.AppendFormat("--cookie {0} {1} ", cookie.Key, cookie.Value);

			paramsBuilder.AppendFormat("\"{0}\" \"{1}\"", document.Url, outputPdfFilePath);
            
            try
            {
                var output = new StringBuilder();
                var error = new StringBuilder();

                using (var process = new Process())
                {
                    process.StartInfo.FileName = environment.WkHtmlToPdfPath;
                    process.StartInfo.Arguments = paramsBuilder.ToString();
                    process.StartInfo.UseShellExecute = false;
                    if (hideWindow)
                        process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardInput = true;

                    using (var outputWaitHandle = new AutoResetEvent(false))
                    using (var errorWaitHandle = new AutoResetEvent(false))
                    {
                        DataReceivedEventHandler outputHandler = (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                outputWaitHandle.Set();
                            }
                            else
                            {
                                output.AppendLine(e.Data);
                            }
                        };

                        DataReceivedEventHandler errorHandler = (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                errorWaitHandle.Set();
                            }
                            else
                            {
                                error.AppendLine(e.Data);
                            }
                        };

                        process.OutputDataReceived += outputHandler;
                        process.ErrorDataReceived += errorHandler;

                        try
                        {
                            process.Start();

                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();

                            if (document.Html != null)
                            {
                                using (var stream = process.StandardInput)
                                {
                                    var buffer = Encoding.UTF8.GetBytes(document.Html);
                                    stream.BaseStream.Write(buffer, 0, buffer.Length);
                                    stream.WriteLine();
                                }
                            }

                            if (process.WaitForExit(environment.Timeout) && outputWaitHandle.WaitOne(environment.Timeout) && errorWaitHandle.WaitOne(environment.Timeout))
                            {
                                if (process.ExitCode != 0 && !File.Exists(outputPdfFilePath))
                                {
                                    throw new PdfConvertException(string.Format("Конвертация из Html в PDF '{0}' не была завершена. Вывод Wkhtmltopdf: \r\n{1}", document.Url, error));
                                }
                            }
                            else
                            {
                                if (!process.HasExited)
                                    process.Kill();

                                throw new PdfConvertTimeoutException();
                            }
                        }
                        finally
                        {
                            process.OutputDataReceived -= outputHandler;
                            process.ErrorDataReceived -= errorHandler;
                        }
                    }
                }

                if (woutput.OutputStream != null)
                {
                    using (Stream fs = new FileStream(outputPdfFilePath, FileMode.Open))
                    {
                        var buffer = new byte[32 * 1024];
                        int read;

                        while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
                            woutput.OutputStream.Write(buffer, 0, read);
                    }
                }

                if (woutput.OutputCallback != null)
                {
                    var pdfFileBytes = File.ReadAllBytes(outputPdfFilePath);
                    woutput.OutputCallback(document, pdfFileBytes);
                }

            }
            finally
            {
                if (delete && File.Exists(outputPdfFilePath))
                    File.Delete(outputPdfFilePath);
            }
        }
    }
}
