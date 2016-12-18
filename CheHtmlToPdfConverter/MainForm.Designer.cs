namespace CheHtmlToPdfConverter
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ConvertButton = new System.Windows.Forms.Button();
            this.OutputFileTextBox = new System.Windows.Forms.TextBox();
            this.ExeFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeOutputFileButton = new System.Windows.Forms.Button();
            this.ChangeExeFileButton = new System.Windows.Forms.Button();
            this.ClearOutputFileButton = new System.Windows.Forms.Button();
            this.ClearExeFileButton = new System.Windows.Forms.Button();
            this.CopyFromClipboardButton = new System.Windows.Forms.Button();
            this.StatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CopyHtmlFromClipboardButton = new System.Windows.Forms.Button();
            this.ChangeHtmlFileButton = new System.Windows.Forms.Button();
            this.HtmlFileEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.HtmlFromFileCheckBox = new System.Windows.Forms.CheckBox();
            this.HtmlPageTextBox = new System.Windows.Forms.TextBox();
            this.DefaultOutputPathTextBox = new System.Windows.Forms.TextBox();
            this.ConvertImmediatelyButton = new System.Windows.Forms.Button();
            this.ChangeDefaultOutputPathButton = new System.Windows.Forms.Button();
            this.OpenPdfFileCheckBox = new System.Windows.Forms.CheckBox();
            this.UrlsToConvertDataGridView = new System.Windows.Forms.DataGridView();
            this.AddRawButton = new System.Windows.Forms.Button();
            this.DeleteRawButton = new System.Windows.Forms.Button();
            this.UrlsListGroupBox = new System.Windows.Forms.GroupBox();
            this.ConvertAllCheckBox = new System.Windows.Forms.CheckBox();
            this.GetTitleFromFileUrlsСheckBox = new System.Windows.Forms.CheckBox();
            this.GetTitleFromUrlСheckBox = new System.Windows.Forms.CheckBox();
            this.NotOpenSelectedPdfFilesAfterConvertButton = new System.Windows.Forms.Button();
            this.OpenSelectedPdfFilesAfterConvertButton = new System.Windows.Forms.Button();
            this.ConvertUrlsListButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GetImmediatelyTitleFromUrlСheckBox = new System.Windows.Forms.CheckBox();
            this.SaveStatusRichTextBoxButton = new System.Windows.Forms.Button();
            this.ClearStatusRichTextBoxButton = new System.Windows.Forms.Button();
            this.UseOtherProgramToOpenPdfCheckBox = new System.Windows.Forms.CheckBox();
            this.OtherProgramToOpenPdfPathTextBox = new System.Windows.Forms.TextBox();
            this.ChangeOtherProgramToOpenPdfPathButton = new System.Windows.Forms.Button();
            this.ClearOtherProgramToOpenPdfPathButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NumerateOutputPdfFileNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.AddUrlToFooterCheckBox = new System.Windows.Forms.CheckBox();
            this.AddTitleToHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ResponseTimeoutTextBox = new System.Windows.Forms.TextBox();
            this.ClearResponseTimeoutTextBoxButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UrlsToConvertDataGridView)).BeginInit();
            this.UrlsListGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(673, 165);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(104, 23);
            this.ConvertButton.TabIndex = 0;
            this.ConvertButton.Text = "Конвертировать";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // OutputFileTextBox
            // 
            this.OutputFileTextBox.Location = new System.Drawing.Point(244, 39);
            this.OutputFileTextBox.Name = "OutputFileTextBox";
            this.OutputFileTextBox.Size = new System.Drawing.Size(533, 20);
            this.OutputFileTextBox.TabIndex = 2;
            this.OutputFileTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.OutputFileTextBox_DragDrop);
            this.OutputFileTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.OutputFileTextBox_DragEnter);
            // 
            // ExeFileTextBox
            // 
            this.ExeFileTextBox.AllowDrop = true;
            this.ExeFileTextBox.Location = new System.Drawing.Point(244, 66);
            this.ExeFileTextBox.Name = "ExeFileTextBox";
            this.ExeFileTextBox.ReadOnly = true;
            this.ExeFileTextBox.Size = new System.Drawing.Size(533, 20);
            this.ExeFileTextBox.TabIndex = 3;
            this.ExeFileTextBox.Text = "C:\\Program Files\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            this.ExeFileTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExeFileTextBox_DragDrop);
            this.ExeFileTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExeFileTextBox_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите URL-адрес страницы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите путь к выходному Pdf-файлу:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите расположение \"wkhtmltopdf.exe\":";
            // 
            // ChangeOutputFileButton
            // 
            this.ChangeOutputFileButton.Location = new System.Drawing.Point(823, 37);
            this.ChangeOutputFileButton.Name = "ChangeOutputFileButton";
            this.ChangeOutputFileButton.Size = new System.Drawing.Size(70, 23);
            this.ChangeOutputFileButton.TabIndex = 7;
            this.ChangeOutputFileButton.Text = "Выбрать";
            this.ChangeOutputFileButton.UseVisualStyleBackColor = true;
            this.ChangeOutputFileButton.Click += new System.EventHandler(this.ChangeOutputFileButton_Click);
            // 
            // ChangeExeFileButton
            // 
            this.ChangeExeFileButton.Location = new System.Drawing.Point(823, 64);
            this.ChangeExeFileButton.Name = "ChangeExeFileButton";
            this.ChangeExeFileButton.Size = new System.Drawing.Size(70, 23);
            this.ChangeExeFileButton.TabIndex = 8;
            this.ChangeExeFileButton.Text = "Выбрать";
            this.ChangeExeFileButton.UseVisualStyleBackColor = true;
            this.ChangeExeFileButton.Click += new System.EventHandler(this.ChangeExeFileButton_Click);
            // 
            // ClearOutputFileButton
            // 
            this.ClearOutputFileButton.Location = new System.Drawing.Point(783, 37);
            this.ClearOutputFileButton.Name = "ClearOutputFileButton";
            this.ClearOutputFileButton.Size = new System.Drawing.Size(34, 23);
            this.ClearOutputFileButton.TabIndex = 9;
            this.ClearOutputFileButton.Text = "X";
            this.ClearOutputFileButton.UseVisualStyleBackColor = true;
            this.ClearOutputFileButton.Click += new System.EventHandler(this.ClearOutputFileButton_Click);
            // 
            // ClearExeFileButton
            // 
            this.ClearExeFileButton.Location = new System.Drawing.Point(783, 64);
            this.ClearExeFileButton.Name = "ClearExeFileButton";
            this.ClearExeFileButton.Size = new System.Drawing.Size(34, 23);
            this.ClearExeFileButton.TabIndex = 10;
            this.ClearExeFileButton.Text = "X";
            this.ClearExeFileButton.UseVisualStyleBackColor = true;
            this.ClearExeFileButton.Click += new System.EventHandler(this.ClearExeFileButton_Click);
            // 
            // CopyFromClipboardButton
            // 
            this.CopyFromClipboardButton.Location = new System.Drawing.Point(869, 10);
            this.CopyFromClipboardButton.Name = "CopyFromClipboardButton";
            this.CopyFromClipboardButton.Size = new System.Drawing.Size(24, 23);
            this.CopyFromClipboardButton.TabIndex = 11;
            this.CopyFromClipboardButton.Text = "<-";
            this.CopyFromClipboardButton.UseVisualStyleBackColor = true;
            this.CopyFromClipboardButton.Click += new System.EventHandler(this.CopyFromClipboardButton_Click);
            // 
            // StatusRichTextBox
            // 
            this.StatusRichTextBox.Location = new System.Drawing.Point(13, 92);
            this.StatusRichTextBox.Name = "StatusRichTextBox";
            this.StatusRichTextBox.Size = new System.Drawing.Size(764, 69);
            this.StatusRichTextBox.TabIndex = 12;
            this.StatusRichTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(797, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "<= html-разметка";
            // 
            // CopyHtmlFromClipboardButton
            // 
            this.CopyHtmlFromClipboardButton.Location = new System.Drawing.Point(783, 132);
            this.CopyHtmlFromClipboardButton.Name = "CopyHtmlFromClipboardButton";
            this.CopyHtmlFromClipboardButton.Size = new System.Drawing.Size(34, 23);
            this.CopyHtmlFromClipboardButton.TabIndex = 14;
            this.CopyHtmlFromClipboardButton.Text = "<-";
            this.CopyHtmlFromClipboardButton.UseVisualStyleBackColor = true;
            this.CopyHtmlFromClipboardButton.Click += new System.EventHandler(this.CopyHtmlFromClipboardButton_Click);
            // 
            // ChangeHtmlFileButton
            // 
            this.ChangeHtmlFileButton.Location = new System.Drawing.Point(823, 132);
            this.ChangeHtmlFileButton.Name = "ChangeHtmlFileButton";
            this.ChangeHtmlFileButton.Size = new System.Drawing.Size(70, 23);
            this.ChangeHtmlFileButton.TabIndex = 15;
            this.ChangeHtmlFileButton.Text = "Выбрать";
            this.ChangeHtmlFileButton.UseVisualStyleBackColor = true;
            this.ChangeHtmlFileButton.Click += new System.EventHandler(this.ChangeHtmlFileButton_Click);
            // 
            // HtmlFileEncodingComboBox
            // 
            this.HtmlFileEncodingComboBox.FormattingEnabled = true;
            this.HtmlFileEncodingComboBox.Items.AddRange(new object[] {
            "UTF8",
            "ASCII",
            "Unicode",
            "1251"});
            this.HtmlFileEncodingComboBox.Location = new System.Drawing.Point(783, 167);
            this.HtmlFileEncodingComboBox.Name = "HtmlFileEncodingComboBox";
            this.HtmlFileEncodingComboBox.Size = new System.Drawing.Size(110, 21);
            this.HtmlFileEncodingComboBox.TabIndex = 16;
            // 
            // HtmlFromFileCheckBox
            // 
            this.HtmlFromFileCheckBox.AutoSize = true;
            this.HtmlFromFileCheckBox.Location = new System.Drawing.Point(783, 96);
            this.HtmlFromFileCheckBox.Name = "HtmlFromFileCheckBox";
            this.HtmlFromFileCheckBox.Size = new System.Drawing.Size(110, 17);
            this.HtmlFromFileCheckBox.TabIndex = 17;
            this.HtmlFromFileCheckBox.Text = "Файл или буфер";
            this.HtmlFromFileCheckBox.UseVisualStyleBackColor = true;
            this.HtmlFromFileCheckBox.CheckedChanged += new System.EventHandler(this.HtmlFromFileCheckBox_CheckedChanged);
            // 
            // HtmlPageTextBox
            // 
            this.HtmlPageTextBox.Location = new System.Drawing.Point(244, 12);
            this.HtmlPageTextBox.Name = "HtmlPageTextBox";
            this.HtmlPageTextBox.Size = new System.Drawing.Size(619, 20);
            this.HtmlPageTextBox.TabIndex = 1;
            // 
            // DefaultOutputPathTextBox
            // 
            this.DefaultOutputPathTextBox.AllowDrop = true;
            this.DefaultOutputPathTextBox.Location = new System.Drawing.Point(6, 42);
            this.DefaultOutputPathTextBox.Name = "DefaultOutputPathTextBox";
            this.DefaultOutputPathTextBox.ReadOnly = true;
            this.DefaultOutputPathTextBox.Size = new System.Drawing.Size(687, 20);
            this.DefaultOutputPathTextBox.TabIndex = 18;
            this.DefaultOutputPathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.DefaultOutputPathTextBox_DragDrop);
            this.DefaultOutputPathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.DefaultOutputPathTextBox_DragEnter);
            // 
            // ConvertImmediatelyButton
            // 
            this.ConvertImmediatelyButton.Location = new System.Drawing.Point(768, 39);
            this.ConvertImmediatelyButton.Name = "ConvertImmediatelyButton";
            this.ConvertImmediatelyButton.Size = new System.Drawing.Size(101, 23);
            this.ConvertImmediatelyButton.TabIndex = 19;
            this.ConvertImmediatelyButton.Text = "Конвертировать";
            this.ConvertImmediatelyButton.UseVisualStyleBackColor = true;
            this.ConvertImmediatelyButton.Click += new System.EventHandler(this.ConvertImmediatelyButton_Click);
            // 
            // ChangeDefaultOutputPathButton
            // 
            this.ChangeDefaultOutputPathButton.Location = new System.Drawing.Point(699, 39);
            this.ChangeDefaultOutputPathButton.Name = "ChangeDefaultOutputPathButton";
            this.ChangeDefaultOutputPathButton.Size = new System.Drawing.Size(63, 23);
            this.ChangeDefaultOutputPathButton.TabIndex = 20;
            this.ChangeDefaultOutputPathButton.Text = "Выбрать";
            this.ChangeDefaultOutputPathButton.UseVisualStyleBackColor = true;
            this.ChangeDefaultOutputPathButton.Click += new System.EventHandler(this.ChangeDefaultOutputPathButton_Click);
            // 
            // OpenPdfFileCheckBox
            // 
            this.OpenPdfFileCheckBox.AutoSize = true;
            this.OpenPdfFileCheckBox.Checked = true;
            this.OpenPdfFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OpenPdfFileCheckBox.Location = new System.Drawing.Point(6, 19);
            this.OpenPdfFileCheckBox.Name = "OpenPdfFileCheckBox";
            this.OpenPdfFileCheckBox.Size = new System.Drawing.Size(201, 17);
            this.OpenPdfFileCheckBox.TabIndex = 21;
            this.OpenPdfFileCheckBox.Text = "Открыть pdf-файл после создания";
            this.OpenPdfFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // UrlsToConvertDataGridView
            // 
            this.UrlsToConvertDataGridView.AllowDrop = true;
            this.UrlsToConvertDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UrlsToConvertDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.UrlsToConvertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UrlsToConvertDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.UrlsToConvertDataGridView.Location = new System.Drawing.Point(6, 19);
            this.UrlsToConvertDataGridView.Name = "UrlsToConvertDataGridView";
            this.UrlsToConvertDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UrlsToConvertDataGridView.Size = new System.Drawing.Size(374, 210);
            this.UrlsToConvertDataGridView.TabIndex = 22;
            this.UrlsToConvertDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.UrlsToConvertDataGridView_DragDrop);
            this.UrlsToConvertDataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.UrlsToConvertDataGridView_DragEnter);
            // 
            // AddRawButton
            // 
            this.AddRawButton.Location = new System.Drawing.Point(386, 19);
            this.AddRawButton.Name = "AddRawButton";
            this.AddRawButton.Size = new System.Drawing.Size(103, 23);
            this.AddRawButton.TabIndex = 25;
            this.AddRawButton.Text = "Добавить строку";
            this.AddRawButton.UseVisualStyleBackColor = true;
            this.AddRawButton.Click += new System.EventHandler(this.AddRawButton_Click);
            // 
            // DeleteRawButton
            // 
            this.DeleteRawButton.Location = new System.Drawing.Point(386, 48);
            this.DeleteRawButton.Name = "DeleteRawButton";
            this.DeleteRawButton.Size = new System.Drawing.Size(103, 23);
            this.DeleteRawButton.TabIndex = 26;
            this.DeleteRawButton.Text = "Удалить строки";
            this.DeleteRawButton.UseVisualStyleBackColor = true;
            this.DeleteRawButton.Click += new System.EventHandler(this.DeleteRawButton_Click);
            // 
            // UrlsListGroupBox
            // 
            this.UrlsListGroupBox.Controls.Add(this.groupBox2);
            this.UrlsListGroupBox.Controls.Add(this.ConvertAllCheckBox);
            this.UrlsListGroupBox.Controls.Add(this.NotOpenSelectedPdfFilesAfterConvertButton);
            this.UrlsListGroupBox.Controls.Add(this.OpenSelectedPdfFilesAfterConvertButton);
            this.UrlsListGroupBox.Controls.Add(this.ConvertUrlsListButton);
            this.UrlsListGroupBox.Controls.Add(this.UrlsToConvertDataGridView);
            this.UrlsListGroupBox.Controls.Add(this.DeleteRawButton);
            this.UrlsListGroupBox.Controls.Add(this.AddRawButton);
            this.UrlsListGroupBox.Location = new System.Drawing.Point(15, 196);
            this.UrlsListGroupBox.Name = "UrlsListGroupBox";
            this.UrlsListGroupBox.Size = new System.Drawing.Size(875, 235);
            this.UrlsListGroupBox.TabIndex = 27;
            this.UrlsListGroupBox.TabStop = false;
            this.UrlsListGroupBox.Text = "Список адресов для конвертирования";
            // 
            // ConvertAllCheckBox
            // 
            this.ConvertAllCheckBox.AutoSize = true;
            this.ConvertAllCheckBox.Checked = true;
            this.ConvertAllCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConvertAllCheckBox.Location = new System.Drawing.Point(400, 183);
            this.ConvertAllCheckBox.Name = "ConvertAllCheckBox";
            this.ConvertAllCheckBox.Size = new System.Drawing.Size(73, 17);
            this.ConvertAllCheckBox.TabIndex = 33;
            this.ConvertAllCheckBox.Text = "Для всех";
            this.ConvertAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // GetTitleFromFileUrlsСheckBox
            // 
            this.GetTitleFromFileUrlsСheckBox.AutoSize = true;
            this.GetTitleFromFileUrlsСheckBox.Checked = true;
            this.GetTitleFromFileUrlsСheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GetTitleFromFileUrlsСheckBox.Location = new System.Drawing.Point(7, 66);
            this.GetTitleFromFileUrlsСheckBox.Name = "GetTitleFromFileUrlsСheckBox";
            this.GetTitleFromFileUrlsСheckBox.Size = new System.Drawing.Size(338, 17);
            this.GetTitleFromFileUrlsСheckBox.TabIndex = 32;
            this.GetTitleFromFileUrlsСheckBox.Text = "Получить имя выходного файла из заголовка страницы (add)";
            this.GetTitleFromFileUrlsСheckBox.UseVisualStyleBackColor = true;
            // 
            // GetTitleFromUrlСheckBox
            // 
            this.GetTitleFromUrlСheckBox.AutoSize = true;
            this.GetTitleFromUrlСheckBox.Location = new System.Drawing.Point(7, 43);
            this.GetTitleFromUrlСheckBox.Name = "GetTitleFromUrlСheckBox";
            this.GetTitleFromUrlСheckBox.Size = new System.Drawing.Size(356, 17);
            this.GetTitleFromUrlСheckBox.TabIndex = 31;
            this.GetTitleFromUrlСheckBox.Text = "Получить имя выходного файла из заголовка страницы (convert)";
            this.GetTitleFromUrlСheckBox.UseVisualStyleBackColor = true;
            // 
            // NotOpenSelectedPdfFilesAfterConvertButton
            // 
            this.NotOpenSelectedPdfFilesAfterConvertButton.Location = new System.Drawing.Point(386, 106);
            this.NotOpenSelectedPdfFilesAfterConvertButton.Name = "NotOpenSelectedPdfFilesAfterConvertButton";
            this.NotOpenSelectedPdfFilesAfterConvertButton.Size = new System.Drawing.Size(103, 23);
            this.NotOpenSelectedPdfFilesAfterConvertButton.TabIndex = 30;
            this.NotOpenSelectedPdfFilesAfterConvertButton.Text = "Не открывать";
            this.NotOpenSelectedPdfFilesAfterConvertButton.UseVisualStyleBackColor = true;
            this.NotOpenSelectedPdfFilesAfterConvertButton.Click += new System.EventHandler(this.NotOpenSelectedPdfFilesAfterConvertButton_Click);
            // 
            // OpenSelectedPdfFilesAfterConvertButton
            // 
            this.OpenSelectedPdfFilesAfterConvertButton.Location = new System.Drawing.Point(386, 77);
            this.OpenSelectedPdfFilesAfterConvertButton.Name = "OpenSelectedPdfFilesAfterConvertButton";
            this.OpenSelectedPdfFilesAfterConvertButton.Size = new System.Drawing.Size(103, 23);
            this.OpenSelectedPdfFilesAfterConvertButton.TabIndex = 29;
            this.OpenSelectedPdfFilesAfterConvertButton.Text = "Открывать";
            this.OpenSelectedPdfFilesAfterConvertButton.UseVisualStyleBackColor = true;
            this.OpenSelectedPdfFilesAfterConvertButton.Click += new System.EventHandler(this.OpenSelectedPdfFilesAfterConvertButton_Click);
            // 
            // ConvertUrlsListButton
            // 
            this.ConvertUrlsListButton.Location = new System.Drawing.Point(386, 206);
            this.ConvertUrlsListButton.Name = "ConvertUrlsListButton";
            this.ConvertUrlsListButton.Size = new System.Drawing.Size(103, 23);
            this.ConvertUrlsListButton.TabIndex = 28;
            this.ConvertUrlsListButton.Text = "Конвертировать";
            this.ConvertUrlsListButton.UseVisualStyleBackColor = true;
            this.ConvertUrlsListButton.Click += new System.EventHandler(this.ConvertUrlsListButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetImmediatelyTitleFromUrlСheckBox);
            this.groupBox1.Controls.Add(this.OpenPdfFileCheckBox);
            this.groupBox1.Controls.Add(this.DefaultOutputPathTextBox);
            this.groupBox1.Controls.Add(this.ConvertImmediatelyButton);
            this.groupBox1.Controls.Add(this.ChangeDefaultOutputPathButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 79);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Мгновенное конвертирование из буфера обмена";
            // 
            // GetImmediatelyTitleFromUrlСheckBox
            // 
            this.GetImmediatelyTitleFromUrlСheckBox.AutoSize = true;
            this.GetImmediatelyTitleFromUrlСheckBox.Checked = true;
            this.GetImmediatelyTitleFromUrlСheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GetImmediatelyTitleFromUrlСheckBox.Location = new System.Drawing.Point(213, 19);
            this.GetImmediatelyTitleFromUrlСheckBox.Name = "GetImmediatelyTitleFromUrlСheckBox";
            this.GetImmediatelyTitleFromUrlСheckBox.Size = new System.Drawing.Size(219, 17);
            this.GetImmediatelyTitleFromUrlСheckBox.TabIndex = 22;
            this.GetImmediatelyTitleFromUrlСheckBox.Text = "Получить имя из заголовка страницы";
            this.GetImmediatelyTitleFromUrlСheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveStatusRichTextBoxButton
            // 
            this.SaveStatusRichTextBoxButton.Location = new System.Drawing.Point(12, 165);
            this.SaveStatusRichTextBoxButton.Name = "SaveStatusRichTextBoxButton";
            this.SaveStatusRichTextBoxButton.Size = new System.Drawing.Size(104, 23);
            this.SaveStatusRichTextBoxButton.TabIndex = 29;
            this.SaveStatusRichTextBoxButton.Text = "Сохранить";
            this.SaveStatusRichTextBoxButton.UseVisualStyleBackColor = true;
            this.SaveStatusRichTextBoxButton.Click += new System.EventHandler(this.SaveStatusRichTextBoxButton_Click);
            // 
            // ClearStatusRichTextBoxButton
            // 
            this.ClearStatusRichTextBoxButton.Location = new System.Drawing.Point(122, 165);
            this.ClearStatusRichTextBoxButton.Name = "ClearStatusRichTextBoxButton";
            this.ClearStatusRichTextBoxButton.Size = new System.Drawing.Size(104, 23);
            this.ClearStatusRichTextBoxButton.TabIndex = 30;
            this.ClearStatusRichTextBoxButton.Text = "Очистить";
            this.ClearStatusRichTextBoxButton.UseVisualStyleBackColor = true;
            this.ClearStatusRichTextBoxButton.Click += new System.EventHandler(this.ClearStatusRichTextBoxButton_Click);
            // 
            // UseOtherProgramToOpenPdfCheckBox
            // 
            this.UseOtherProgramToOpenPdfCheckBox.AutoSize = true;
            this.UseOtherProgramToOpenPdfCheckBox.Enabled = false;
            this.UseOtherProgramToOpenPdfCheckBox.Location = new System.Drawing.Point(15, 522);
            this.UseOtherProgramToOpenPdfCheckBox.Name = "UseOtherProgramToOpenPdfCheckBox";
            this.UseOtherProgramToOpenPdfCheckBox.Size = new System.Drawing.Size(352, 17);
            this.UseOtherProgramToOpenPdfCheckBox.TabIndex = 31;
            this.UseOtherProgramToOpenPdfCheckBox.Text = "Использовать стороннюю программу для открытия pdf-файлов:";
            this.UseOtherProgramToOpenPdfCheckBox.UseVisualStyleBackColor = true;
            this.UseOtherProgramToOpenPdfCheckBox.CheckedChanged += new System.EventHandler(this.UseOtherProgramToOpenPdfCheckBox_CheckedChanged);
            // 
            // OtherProgramToOpenPdfPathTextBox
            // 
            this.OtherProgramToOpenPdfPathTextBox.AllowDrop = true;
            this.OtherProgramToOpenPdfPathTextBox.Location = new System.Drawing.Point(15, 541);
            this.OtherProgramToOpenPdfPathTextBox.Name = "OtherProgramToOpenPdfPathTextBox";
            this.OtherProgramToOpenPdfPathTextBox.ReadOnly = true;
            this.OtherProgramToOpenPdfPathTextBox.Size = new System.Drawing.Size(762, 20);
            this.OtherProgramToOpenPdfPathTextBox.TabIndex = 32;
            this.OtherProgramToOpenPdfPathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.OtherProgramToOpenPdfPathTextBox_DragDrop);
            this.OtherProgramToOpenPdfPathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.OtherProgramToOpenPdfPathTextBox_DragEnter);
            // 
            // ChangeOtherProgramToOpenPdfPathButton
            // 
            this.ChangeOtherProgramToOpenPdfPathButton.Location = new System.Drawing.Point(823, 538);
            this.ChangeOtherProgramToOpenPdfPathButton.Name = "ChangeOtherProgramToOpenPdfPathButton";
            this.ChangeOtherProgramToOpenPdfPathButton.Size = new System.Drawing.Size(70, 23);
            this.ChangeOtherProgramToOpenPdfPathButton.TabIndex = 33;
            this.ChangeOtherProgramToOpenPdfPathButton.Text = "Выбрать";
            this.ChangeOtherProgramToOpenPdfPathButton.UseVisualStyleBackColor = true;
            this.ChangeOtherProgramToOpenPdfPathButton.Click += new System.EventHandler(this.ChangeOtherProgramToOpenPdfPathButton_Click);
            // 
            // ClearOtherProgramToOpenPdfPathButton
            // 
            this.ClearOtherProgramToOpenPdfPathButton.Location = new System.Drawing.Point(783, 538);
            this.ClearOtherProgramToOpenPdfPathButton.Name = "ClearOtherProgramToOpenPdfPathButton";
            this.ClearOtherProgramToOpenPdfPathButton.Size = new System.Drawing.Size(34, 23);
            this.ClearOtherProgramToOpenPdfPathButton.TabIndex = 34;
            this.ClearOtherProgramToOpenPdfPathButton.Text = "X";
            this.ClearOtherProgramToOpenPdfPathButton.UseVisualStyleBackColor = true;
            this.ClearOtherProgramToOpenPdfPathButton.Click += new System.EventHandler(this.ClearOtherProgramToOpenPdfPathButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClearResponseTimeoutTextBoxButton);
            this.groupBox2.Controls.Add(this.ResponseTimeoutTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.AddTitleToHeaderCheckBox);
            this.groupBox2.Controls.Add(this.AddUrlToFooterCheckBox);
            this.groupBox2.Controls.Add(this.NumerateOutputPdfFileNamesCheckBox);
            this.groupBox2.Controls.Add(this.GetTitleFromUrlСheckBox);
            this.groupBox2.Controls.Add(this.GetTitleFromFileUrlsСheckBox);
            this.groupBox2.Location = new System.Drawing.Point(495, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 210);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры конвертирования списка даресов";
            // 
            // NumerateOutputPdfFileNamesCheckBox
            // 
            this.NumerateOutputPdfFileNamesCheckBox.AutoSize = true;
            this.NumerateOutputPdfFileNamesCheckBox.Location = new System.Drawing.Point(7, 20);
            this.NumerateOutputPdfFileNamesCheckBox.Name = "NumerateOutputPdfFileNamesCheckBox";
            this.NumerateOutputPdfFileNamesCheckBox.Size = new System.Drawing.Size(217, 17);
            this.NumerateOutputPdfFileNamesCheckBox.TabIndex = 0;
            this.NumerateOutputPdfFileNamesCheckBox.Text = "Нумеровать имена выходных файлов";
            this.NumerateOutputPdfFileNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddUrlToFooterCheckBox
            // 
            this.AddUrlToFooterCheckBox.AutoSize = true;
            this.AddUrlToFooterCheckBox.Checked = true;
            this.AddUrlToFooterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddUrlToFooterCheckBox.Location = new System.Drawing.Point(6, 164);
            this.AddUrlToFooterCheckBox.Name = "AddUrlToFooterCheckBox";
            this.AddUrlToFooterCheckBox.Size = new System.Drawing.Size(164, 17);
            this.AddUrlToFooterCheckBox.TabIndex = 33;
            this.AddUrlToFooterCheckBox.Text = "Добавить источник в footer";
            this.AddUrlToFooterCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddTitleToHeaderCheckBox
            // 
            this.AddTitleToHeaderCheckBox.AutoSize = true;
            this.AddTitleToHeaderCheckBox.Checked = true;
            this.AddTitleToHeaderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddTitleToHeaderCheckBox.Location = new System.Drawing.Point(6, 187);
            this.AddTitleToHeaderCheckBox.Name = "AddTitleToHeaderCheckBox";
            this.AddTitleToHeaderCheckBox.Size = new System.Drawing.Size(177, 17);
            this.AddTitleToHeaderCheckBox.TabIndex = 34;
            this.AddTitleToHeaderCheckBox.Text = "Добавить заголовок в header";
            this.AddTitleToHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Таймаут при получении заголовка страницы:";
            // 
            // ResponseTimeoutTextBox
            // 
            this.ResponseTimeoutTextBox.Location = new System.Drawing.Point(245, 84);
            this.ResponseTimeoutTextBox.Name = "ResponseTimeoutTextBox";
            this.ResponseTimeoutTextBox.Size = new System.Drawing.Size(83, 20);
            this.ResponseTimeoutTextBox.TabIndex = 36;
            this.ResponseTimeoutTextBox.Text = "15000";
            this.ResponseTimeoutTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ResponseTimeoutTextBox_KeyPress);
            // 
            // ClearResponseTimeoutTextBoxButton
            // 
            this.ClearResponseTimeoutTextBoxButton.Location = new System.Drawing.Point(334, 82);
            this.ClearResponseTimeoutTextBoxButton.Name = "ClearResponseTimeoutTextBoxButton";
            this.ClearResponseTimeoutTextBoxButton.Size = new System.Drawing.Size(34, 23);
            this.ClearResponseTimeoutTextBoxButton.TabIndex = 37;
            this.ClearResponseTimeoutTextBoxButton.Text = "X";
            this.ClearResponseTimeoutTextBoxButton.UseVisualStyleBackColor = true;
            this.ClearResponseTimeoutTextBoxButton.Click += new System.EventHandler(this.ClearResponseTimeoutTextBoxButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 573);
            this.Controls.Add(this.ClearOtherProgramToOpenPdfPathButton);
            this.Controls.Add(this.OtherProgramToOpenPdfPathTextBox);
            this.Controls.Add(this.ChangeOtherProgramToOpenPdfPathButton);
            this.Controls.Add(this.UseOtherProgramToOpenPdfCheckBox);
            this.Controls.Add(this.ClearStatusRichTextBoxButton);
            this.Controls.Add(this.SaveStatusRichTextBoxButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UrlsListGroupBox);
            this.Controls.Add(this.HtmlFromFileCheckBox);
            this.Controls.Add(this.HtmlFileEncodingComboBox);
            this.Controls.Add(this.ChangeHtmlFileButton);
            this.Controls.Add(this.CopyHtmlFromClipboardButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusRichTextBox);
            this.Controls.Add(this.CopyFromClipboardButton);
            this.Controls.Add(this.ClearExeFileButton);
            this.Controls.Add(this.ClearOutputFileButton);
            this.Controls.Add(this.ChangeExeFileButton);
            this.Controls.Add(this.ChangeOutputFileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExeFileTextBox);
            this.Controls.Add(this.OutputFileTextBox);
            this.Controls.Add(this.HtmlPageTextBox);
            this.Controls.Add(this.ConvertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheHtmlToPdfConverter v1.0";
            ((System.ComponentModel.ISupportInitialize)(this.UrlsToConvertDataGridView)).EndInit();
            this.UrlsListGroupBox.ResumeLayout(false);
            this.UrlsListGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.TextBox OutputFileTextBox;
        private System.Windows.Forms.TextBox ExeFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChangeOutputFileButton;
        private System.Windows.Forms.Button ChangeExeFileButton;
        private System.Windows.Forms.Button ClearOutputFileButton;
        private System.Windows.Forms.Button ClearExeFileButton;
        private System.Windows.Forms.Button CopyFromClipboardButton;
        private System.Windows.Forms.RichTextBox StatusRichTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CopyHtmlFromClipboardButton;
        private System.Windows.Forms.Button ChangeHtmlFileButton;
        private System.Windows.Forms.ComboBox HtmlFileEncodingComboBox;
        private System.Windows.Forms.CheckBox HtmlFromFileCheckBox;
        private System.Windows.Forms.TextBox HtmlPageTextBox;
        private System.Windows.Forms.TextBox DefaultOutputPathTextBox;
        private System.Windows.Forms.Button ConvertImmediatelyButton;
        private System.Windows.Forms.Button ChangeDefaultOutputPathButton;
        private System.Windows.Forms.CheckBox OpenPdfFileCheckBox;
        private System.Windows.Forms.DataGridView UrlsToConvertDataGridView;
        private System.Windows.Forms.Button AddRawButton;
        private System.Windows.Forms.Button DeleteRawButton;
        private System.Windows.Forms.GroupBox UrlsListGroupBox;
        private System.Windows.Forms.Button ConvertUrlsListButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveStatusRichTextBoxButton;
        private System.Windows.Forms.Button OpenSelectedPdfFilesAfterConvertButton;
        private System.Windows.Forms.Button NotOpenSelectedPdfFilesAfterConvertButton;
        private System.Windows.Forms.Button ClearStatusRichTextBoxButton;
        private System.Windows.Forms.CheckBox GetTitleFromUrlСheckBox;
        private System.Windows.Forms.CheckBox GetTitleFromFileUrlsСheckBox;
        private System.Windows.Forms.CheckBox ConvertAllCheckBox;
        private System.Windows.Forms.CheckBox GetImmediatelyTitleFromUrlСheckBox;
        private System.Windows.Forms.CheckBox UseOtherProgramToOpenPdfCheckBox;
        private System.Windows.Forms.TextBox OtherProgramToOpenPdfPathTextBox;
        private System.Windows.Forms.Button ChangeOtherProgramToOpenPdfPathButton;
        private System.Windows.Forms.Button ClearOtherProgramToOpenPdfPathButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox NumerateOutputPdfFileNamesCheckBox;
        private System.Windows.Forms.CheckBox AddUrlToFooterCheckBox;
        private System.Windows.Forms.CheckBox AddTitleToHeaderCheckBox;
        private System.Windows.Forms.Button ClearResponseTimeoutTextBoxButton;
        private System.Windows.Forms.TextBox ResponseTimeoutTextBox;
        private System.Windows.Forms.Label label5;
    }
}

