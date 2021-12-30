
namespace Library.Forms.AddingInfoBookForms
{
    partial class AddTheme
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
            this.themesDataGridView = new System.Windows.Forms.DataGridView();
            this.addThemeBookButton = new System.Windows.Forms.Button();
            this.themeSearchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.themesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // themesDataGridView
            // 
            this.themesDataGridView.AllowUserToAddRows = false;
            this.themesDataGridView.AllowUserToDeleteRows = false;
            this.themesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.themesDataGridView.Location = new System.Drawing.Point(29, 92);
            this.themesDataGridView.Name = "themesDataGridView";
            this.themesDataGridView.ReadOnly = true;
            this.themesDataGridView.RowHeadersWidth = 51;
            this.themesDataGridView.RowTemplate.Height = 24;
            this.themesDataGridView.Size = new System.Drawing.Size(273, 299);
            this.themesDataGridView.TabIndex = 0;
            this.themesDataGridView.SelectionChanged += new System.EventHandler(this.themesDataGridView_SelectionChanged);
            // 
            // addThemeBookButton
            // 
            this.addThemeBookButton.Location = new System.Drawing.Point(180, 408);
            this.addThemeBookButton.Name = "addThemeBookButton";
            this.addThemeBookButton.Size = new System.Drawing.Size(122, 31);
            this.addThemeBookButton.TabIndex = 1;
            this.addThemeBookButton.Text = "Добавить";
            this.addThemeBookButton.UseVisualStyleBackColor = true;
            this.addThemeBookButton.Click += new System.EventHandler(this.addThemeBookButton_Click);
            // 
            // themeSearchTextBox
            // 
            this.themeSearchTextBox.Location = new System.Drawing.Point(29, 57);
            this.themeSearchTextBox.Multiline = true;
            this.themeSearchTextBox.Name = "themeSearchTextBox";
            this.themeSearchTextBox.Size = new System.Drawing.Size(140, 29);
            this.themeSearchTextBox.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(180, 57);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(86, 29);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите тему";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(29, 408);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(104, 31);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Сбросить";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // AddTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 447);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.themeSearchTextBox);
            this.Controls.Add(this.addThemeBookButton);
            this.Controls.Add(this.themesDataGridView);
            this.Name = "AddTheme";
            this.Text = "AddTheme";
            ((System.ComponentModel.ISupportInitialize)(this.themesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView themesDataGridView;
        private System.Windows.Forms.Button addThemeBookButton;
        private System.Windows.Forms.TextBox themeSearchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
    }
}