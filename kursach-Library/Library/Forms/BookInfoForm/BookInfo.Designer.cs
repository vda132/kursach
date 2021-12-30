
namespace Library.Forms.BookInfoForm
{
    partial class BookInfo
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
            this.bookNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.authorsTextBox = new System.Windows.Forms.TextBox();
            this.themeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Location = new System.Drawing.Point(95, 18);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(46, 17);
            this.bookNameLabel.TabIndex = 0;
            this.bookNameLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Авторы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тематика:";
            // 
            // authorsTextBox
            // 
            this.authorsTextBox.Location = new System.Drawing.Point(98, 66);
            this.authorsTextBox.Multiline = true;
            this.authorsTextBox.Name = "authorsTextBox";
            this.authorsTextBox.ReadOnly = true;
            this.authorsTextBox.Size = new System.Drawing.Size(124, 122);
            this.authorsTextBox.TabIndex = 3;
            // 
            // themeTextBox
            // 
            this.themeTextBox.Location = new System.Drawing.Point(98, 212);
            this.themeTextBox.Multiline = true;
            this.themeTextBox.Name = "themeTextBox";
            this.themeTextBox.ReadOnly = true;
            this.themeTextBox.Size = new System.Drawing.Size(124, 122);
            this.themeTextBox.TabIndex = 4;
            // 
            // BookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 376);
            this.Controls.Add(this.themeTextBox);
            this.Controls.Add(this.authorsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bookNameLabel);
            this.Name = "BookInfo";
            this.Text = "BookInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bookNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox authorsTextBox;
        private System.Windows.Forms.TextBox themeTextBox;
    }
}