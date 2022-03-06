namespace OOP_Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поЛекторуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поСеместруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поКурсуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поНесколькимКритериямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поКолвуЛекцийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВидуКонтроляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.поЛекторуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.поСеместруToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.поКурсуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поКолвуЛекцийToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.поВидуКонтроляToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(34, 99);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(223, 68);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cornsilk;
            this.button1.Font = new System.Drawing.Font("Rockwell", 11.216F);
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(24, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ввести дисциплину";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Items.AddRange(new object[] {
            "ПОИТ",
            "ИСИТ",
            "ПОИБМС",
            "ДЭВИ"});
            this.listBox3.Location = new System.Drawing.Point(318, 99);
            this.listBox3.Margin = new System.Windows.Forms.Padding(113, 13, 3, 3);
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox3.Size = new System.Drawing.Size(107, 68);
            this.listBox3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 8.8F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(31, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите название дисциплины:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.radioButton1.Location = new System.Drawing.Point(57, 231);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 20);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "зачёт";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.radioButton2.Location = new System.Drawing.Point(57, 258);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 20);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "экзамен";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Rockwell", 8.216F);
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.linkLabel1.Location = new System.Drawing.Point(79, 328);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(91, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Преподаватель:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BeepOnError = true;
            this.maskedTextBox1.Culture = new System.Globalization.CultureInfo("en-ER");
            this.maskedTextBox1.Location = new System.Drawing.Point(70, 369);
            this.maskedTextBox1.Mask = "L.L.LLL????????";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(118, 22);
            this.maskedTextBox1.TabIndex = 9;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 16;
            this.listBox4.Items.AddRange(new object[] {
            "Информационных систем и технологий",
            "Информатики и Веб-дизайна",
            "Программной инженерии",
            "Физики",
            "Инженерной графики",
            "Высшей математики"});
            this.listBox4.Location = new System.Drawing.Point(245, 369);
            this.listBox4.Margin = new System.Windows.Forms.Padding(113, 13, 3, 3);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(287, 100);
            this.listBox4.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Rockwell", 8.216F);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(282, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Кафедра преподавателя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Rockwell", 8.216F);
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(618, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Аудитория:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(621, 369);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(82, 36);
            this.richTextBox2.TabIndex = 13;
            this.richTextBox2.Text = "";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1-ый курс",
            "2-ой курс",
            "3-ий курс",
            "4-ый курс"});
            this.checkedListBox1.Location = new System.Drawing.Point(466, 99);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(114, 89);
            this.checkedListBox1.TabIndex = 14;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(213, 241);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(79, 37);
            this.richTextBox3.TabIndex = 15;
            this.richTextBox3.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Rockwell", 8.4216F);
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(198, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Часов лекций:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Rockwell", 8.36F);
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(365, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Часов лабораторных:";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(401, 241);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(79, 37);
            this.richTextBox4.TabIndex = 18;
            this.richTextBox4.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox1.Location = new System.Drawing.Point(621, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 24);
            this.comboBox1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Rockwell", 8.9F);
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(618, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Выберите семестр:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Cornsilk;
            this.button2.Font = new System.Drawing.Font("Rockwell", 11.216F);
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(443, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 56);
            this.button2.TabIndex = 21;
            this.button2.Text = "Ввести в файл";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Cornsilk;
            this.button3.Font = new System.Drawing.Font("Rockwell", 11.216F);
            this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button3.Location = new System.Drawing.Point(654, 505);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 56);
            this.button3.TabIndex = 22;
            this.button3.Text = "Вывести из файла";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = global::OOP_Lab3.Properties.Resources.a631f27081a367c;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.сортировкаToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 29);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поЛекторуToolStripMenuItem,
            this.поСеместруToolStripMenuItem,
            this.поКурсуToolStripMenuItem,
            this.поНесколькимКритериямToolStripMenuItem});
            this.поискToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // поЛекторуToolStripMenuItem
            // 
            this.поЛекторуToolStripMenuItem.Name = "поЛекторуToolStripMenuItem";
            this.поЛекторуToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.поЛекторуToolStripMenuItem.Text = "по лектору";
            this.поЛекторуToolStripMenuItem.Click += new System.EventHandler(this.поЛекторуToolStripMenuItem_Click);
            // 
            // поСеместруToolStripMenuItem
            // 
            this.поСеместруToolStripMenuItem.Name = "поСеместруToolStripMenuItem";
            this.поСеместруToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.поСеместруToolStripMenuItem.Text = "по семестру";
            this.поСеместруToolStripMenuItem.Click += new System.EventHandler(this.поСеместруToolStripMenuItem_Click);
            // 
            // поКурсуToolStripMenuItem
            // 
            this.поКурсуToolStripMenuItem.Name = "поКурсуToolStripMenuItem";
            this.поКурсуToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.поКурсуToolStripMenuItem.Text = "по курсу";
            this.поКурсуToolStripMenuItem.Click += new System.EventHandler(this.поКурсуToolStripMenuItem_Click);
            // 
            // поНесколькимКритериямToolStripMenuItem
            // 
            this.поНесколькимКритериямToolStripMenuItem.Name = "поНесколькимКритериямToolStripMenuItem";
            this.поНесколькимКритериямToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.поНесколькимКритериямToolStripMenuItem.Text = "по нескольким критериям";
            this.поНесколькимКритериямToolStripMenuItem.Click += new System.EventHandler(this.поНесколькимКритериямToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.сортировкаToolStripMenuItem.BackgroundImage = global::OOP_Lab3.Properties.Resources.a631f27081a367c;
            this.сортировкаToolStripMenuItem.Checked = true;
            this.сортировкаToolStripMenuItem.CheckOnClick = true;
            this.сортировкаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поКолвуЛекцийToolStripMenuItem,
            this.поВидуКонтроляToolStripMenuItem});
            this.сортировкаToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            // 
            // поКолвуЛекцийToolStripMenuItem
            // 
            this.поКолвуЛекцийToolStripMenuItem.Name = "поКолвуЛекцийToolStripMenuItem";
            this.поКолвуЛекцийToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.поКолвуЛекцийToolStripMenuItem.Text = "по кол-ву лекций";
            this.поКолвуЛекцийToolStripMenuItem.Click += new System.EventHandler(this.поКолвуЛекцийToolStripMenuItem_Click);
            // 
            // поВидуКонтроляToolStripMenuItem
            // 
            this.поВидуКонтроляToolStripMenuItem.Name = "поВидуКонтроляToolStripMenuItem";
            this.поВидуКонтроляToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.поВидуКонтроляToolStripMenuItem.Text = "по виду контроля";
            this.поВидуКонтроляToolStripMenuItem.Click += new System.EventHandler(this.поВидуКонтроляToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem1,
            this.сортировкиToolStripMenuItem});
            this.сохранитьToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // поискToolStripMenuItem1
            // 
            this.поискToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поЛекторуToolStripMenuItem1,
            this.поСеместруToolStripMenuItem1,
            this.поКурсуToolStripMenuItem1});
            this.поискToolStripMenuItem1.Name = "поискToolStripMenuItem1";
            this.поискToolStripMenuItem1.Size = new System.Drawing.Size(181, 30);
            this.поискToolStripMenuItem1.Text = "поиск";
            // 
            // поЛекторуToolStripMenuItem1
            // 
            this.поЛекторуToolStripMenuItem1.Name = "поЛекторуToolStripMenuItem1";
            this.поЛекторуToolStripMenuItem1.Size = new System.Drawing.Size(184, 30);
            this.поЛекторуToolStripMenuItem1.Text = "по лектору";
            this.поЛекторуToolStripMenuItem1.Click += new System.EventHandler(this.поЛекторуToolStripMenuItem1_Click);
            // 
            // поСеместруToolStripMenuItem1
            // 
            this.поСеместруToolStripMenuItem1.Name = "поСеместруToolStripMenuItem1";
            this.поСеместруToolStripMenuItem1.Size = new System.Drawing.Size(184, 30);
            this.поСеместруToolStripMenuItem1.Text = "по семестру";
            this.поСеместруToolStripMenuItem1.Click += new System.EventHandler(this.поСеместруToolStripMenuItem1_Click);
            // 
            // поКурсуToolStripMenuItem1
            // 
            this.поКурсуToolStripMenuItem1.Name = "поКурсуToolStripMenuItem1";
            this.поКурсуToolStripMenuItem1.Size = new System.Drawing.Size(184, 30);
            this.поКурсуToolStripMenuItem1.Text = "по курсу";
            this.поКурсуToolStripMenuItem1.Click += new System.EventHandler(this.поКурсуToolStripMenuItem1_Click);
            // 
            // сортировкиToolStripMenuItem
            // 
            this.сортировкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поКолвуЛекцийToolStripMenuItem1,
            this.поВидуКонтроляToolStripMenuItem1});
            this.сортировкиToolStripMenuItem.Name = "сортировкиToolStripMenuItem";
            this.сортировкиToolStripMenuItem.Size = new System.Drawing.Size(181, 30);
            this.сортировкиToolStripMenuItem.Text = "сортировки";
            // 
            // поКолвуЛекцийToolStripMenuItem1
            // 
            this.поКолвуЛекцийToolStripMenuItem1.Name = "поКолвуЛекцийToolStripMenuItem1";
            this.поКолвуЛекцийToolStripMenuItem1.Size = new System.Drawing.Size(224, 30);
            this.поКолвуЛекцийToolStripMenuItem1.Text = "по кол-ву лекций";
            this.поКолвуЛекцийToolStripMenuItem1.Click += new System.EventHandler(this.поКолвуЛекцийToolStripMenuItem1_Click);
            // 
            // поВидуКонтроляToolStripMenuItem1
            // 
            this.поВидуКонтроляToolStripMenuItem1.Name = "поВидуКонтроляToolStripMenuItem1";
            this.поВидуКонтроляToolStripMenuItem1.Size = new System.Drawing.Size(224, 30);
            this.поВидуКонтроляToolStripMenuItem1.Text = "по виду контроля";
            this.поВидуКонтроляToolStripMenuItem1.Click += new System.EventHandler(this.поВидуКонтроляToolStripMenuItem1_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(120, 25);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 29);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 8.216F);
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(98, 25);
            this.toolStripButton1.Text = "Очистить";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 8.416F);
            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(90, 29);
            this.toolStripButton2.Text = "Удалить";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 8.216F);
            this.toolStripButton3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(85, 29);
            this.toolStripButton3.Text = "Вперёд";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 8.216F);
            this.toolStripButton4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(76, 29);
            this.toolStripButton4.Text = "Назад";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(67, 29);
            this.toolStripButton5.Text = "Скрыть";
            this.toolStripButton5.ToolTipText = "Скрыть";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 28);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(137, 21);
            this.toolStripStatusLabel1.Text = "Кол-во объектов: ";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Cornsilk;
            this.button6.Font = new System.Drawing.Font("Rockwell", 11.216F);
            this.button6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button6.Location = new System.Drawing.Point(229, 505);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 56);
            this.button6.TabIndex = 28;
            this.button6.Text = "Вывести на экран";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(62)))), ((int)(((byte)(235)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(710, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 29);
            this.button4.TabIndex = 29;
            this.button4.Text = "Показать";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OOP_Lab3.Properties.Resources.a631f27081a367c;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisciplineRedact";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem поЛекторуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поСеместруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поКурсуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поКолвуЛекцийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВидуКонтроляToolStripMenuItem;
        public System.Windows.Forms.MaskedTextBox maskedTextBox1;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem поЛекторуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem поСеместруToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem поКурсуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сортировкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поКолвуЛекцийToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem поВидуКонтроляToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem поНесколькимКритериямToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.Button button4;
    }
}

