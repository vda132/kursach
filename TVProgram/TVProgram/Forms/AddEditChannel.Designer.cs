
namespace TVProgram.Forms
{
    partial class AddEditChannel
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
            this.ChannelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(64, 173);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(94, 29);
            this.BackButton.TabIndex = 7;
            this.BackButton.Text = "Вернуться";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddEditButton
            // 
            this.AddEditButton.Location = new System.Drawing.Point(164, 173);
            this.AddEditButton.Name = "AddEditButton";
            this.AddEditButton.Size = new System.Drawing.Size(94, 29);
            this.AddEditButton.TabIndex = 6;
            this.AddEditButton.UseVisualStyleBackColor = true;
            this.AddEditButton.Click += new System.EventHandler(this.AddEditButton_Click);
            // 
            // ChannelTextBox
            // 
            this.ChannelTextBox.Location = new System.Drawing.Point(12, 32);
            this.ChannelTextBox.Name = "ChannelTextBox";
            this.ChannelTextBox.Size = new System.Drawing.Size(246, 27);
            this.ChannelTextBox.TabIndex = 5;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Логин";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(12, 85);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(246, 27);
            this.LoginTextBox.TabIndex = 9;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 138);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(246, 27);
            this.PasswordTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Пароль";
            // 
            // AddEditChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 214);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AddEditButton);
            this.Controls.Add(this.ChannelTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddEditChannel";
            this.Text = "AddEditChannel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button AddEditButton;
        private System.Windows.Forms.TextBox ChannelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label3;
    }
}