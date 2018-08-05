using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CheHtmlToPdfConverter.Helpers;

namespace CheHtmlToPdfConverter
{
    public partial class MainForm : Form
    {
        public BindingList<UrlToConvert> UrlsToConvert { get; set; }

        readonly IniFileHelper.IniFile _iniFile = new IniFileHelper.IniFile("config.ini");

        public MainForm()
        {
            InitializeComponent();

            UrlsToConvert = new BindingList<UrlToConvert>();
            UrlsToConvertDataGridView.DataSource = UrlsToConvert;

            HtmlFileEncodingComboBox.SelectedIndex = 0;
            HtmlFromFileCheckBox.Checked = true;
            HtmlFromFileCheckBox.Checked = false;
            UseOtherProgramToOpenPdfCheckBox.Checked = true;
            UseOtherProgramToOpenPdfCheckBox.Checked = false;

            OtherProgramToOpenPdfPathTextBox.Text = _iniFile.KeyExists("Default", "OtherProgramToOpenPdf") ? _iniFile.Read("OtherProgramToOpenPdf", "Default") : "";

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
            var sfd = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "pdf",
                Filter = @"pdf файлы (*.pdf)|*.pdf",
                OverwritePrompt = true,
                CreatePrompt = true,
                RestoreDirectory = true,
                Title = @"Выберите выходной pdf-файл",
                ValidateNames = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                OutputFileTextBox.Text = sfd.FileName;
            }
        }

        private void ChangeExeFileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = "exe",
                Filter = @"exe файлы (*.exe)|*.exe",
                RestoreDirectory = true,
                Title = @"Выберите расположение wkhtmltopdf.exe",
                ValidateNames = true,
                CheckFileExists = true,
                Multiselect = false,
                SupportMultiDottedExtensions = false
            };

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
                        var r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                        var m = r.Match(HtmlPageTextBox.Text);
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
                }, HideWkhtmltopdfWindowCheckBox.Checked);

                StatusRichTextBox.Text += "\"" + outputFileFullPath + "\" создан.\n";

                if (!open) return;

                if (!UseOtherProgramToOpenPdfCheckBox.Checked)
                    Process.Start(outputFileFullPath);
                else
                    Process.Start(OtherProgramToOpenPdfPathTextBox.Text, outputFileFullPath);
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
            var ofd = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = "htm",
                Filter = @"html файлы (*.html)|*.html|htm файлы (*.htm)|*.htm",
                RestoreDirectory = true,
                Title = @"Выберите html или htm файл",
                ValidateNames = true,
                CheckFileExists = true,
                Multiselect = false,
                SupportMultiDottedExtensions = false
            };

            if (ofd.ShowDialog() != DialogResult.OK || !File.Exists(ofd.FileName)) return;

            var encoding = GetEncoding();
            StatusRichTextBox.Text = File.ReadAllText(ofd.FileName, encoding);
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
            var fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Выберите каталог для выходного pdf-файла"
            };

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

            string fileName;
            var url = Clipboard.GetText(TextDataFormat.Text);
            if (GetImmediatelyTitleFromUrlСheckBox.Checked)
            {
                if (!int.TryParse(ResponseTimeoutTextBox.Text, out var timeout))
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
            if (findNull >= 0)
                fileName = fileName.Remove(findNull);

            if (!string.Equals(fileName, oldFileName))
                StatusRichTextBox.Text += "Выходное имя файла \"" + oldFileName + "\" изменено на \"" + fileName + "\"\n";

            Convert(url, fileName, true,
                OpenPdfFileCheckBox.Checked);
        }

        private void AddRawButton_Click(object sender, EventArgs e)
        {
            UrlsToConvert.Add(new UrlToConvert("", false));
            UrlsListGroupBox.Text = "Список адресов для конвертирования - " + UrlsToConvert.Count;
        }

        private void DeleteRawButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in UrlsToConvertDataGridView.SelectedRows)
            {
                UrlsToConvert.Remove((UrlToConvert)selectedRow.DataBoundItem);
            }
            UrlsListGroupBox.Text = "Список адресов для конвертирования - " + UrlsToConvert.Count;
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

            if (!int.TryParse(ResponseTimeoutTextBox.Text, out var timeout))
                timeout = 15000;

            var count = 0;
            foreach (DataGridViewRow row in UrlsToConvertDataGridView.SelectedRows)
            {
                count++;
                var realDataRow = (UrlToConvert)row.DataBoundItem;

                var r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                var m = r.Match(realDataRow.Url);
                if (!m.Success)
                {
                    StatusRichTextBox.Text += "Неверно задан URL html-страницы: " + realDataRow.Url + "\n";
                    HtmlPageTextBox.Focus();
                    continue;
                }

                var url = FixUrlsList(realDataRow.Url);
                
                var fileName = realDataRow.Name;
                if (GetTitleFromUrlСheckBox.Checked)
                {
                    StatusRichTextBox.Text += "Идет получение Title по Url...\n";
                    var title = ResponseTagHelper.GetWebPageTitle(url, timeout);
                    if (title != "")
                        fileName = title;
                }

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
            var url = urlOld;
            var findNull = url.IndexOf('\0');
            if (findNull >= 0)
                url = url.Remove(findNull);

            while (url.IndexOf("http") != 0)
            {
                url = url.Remove(0, 1);
            }

            int findUntil;
            if ((findUntil = url.IndexOf("\"", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("*", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("«", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("<", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf(">", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("|", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf("(", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }
            if ((findUntil = url.IndexOf(")", StringComparison.Ordinal)) >= 0)
            {
                url = url.Remove(findUntil);
            }

            if (!string.Equals(url, urlOld))
                StatusRichTextBox.Text += "Url \"" + urlOld + "\" изменен на \"" + url + "\"\n";

            return url;
        }

        private void FixUrlsList()
        {
            foreach (var urlToConvert in UrlsToConvert)
            {
                var url = urlToConvert.Url;
                var findNull = url.IndexOf('\0');
                if (findNull >= 0)
                    url = url.Remove(findNull);

                while (url.IndexOf("http") != 0)
                {
                    url = url.Remove(0, 1);
                }

                int findUntil;
                if ((findUntil = url.IndexOf("\"", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("*", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("«", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("<", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf(">", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("|", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf("(", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }
                if ((findUntil = url.IndexOf(")", StringComparison.Ordinal)) >= 0)
                {
                    url = url.Remove(findUntil);
                }

                if (!string.Equals(url, urlToConvert.Url))
                    StatusRichTextBox.Text += "Url \"" + urlToConvert.Url + "\" изменен на \"" + url + "\"\n";
            }

            UrlsToConvertDataGridView.Refresh();
        }

        private void ExeFileTextBox_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var file in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                ExeFileTextBox.Text = file;
            }
        }

        private void ExeFileTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void OutputFileTextBox_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var file in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                ExeFileTextBox.Text = file;
            }
        }

        private void OutputFileTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false)) return;
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (File.Exists(path))
                e.Effect = DragDropEffects.All;
        }

        private void UrlsToConvertDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!int.TryParse(ResponseTimeoutTextBox.Text, out var timeout))
                timeout = 15000;

            var counter = 0;
            foreach (var filePath in files)
            {
                string line;
                var file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    foreach (var l in line.Split(' '))
                    {
                        var r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                        var m = r.Match(l);
                        if (!m.Success) continue;
                        if (GetTitleFromFileUrlsСheckBox.Checked)
                        {
                            var title = ResponseTagHelper.GetWebPageTitle(l.Trim(), timeout);
                            UrlsToConvert.Add(title != ""
                                ? new UrlToConvert(l.Trim(), title, false)
                                : new UrlToConvert(l.Trim(), false));
                        }
                        else
                            UrlsToConvert.Add(new UrlToConvert(l.Trim(), false));

                        UrlsListGroupBox.Text = "Список адресов для конвертирования - " + UrlsToConvert.Count;
                    }
                    counter++;
                }
                file.Close();
            }

            StatusRichTextBox.Text += "Всего считано: " + counter + " строк.\n";
        }

        private void UrlsToConvertDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false)) return;
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (File.Exists(path))
                e.Effect = DragDropEffects.All;
        }

        private void DefaultOutputPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            DefaultOutputPathTextBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void DefaultOutputPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false)) return;
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (Directory.Exists(path))
                e.Effect = DragDropEffects.All;
        }

        private void SaveStatusRichTextBoxButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "log",
                Filter = @"log файлы (*.log)|*.log",
                OverwritePrompt = true,
                CreatePrompt = true,
                RestoreDirectory = true,
                Title = @"Выберите выходной log-файл",
                ValidateNames = true
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (var file = new StreamWriter(sfd.FileName))
            {
                file.Write(StatusRichTextBox.Text);
            }
        }

        private void OpenSelectedPdfFilesAfterConvertButton_Click(object sender, EventArgs e)
        {
            foreach (var url in UrlsToConvert)
            {
                url.Open = true;
            }

            UrlsToConvertDataGridView.Refresh();
        }

        private void NotOpenSelectedPdfFilesAfterConvertButton_Click(object sender, EventArgs e)
        {
            foreach (var url in UrlsToConvert)
            {
                url.Open = false;
            }

            UrlsToConvertDataGridView.Refresh();
        }

        private void ClearStatusRichTextBoxButton_Click(object sender, EventArgs e)
        {
            StatusRichTextBox.Text = "";
        }

        private void ChangeOtherProgramToOpenPdfPathButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = "exe",
                Filter = @"exe файлы (*.exe)|*.exe",
                RestoreDirectory = true,
                Title = @"Выберите расположение программы для открытия pdf-файлов",
                ValidateNames = true,
                CheckFileExists = true,
                Multiselect = false,
                SupportMultiDottedExtensions = false
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OtherProgramToOpenPdfPathTextBox.Text = ofd.FileName;
            }
        }

        private void OtherProgramToOpenPdfPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var file in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                OtherProgramToOpenPdfPathTextBox.Text = file;
            }
        }

        private void OtherProgramToOpenPdfPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false)) return;
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (File.Exists(path))
                e.Effect = DragDropEffects.All;
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != System.Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для конвертирования html-страниц в pdf-файлы с исходным форматированием.\nРазработано 'unchase'.", "О программе CheHtmlToPdfConverter v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
