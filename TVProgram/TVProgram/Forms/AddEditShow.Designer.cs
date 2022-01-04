
namespace TVProgram.Forms
{
    partial class AddEditShow
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
            this.BackButton = new System.Windows.Forms.Button();
            this.AddEditButton = new System.Windows.Forms.Button();
            this.ShowTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GenresComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddGenreButton = new System.Windows.Forms.Button();
            this.RemoveGenreButton = new System.Windows.Forms.Button();
            this.ShowGenresComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(64, 180);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(94, 29);
            this.BackButton.TabIndex = 7;
            this.BackButton.Text = "Вернуться";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddEditButton
            // 
            this.AddEditButton.Location = new System.Drawing.Point(164, 180);
            this.AddEditButton.Name = "AddEditButton";
            this.AddEditButton.Size = new System.Drawing.Size(94, 29);
            this.AddEditButton.TabIndex = 6;
            this.AddEditButton.UseVisualStyleBackColor = true;
            this.AddEditButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ShowTextBox
            // 
            this.ShowTextBox.Location = new System.Drawing.Point(12, 32);
            this.ShowTextBox.Name = "ShowTextBox";
            this.ShowTextBox.Size = new System.Drawing.Size(246, 27);
            this.ShowTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название";
            // 
            // GenresComboBox
            // 
            this.GenresComboBox.FormattingEnabled = true;
            this.GenresComboBox.Location = new System.Drawing.Point(12, 92);
            this.GenresComboBox.Name = "GenresComboBox";
            this.GenresComboBox.Size = new System.Drawing.Size(156, 28);
            this.GenresComboBox.TabIndex = 8;
            this.GenresComboBox.SelectedIndexChanged += new System.EventHandler(this.GenresComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Жанры";
            // 
            // AddGenreButton
            // 
            this.AddGenreButton.Location = new System.Drawing.Point(174, 92);
            this.AddGenreButton.Name = "AddGenreButton";
            this.AddGenreButton.Size = new System.Drawing.Size(84, 28);
            this.AddGenreButton.TabIndex = 11;
            this.AddGenreButton.Text = "Добавить";
            this.AddGenreButton.UseVisualStyleBackColor = true;
            this.AddGenreButton.Click += new System.EventHandler(this.AddGenreButton_Click);
            // 
            // RemoveGenreButton
            // 
            this.RemoveGenreButton.Location = new System.Drawing.Point(174, 145);
            this.RemoveGenreButton.Name = "RemoveGenreButton";
            this.RemoveGenreButton.Size = new System.Drawing.Size(84, 29);
            this.RemoveGenreButton.TabIndex = 12;
            this.RemoveGenreButton.Text = "Удалить";
            this.RemoveGenreButton.UseVisualStyleBackColor = true;
            this.RemoveGenreButton.Click += new System.EventHandler(this.RemoveGenreButton_Click);
            // 
            // ShowGenresComboBox
            // 
            this.ShowGenresComboBox.FormattingEnabled = true;
            this.ShowGenresComboBox.Location = new System.Drawing.Point(12, 146);
            this.ShowGenresComboBox.Name = "ShowGenresComboBox";
            this.ShowGenresComboBox.Size = new System.Drawing.Size(156, 28);
            this.ShowGenresComboBox.TabIndex = 13;
            this.ShowGenresComboBox.SelectedIndexChanged += new System.EventHandler(this.ShowGenresComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Жанры данной передачи";
            // 
            // AddEditShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 217);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ShowGenresComboBox);
            this.Controls.Add(this.RemoveGenreButton);
            this.Controls.Add(this.AddGenreButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GenresComboBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AddEditButton);
            this.Controls.Add(this.ShowTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddEditShow";
            this.Text = "AddShow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button AddEditButton;
        private System.Windows.Forms.TextBox ShowTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GenresComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddGenreButton;
        private System.Windows.Forms.Button RemoveGenreButton;
        private System.Windows.Forms.ComboBox ShowGenresComboBox;
        private System.Windows.Forms.Label label3;
    }
}