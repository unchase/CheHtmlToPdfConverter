using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CheHtmlToPdfConverter.Helpers;
using Codaxy.WkHtmlToPdf;

namespace CheHtmlToPdfConverter
{
    public partial class MainForm : Form
    {
        public BindingList<UrlToConvert> UrlsToConvert { get; set; }

        IniFileHelper.IniFile iniFile = new IniFileHelper.IniFile("config.ini");

        public MainForm()
        {
            InitializeComponent();


            //Process.Start("c:\\Program Files\\priPrinter\\priPrinter.exe", "e:\\26\\1.pdf");


            UrlsToConvert = new BindingList<UrlToConvert>();
            UrlsToConvertDataGridView.DataSource = UrlsToConvert;

            HtmlFileEncodingComboBox.SelectedIndex = 0;
            HtmlFromFileCheckBox.Checked = true;
            HtmlFromFileCheckBox.Checked = false;
            UseOtherProgramToOpenPdfCheckBox.Checked = true;
            UseOtherProgramToOpenPdfCheckBox.Checked = false;

            if (iniFile.KeyExists("Default", "OtherProgramToOpenPdf"))
            {
                OtherProgramToOpenPdfPathTextBox.Text = iniFile.Read("OtherProgramToOpenPdf", "Default");
            }
            else
                OtherProgramToOpenPdfPathTextBox.Text = "";

            HtmlFileEncodingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            DefaultOutputPathTextBox.Text = DefaultFoldersHelper.GetPath(KnownFolder.Downloads);

            if (Environment.Is64BitOperatingSystem)
            {
                ExeFileTextBox.Text = Environment.CurrentDirectory + "\\wkhtmltopdf\\x64\\wkhtmltopdf.exe";
            }
            else
            {
                ExeFileTextBox.Text = Environment.CurrentDirectory + "\\wkhtmltopdf\\x86\\wkhtmltopdf.exe";
            }
        }

        private void ClearOutputFileButton_Click(object sender, EventArgs e)
        {
            OutputFileTextBox.Text = "";
        }

        private void ClearExeFileButton_Click(object sender, EventArgs e)
        {
            ExeFileTextBox.Text = "";
        }

        private void ChangeOutputFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "pdf";
            sfd.Filter = "pdf файлы (*.pdf)|*.pdf";
            sfd.OverwritePrompt = true;
            sfd.CreatePrompt = true;
            sfd.RestoreDirectory = true;
            sfd.Title = "Выберите выходной pdf-файл";
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                OutputFileTextBox.Text = sfd.FileName;
            }
        }

        private void ChangeExeFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "exe";
            ofd.Filter = "exe файлы (*.exe)|*.exe";
            ofd.RestoreDirectory = true;
            ofd.Title = "Выберите расположение wkhtmltopdf.exe";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.SupportMultiDottedExtensions = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ExeFileTextBox.Text = ofd.FileName;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (OutputFileTextBox.Text == "")
            {
                StatusRichTextBox.Text = "Неверно задано имя выходного файла!";
                OutputFileTextBox.Focus();
                return;
            }

            Convert("", OutputFileTextBox.Text, false, true);
        }

        private void Convert(string url, string outputFileFullPath, bool immediately, bool open)
        {
            try
            {
                PdfConvert.Environment.Debug = false;
                if (ExeFileTextBox.Text != "")
                {
                    PdfConvert.Environment.WkHtmlToPdfPath = ExeFileTextBox.Text;
                }

                var pdfDocument = new PdfDocument();
                if (!immediately)
                {
                    if (!HtmlFromFileCheckBox.Checked)
                    {
                        //^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$
                        //^((https?|ftp)\:\/\/)?([a-z0-9]{1})((\.[a-z0-9-])|([a-z0-9-]))*\.([a-z]{2,6})(\/?)$
                        Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                        Match m = r.Match(HtmlPageTextBox.Text);
                        if (!m.Success)
                        {
                            StatusRichTextBox.Text = "Неверно задан URL html-страницы!";
                            HtmlPageTextBox.Focus();
                            return;
                        }

                        pdfDocument.Url = HtmlPageTextBox.Text;


                    }
                    else
                    {
                        pdfDocument.Url = "-";
                        pdfDocument.Html = StatusRichTextBox.Text;


                    }
                }
                else
                {
                    pdfDocument.Url = url;
                    if (AddUrlToFooterCheckBox.Checked)
                    {
                        pdfDocument.FooterCenter = url;
                    }
                    if (AddTitleToHeaderCheckBox.Checked)
                    {
                        pdfDocument.HeaderLeft = "[title]";
                    }

                }

                PdfConvert.ConvertHtmlToPdf(pdfDocument, new PdfOutput
                {
                    OutputFilePath = outputFileFullPath
                });

                //PdfConvert.ConvertHtmlToPdf(new PdfDocument 
                //{ 
                //    Url = "http://www.codaxy.com",
                //    HeaderLeft = "[title]",
                //    HeaderRight = "[date] [time]",
                //    FooterCenter = "Page [page] of [topage]"


                StatusRichTextBox.Text += "\"" + outputFileFullPath + "\" создан.\n";

                if (open)
                {
                    Process.Start(outputFileFullPath);
                }
            }
            catch (Exception ex)
            {
                StatusRichTextBox.Text += "Произошла ошибка: " + ex.Message + "\n";
            }
        }

        private void CopyFromClipboardButton_Click(object sender, EventArgs e)
        {
            HtmlPageTextBox.Text = Clipboard.GetText(TextDataFormat.Text);
        }

        private void CopyHtmlFromClipboardButton_Click(object sender, EventArgs e)
        {
            StatusRichTextBox.Text = Clipboard.GetText(TextDataFormat.Text);
        }

        private void ChangeHtmlFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "htm";
            ofd.Filter = "html файлы (*.html)|*.html|htm файлы (*.htm)|*.htm";
            ofd.RestoreDirectory = true;
            ofd.Title = "Выберите html или htm файл";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.SupportMultiDottedExtensions = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    var encoding = GetEncoding();
                    var text = File.ReadAllText(ofd.FileName, encoding);
                    StatusRichTextBox.Text = text;
                }
            }
        }

        private Encoding GetEncoding()
        {
            switch (HtmlFileEncodingComboBox.SelectedText)
            {
                case "UTF8":
                    return Encoding.UTF8;
                case "ASCII":
                    return Encoding.ASCII;
                case "Unicode":
                    return Encoding.Unicode;
                case "1251":
                    return Encoding.GetEncoding(1251);
                default:
                    return Encoding.UTF8;
            }
        }

        private void HtmlFromFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            HtmlPageTextBox.Enabled = !HtmlFromFileCheckBox.Checked;
            CopyFromClipboardButton.Enabled = !HtmlFromFileCheckBox.Checked;
            CopyHtmlFromClipboardButton.Enabled = HtmlFromFileCheckBox.Checked;
            ChangeHtmlFileButton.Enabled = HtmlFromFileCheckBox.Checked;
            HtmlFileEncodingComboBox.Enabled = HtmlFromFileCheckBox.Checked;
            StatusRichTextBox.ReadOnly = !HtmlFromFileCheckBox.Checked;
        }

        private void ChangeDefaultOutputPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Выберите каталог для выходного pdf-файла";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DefaultOutputPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void ConvertImmediatelyButton_Click(object sender, EventArgs e)
        {
            if (DefaultOutputPathTextBox.Text == "")
            {
                StatusRichTextBox.Text = "Неверно задан каталог для выходного файла!";
                OutputFileTextBox.Focus();
                return;
            }

            StatusRichTextBox.Text = "";

            var fileName = "";
            var url = Clipboard.GetText(TextDataFormat.Text);
            if (GetImmediatelyTitleFromUrlСheckBox.Checked)
            {
                int timeout;
                if (!int.TryParse(ResponseTimeoutTextBox.Text, out timeout))
                    timeout = 15000;

                fileName = ResponseTagHelper.GetWebPageTitle(url, timeout);
                if (fileName == "")
                    fileName = Path.Combine(DefaultOutputPathTextBox.Text,
                        DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                        DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".pdf");
                else
                {
                    fileName = Path.Combine(DefaultOutputPathTextBox.Text, fileName + ".pdf");
                }
            } 
            else
            {
                fileName = Path.Combine(DefaultOutputPathTextBox.Text,
                    DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                    DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".pdf");
            }

            var oldFileName = fileName;
            var findNull = fileName.IndexOf('\0');
            if (findNull != null && findNull >= 0)
                fileName = fileName.Remove(findNull);

            if (!string.Equals(fileName, oldFileName))
                StatusRichTextBox.Text += "Выходное имя файла \"" + oldFileName + "\" изменено на \"" + fileName + "\"\n";

            Convert(url, fileName, true,
                OpenPdfFileCheckBox.Checked);
        }

        private void AddRawButton_Click(object sender, EventArgs e)
        {
            UrlsToConvert.Add(new UrlToConvert("", false));
        }

        private void DeleteRawButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in UrlsToConvertDataGridView.SelectedRows)
            {
                UrlsToConvert.Remove((UrlToConvert)selectedRow.DataBoundItem);
            }
        }

        private void ConvertUrlsListButton_Click(object sender, EventArgs e)
        {
            if (DefaultOutputPathTextBox.Text == "")
            {
                StatusRichTextBox.Text = "Неверно задан каталог для выходного файла!";
                OutputFileTextBox.Focus();
                return;
            }

            StatusRichTextBox.Text = "";

            if (ConvertAllCheckBox.Checked)
                UrlsToConvertDataGridView.SelectAll();

            int timeout;
            if (!int.TryParse(ResponseTimeoutTextBox.Text, out timeout))
                timeout = 15000;

            var count = 0;
            foreach (DataGridViewRow row in UrlsToConvertDataGridView.SelectedRows)
            {
                count++;
                UrlToConvert realDataRow = (UrlToConvert)row.DataBoundItem;

                //^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$
                //^((https?|ftp)\:\/\/)?([a-z0-9]{1})((\.[a-z0-9-])|([a-z0-9-]))*\.([a-z]{2,6})(\/?)$
                Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                Match m = r.Match(realDataRow.Url);
                if (!m.Success)
                {
                    StatusRichTextBox.Text += "Неверно задан URL html-страницы: " + realDataRow.Url + "\n";
                    HtmlPageTextBox.Focus();
                    continue;
                }

                string url = FixUrlsList(realDataRow.Url);
                
                var fileName = realDataRow.Name;
                if (GetTitleFromUrlСheckBox.Checked)
                {
                    StatusRichTextBox.Text += "Идет получение Title по Url...\n";
                    string title = ResponseTagHelper.GetWebPageTitle(url, timeout);
                    if (title != "")
                        fileName = title;
                }


                ///
                //var t = HttpUtility.UrlDecode(fileName);


                
                //StringBuilder output = new StringBuilder(fileName.Length);

                //for (int i = 0; i < fileName.Length; i++)
                //{
                //    if (fileName[i] == '&')
                //    {
                //        int startOfEntity = i; // just for easier reading
                //        int endOfEntity = fileName.IndexOf(';', startOfEntity);
                //        string entity = fileName.Substring(startOfEntity, endOfEntity - startOfEntity);
                //        int unicodeNumber = (int)(HttpUtility.HtmlDecode(entity)[0]);

                //        //int code = int.Parse(unicodeNumber.ToString(), System.Globalization.NumberStyles.Number);
                        
                //        string unicodeString = ((char)unicodeNumber).ToString();


                //        output.Append(unicodeString);
                //        i = endOfEntity; // continue parsing after the end of the entity
                //    }
                //    else
                //        output.Append(fileName[i]);
                //}
                //var tt = output.ToString();
                ///


                fileName = fileName.Replace('/', '_');
                fileName = fileName.Replace('\\', '_');
                fileName = fileName.Replace(':', '_');
                fileName = fileName.Replace('*', '_');
                fileName = fileName.Replace('?', '_');
                fileName = fileName.Replace('«', '_');
                fileName = fileName.Replace('<', '_');
                fileName = fileName.Replace('>', '_');
                fileName = fileName.Replace('|', '_');


                if (!string.Equals(fileName, realDataRow.Name))
                    StatusRichTextBox.Text += "Выходное имя файла \"" + realDataRow.Name + "\" изменено на \"" + fileName + "\"\n";

                if (NumerateOutputPdfFileNamesCheckBox.Checked)
                    fileName = count + " - " + fileName;

                Convert(url, Path.Combine(DefaultOutputPathTextBox.Text, fileName + ".pdf"),
                    true, realDataRow.Open);
            }
        }

        private string FixUrlsList(string urlOld)
        {
            string url = urlOld;
            var findNull = url.IndexOf('\0');
            if (findNull != null && findNull >= 0)
                url = url.Remove(findNull);

            int findUntilHttp = -1;
            while ((url.IndexOf("http")) != 0)
            {
                url = url.Remove(0, 1);
            }

            var findUntil = -1;
            if ((findUntil = url.IndexOf("\"")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("*")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("«")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("<")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf(">")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("|")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("(")) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf(")")) >= 0)
            {
                url = url.Remove(findUntil);
            }

            if (!string.Equals(url, urlOld))
                StatusRichTextBox.Text += "Url \"" + urlOld + "\" изменен на \"" + url + "\"\n";

            return url;
        }

        private void FixUrlsList()
        {
            foreach (var UrlToConvert in UrlsToConvert)
            {
                string url = UrlToConvert.Url;
                var findNull = url.IndexOf('\0');
                if (findNull != null && findNull >= 0)
                    url = url.Remove(findNull);

                int findUntilHttp = -1;
                while ((url.IndexOf("http")) != 0)
                {
                    url = url.Remove(0, 1);
                }

                var findUntil = -1;
                if ((findUntil = url.IndexOf("\"")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("*")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("«")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("<")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf(">")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("|")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("(")) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf(")")) >= 0)
                {
                    url = url.Remove(findUntil);
                }

                if (!string.Equals(url, UrlToConvert.Url))
                    StatusRichTextBox.Text += "Url \"" + UrlToConvert.Url + "\" изменен на \"" + url + "\"\n";
            }

            UrlsToConvertDataGridView.Refresh();
        }

        private void ExeFileTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                ExeFileTextBox.Text = file;
            }
        }

        private void ExeFileTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void OutputFileTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                ExeFileTextBox.Text = file;
            }
        }

        private void OutputFileTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                if (File.Exists(path))
                    e.Effect = DragDropEffects.All;
            }
        }

        private void UrlsToConvertDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            int timeout;
            if (!int.TryParse(ResponseTimeoutTextBox.Text, out timeout))
                timeout = 15000;

            int counter = 0;
            foreach (string filePath in files)
            {
                string line;
                System.IO.StreamReader file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    var lines = line.Split(' ');
                    foreach (var l in lines)
                    {
                        //^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$
                        //^((https?|ftp)\:\/\/)?([a-z0-9]{1})((\.[a-z0-9-])|([a-z0-9-]))*\.([a-z]{2,6})(\/?)$
                        Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                        Match m = r.Match(l);
                        if (m.Success)
                        {
                            if (GetTitleFromFileUrlsСheckBox.Checked)
                            {
                                

                                string title = ResponseTagHelper.GetWebPageTitle(l.Trim(), timeout);
                                if (title != "")
                                    UrlsToConvert.Add(new UrlToConvert(l.Trim(), title, false));
                                else
                                    UrlsToConvert.Add(new UrlToConvert(l.Trim(), false));
                            }
                            else
                                UrlsToConvert.Add(new UrlToConvert(l.Trim(), false));
                        }
                    }
                    counter++;
                }
                file.Close();
            }

            StatusRichTextBox.Text += "Всего считано: " + counter + " строк.\n";
        }

        private void UrlsToConvertDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                if (File.Exists(path))
                    e.Effect = DragDropEffects.All;
            }
        }

        private void DefaultOutputPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            DefaultOutputPathTextBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void DefaultOutputPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                if (Directory.Exists(path))
                    e.Effect = DragDropEffects.All;
            }
        }

        private void SaveStatusRichTextBoxButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "log";
            sfd.Filter = "log файлы (*.log)|*.log";
            sfd.OverwritePrompt = true;
            sfd.CreatePrompt = true;
            sfd.RestoreDirectory = true;
            sfd.Title = "Выберите выходной log-файл";
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var file = new StreamWriter(sfd.FileName))
                {
                    file.Write(StatusRichTextBox.Text);
                }
            }
        }

        private void OpenSelectedPdfFilesAfterConvertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UrlsToConvert.Count; i++)
            {
                UrlsToConvert[i].Open = true;
            }
            UrlsToConvertDataGridView.Refresh();
        }

        private void NotOpenSelectedPdfFilesAfterConvertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UrlsToConvert.Count; i++)
            {
                UrlsToConvert[i].Open = false;
            }
            UrlsToConvertDataGridView.Refresh();
        }

        private void ClearStatusRichTextBoxButton_Click(object sender, EventArgs e)
        {
            StatusRichTextBox.Text = "";
        }

        private void ChangeOtherProgramToOpenPdfPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "exe";
            ofd.Filter = "exe файлы (*.exe)|*.exe";
            ofd.RestoreDirectory = true;
            ofd.Title = "Выберите расположение программы для открытия pdf-файлов";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.SupportMultiDottedExtensions = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OtherProgramToOpenPdfPathTextBox.Text = ofd.FileName;
            }
        }

        private void OtherProgramToOpenPdfPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                OtherProgramToOpenPdfPathTextBox.Text = file;
            }
        }

        private void OtherProgramToOpenPdfPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                if (File.Exists(path))
                    e.Effect = DragDropEffects.All;
            }
        }

        private void ClearOtherProgramToOpenPdfPathButton_Click(object sender, EventArgs e)
        {
            OtherProgramToOpenPdfPathTextBox.Text = "";
        }

        private void UseOtherProgramToOpenPdfCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OtherProgramToOpenPdfPathTextBox.Enabled = UseOtherProgramToOpenPdfCheckBox.Checked;
            ClearOtherProgramToOpenPdfPathButton.Enabled = UseOtherProgramToOpenPdfCheckBox.Checked;
            ChangeOtherProgramToOpenPdfPathButton.Enabled = UseOtherProgramToOpenPdfCheckBox.Checked;
        }

        private void ClearResponseTimeoutTextBoxButton_Click(object sender, EventArgs e)
        {
            ResponseTimeoutTextBox.Text = "15000";
        }

        private void ResponseTimeoutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != System.Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
