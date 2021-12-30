
namespace Library.Forms.AddingInfoBookForms
{
    partial class AddAuthor
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.authorSearchTextBox = new System.Windows.Forms.TextBox();
            this.addAuthorBookButton = new System.Windows.Forms.Button();
            this.authorsDataGridView = new System.Windows.Forms.DataGridView();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.authorsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Введите ФИО автора";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(180, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(86, 29);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // authorSearchTextBox
            // 
            this.authorSearchTextBox.Location = new System.Drawing.Point(29, 43);
            this.authorSearchTextBox.Multiline = true;
            this.authorSearchTextBox.Name = "authorSearchTextBox";
            this.authorSearchTextBox.Size = new System.Drawing.Size(140, 29);
            this.authorSearchTextBox.TabIndex = 7;
            // 
            // addAuthorBookButton
            // 
            this.addAuthorBookButton.Location = new System.Drawing.Point(180, 394);
            this.addAuthorBookButton.Name = "addAuthorBookButton";
            this.addAuthorBookButton.Size = new System.Drawing.Size(122, 31);
            this.addAuthorBookButton.TabIndex = 6;
            this.addAuthorBookButton.Text = "Добавить";
            this.addAuthorBookButton.UseVisualStyleBackColor = true;
            this.addAuthorBookButton.Click += new System.EventHandler(this.addAuthorBookButton_Click);
            // 
            // authorsDataGridView
            // 
            this.authorsDataGridView.AllowUserToAddRows = false;
            this.authorsDataGridView.AllowUserToDeleteRows = false;
            this.authorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.authorsDataGridView.Location = new System.Drawing.Point(29, 78);
            this.authorsDataGridView.Name = "authorsDataGridView";
            this.authorsDataGridView.ReadOnly = true;
            this.authorsDataGridView.RowHeadersWidth = 51;
            this.authorsDataGridView.RowTemplate.Height = 24;
            this.authorsDataGridView.Size = new System.Drawing.Size(273, 299);
            this.authorsDataGridView.TabIndex = 5;
            this.authorsDataGridView.SelectionChanged += new System.EventHandler(this.authorsDataGridView_SelectionChanged);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(29, 394);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(104, 31);
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "Сбросить";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // AddAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 450);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.authorSearchTextBox);
            this.Controls.Add(this.addAuthorBookButton);
            this.Controls.Add(this.authorsDataGridView);
            this.Name = "AddAuthor";
            this.Text = "AddAuthor";
            ((System.ComponentModel.ISupportInitialize)(this.authorsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox authorSearchTextBox;
        private System.Windows.Forms.Button addAuthorBookButton;
        private System.Windows.Forms.DataGridView authorsDataGridView;
        private System.Windows.Forms.Button resetButton;
    }
}