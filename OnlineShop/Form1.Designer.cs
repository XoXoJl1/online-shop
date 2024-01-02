namespace OnlineShop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.AccountButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.AdminButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteSizeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddSizeButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AddtoCartButton = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.ItemsButton = new System.Windows.Forms.Button();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.OrdersButton = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.PictureBox();
            this.Cart = new System.Windows.Forms.PictureBox();
            this.CompanyComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avgCompanyPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(13, 40);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(203, 46);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Авторизация";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(1075, 47);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(124, 31);
            this.SearchTextBox.TabIndex = 6;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // AccountButton
            // 
            this.AccountButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AccountButton.FlatAppearance.BorderSize = 0;
            this.AccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.AccountButton.Location = new System.Drawing.Point(12, 40);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Size = new System.Drawing.Size(203, 46);
            this.AccountButton.TabIndex = 8;
            this.AccountButton.Text = "Аккаунт";
            this.AccountButton.UseVisualStyleBackColor = false;
            this.AccountButton.Visible = false;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // AdminButton
            // 
            this.AdminButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AdminButton.FlatAppearance.BorderSize = 0;
            this.AdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdminButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminButton.Location = new System.Drawing.Point(762, 40);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(167, 46);
            this.AdminButton.TabIndex = 9;
            this.AdminButton.Text = "Администрирование";
            this.AdminButton.UseVisualStyleBackColor = false;
            this.AdminButton.Visible = false;
            this.AdminButton.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1238, 346);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 24F);
            this.label1.Location = new System.Drawing.Point(476, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 52);
            this.label1.TabIndex = 11;
            this.label1.Text = "OnlineShop";
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.EditButton.Location = new System.Drawing.Point(12, 470);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(150, 46);
            this.EditButton.TabIndex = 12;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Visible = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteSizeButton
            // 
            this.DeleteSizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteSizeButton.FlatAppearance.BorderSize = 0;
            this.DeleteSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSizeButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSizeButton.Location = new System.Drawing.Point(563, 470);
            this.DeleteSizeButton.Name = "DeleteSizeButton";
            this.DeleteSizeButton.Size = new System.Drawing.Size(150, 46);
            this.DeleteSizeButton.TabIndex = 13;
            this.DeleteSizeButton.Text = "Удалить размер";
            this.DeleteSizeButton.UseVisualStyleBackColor = false;
            this.DeleteSizeButton.Visible = false;
            this.DeleteSizeButton.Click += new System.EventHandler(this.DeleteSizeButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.SaveButton.Location = new System.Drawing.Point(1100, 470);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 46);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddSizeButton
            // 
            this.AddSizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddSizeButton.FlatAppearance.BorderSize = 0;
            this.AddSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSizeButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.AddSizeButton.Location = new System.Drawing.Point(287, 470);
            this.AddSizeButton.Name = "AddSizeButton";
            this.AddSizeButton.Size = new System.Drawing.Size(150, 46);
            this.AddSizeButton.TabIndex = 15;
            this.AddSizeButton.Text = "Добавить размер";
            this.AddSizeButton.UseVisualStyleBackColor = false;
            this.AddSizeButton.Visible = false;
            this.AddSizeButton.Click += new System.EventHandler(this.AddSizeButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.RefreshButton.Location = new System.Drawing.Point(839, 470);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(150, 46);
            this.RefreshButton.TabIndex = 16;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Visible = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.SizeLabel.Location = new System.Drawing.Point(333, 519);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(56, 17);
            this.SizeLabel.TabIndex = 17;
            this.SizeLabel.Text = "Размер";
            this.SizeLabel.Visible = false;
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.SizeTextBox.Location = new System.Drawing.Point(287, 539);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(150, 25);
            this.SizeTextBox.TabIndex = 18;
            this.SizeTextBox.Visible = false;
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.AmountTextBox.Location = new System.Drawing.Point(287, 588);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(150, 25);
            this.AmountTextBox.TabIndex = 19;
            this.AmountTextBox.Visible = false;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.AmountLabel.Location = new System.Drawing.Point(333, 568);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(56, 17);
            this.AmountLabel.TabIndex = 20;
            this.AmountLabel.Text = "Кол-во";
            this.AmountLabel.Visible = false;
            // 
            // AddtoCartButton
            // 
            this.AddtoCartButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddtoCartButton.FlatAppearance.BorderSize = 0;
            this.AddtoCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddtoCartButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.AddtoCartButton.Location = new System.Drawing.Point(536, 470);
            this.AddtoCartButton.Name = "AddtoCartButton";
            this.AddtoCartButton.Size = new System.Drawing.Size(231, 46);
            this.AddtoCartButton.TabIndex = 21;
            this.AddtoCartButton.Text = "Добавить в корзину";
            this.AddtoCartButton.UseVisualStyleBackColor = false;
            this.AddtoCartButton.Visible = false;
            this.AddtoCartButton.Click += new System.EventHandler(this.AddtoCartButton_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTextBox.Location = new System.Drawing.Point(13, 539);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(149, 25);
            this.IDTextBox.TabIndex = 23;
            this.IDTextBox.Visible = false;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.IDLabel.Location = new System.Drawing.Point(41, 519);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(88, 17);
            this.IDLabel.TabIndex = 24;
            this.IDLabel.Text = "Код товара";
            this.IDLabel.Visible = false;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.NameLabel.Location = new System.Drawing.Point(41, 568);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(72, 17);
            this.NameLabel.TabIndex = 25;
            this.NameLabel.Text = "Название";
            this.NameLabel.Visible = false;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.PriceLabel.Location = new System.Drawing.Point(203, 568);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(40, 17);
            this.PriceLabel.TabIndex = 26;
            this.PriceLabel.Text = "Цена";
            this.PriceLabel.Visible = false;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.NameTextBox.Location = new System.Drawing.Point(12, 588);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(150, 25);
            this.NameTextBox.TabIndex = 27;
            this.NameTextBox.Visible = false;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.PriceTextBox.Location = new System.Drawing.Point(168, 588);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(113, 25);
            this.PriceTextBox.TabIndex = 28;
            this.PriceTextBox.Visible = false;
            // 
            // ItemsButton
            // 
            this.ItemsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ItemsButton.FlatAppearance.BorderSize = 0;
            this.ItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemsButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.ItemsButton.Location = new System.Drawing.Point(260, 40);
            this.ItemsButton.Name = "ItemsButton";
            this.ItemsButton.Size = new System.Drawing.Size(177, 46);
            this.ItemsButton.TabIndex = 29;
            this.ItemsButton.Text = "Товары";
            this.ItemsButton.UseVisualStyleBackColor = false;
            this.ItemsButton.Visible = false;
            this.ItemsButton.Click += new System.EventHandler(this.ItemsButton_Click);
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.CompanyLabel.Location = new System.Drawing.Point(183, 519);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(72, 17);
            this.CompanyLabel.TabIndex = 31;
            this.CompanyLabel.Text = "Компания";
            this.CompanyLabel.Visible = false;
            // 
            // OrdersButton
            // 
            this.OrdersButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OrdersButton.FlatAppearance.BorderSize = 0;
            this.OrdersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrdersButton.Font = new System.Drawing.Font("Cascadia Mono", 7.8F);
            this.OrdersButton.Location = new System.Drawing.Point(13, 40);
            this.OrdersButton.Name = "OrdersButton";
            this.OrdersButton.Size = new System.Drawing.Size(203, 46);
            this.OrdersButton.TabIndex = 32;
            this.OrdersButton.Text = "Заказы";
            this.OrdersButton.UseVisualStyleBackColor = false;
            this.OrdersButton.Visible = false;
            this.OrdersButton.Click += new System.EventHandler(this.OrdersButton_Click);
            // 
            // Search
            // 
            this.Search.Image = global::OnlineShop.Properties.Resources.Search;
            this.Search.Location = new System.Drawing.Point(1214, 45);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(36, 33);
            this.Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Search.TabIndex = 4;
            this.Search.TabStop = false;
            // 
            // Cart
            // 
            this.Cart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cart.Image = global::OnlineShop.Properties.Resources.Cart;
            this.Cart.Location = new System.Drawing.Point(969, 40);
            this.Cart.Name = "Cart";
            this.Cart.Size = new System.Drawing.Size(100, 46);
            this.Cart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Cart.TabIndex = 2;
            this.Cart.TabStop = false;
            this.Cart.Visible = false;
            this.Cart.Click += new System.EventHandler(this.Cart_Click);
            // 
            // CompanyComboBox
            // 
            this.CompanyComboBox.Font = new System.Drawing.Font("Cascadia Mono", 8F);
            this.CompanyComboBox.FormattingEnabled = true;
            this.CompanyComboBox.Location = new System.Drawing.Point(168, 539);
            this.CompanyComboBox.Name = "CompanyComboBox";
            this.CompanyComboBox.Size = new System.Drawing.Size(113, 25);
            this.CompanyComboBox.TabIndex = 33;
            this.CompanyComboBox.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 28);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companiesToolStripMenuItem,
            this.sizesToolStripMenuItem,
            this.avgCompanyPriceToolStripMenuItem});
            this.statisticsToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // companiesToolStripMenuItem
            // 
            this.companiesToolStripMenuItem.Name = "companiesToolStripMenuItem";
            this.companiesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.companiesToolStripMenuItem.Text = "Companies";
            this.companiesToolStripMenuItem.Click += new System.EventHandler(this.companiesToolStripMenuItem_Click);
            // 
            // sizesToolStripMenuItem
            // 
            this.sizesToolStripMenuItem.Name = "sizesToolStripMenuItem";
            this.sizesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sizesToolStripMenuItem.Text = "Sizes";
            this.sizesToolStripMenuItem.Click += new System.EventHandler(this.sizesToolStripMenuItem_Click);
            // 
            // avgCompanyPriceToolStripMenuItem
            // 
            this.avgCompanyPriceToolStripMenuItem.Name = "avgCompanyPriceToolStripMenuItem";
            this.avgCompanyPriceToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.avgCompanyPriceToolStripMenuItem.Text = "AvgCompanyPrice";
            this.avgCompanyPriceToolStripMenuItem.Click += new System.EventHandler(this.avgCompanyPriceToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1262, 678);
            this.Controls.Add(this.CompanyComboBox);
            this.Controls.Add(this.OrdersButton);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.ItemsButton);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.AddtoCartButton);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.AddSizeButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteSizeButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AdminButton);
            this.Controls.Add(this.AccountButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Cart);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "OnlineShop";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.PictureBox Cart;
        private System.Windows.Forms.PictureBox Search;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button AccountButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button AdminButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteSizeButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddSizeButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Button AddtoCartButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Button ItemsButton;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Button OrdersButton;
        private System.Windows.Forms.ComboBox CompanyComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avgCompanyPriceToolStripMenuItem;
    }
}

