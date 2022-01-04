
namespace TVProgram.Forms
{
    partial class Registration
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
            this.submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordConfirmTextBox = new System.Windows.Forms.TextBox();
            this.backToPreviousFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(78, 243);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(114, 29);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Подтвердить";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Подтвердите пароль";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(12, 64);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(251, 27);
            this.loginTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(12, 129);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(251, 27);
            this.passwordTextBox.TabIndex = 5;
            // 
            // passwordConfirmTextBox
            // 
            this.passwordConfirmTextBox.Location = new System.Drawing.Point(12, 194);
            this.passwordConfirmTextBox.Name = "passwordConfirmTextBox";
            this.passwordConfirmTextBox.PasswordChar = '*';
            this.passwordConfirmTextBox.Size = new System.Drawing.Size(251, 27);
            this.passwordConfirmTextBox.TabIndex = 6;
            // 
            // backToPreviousFormButton
            // 
            this.backToPreviousFormButton.Location = new System.Drawing.Point(78, 281);
            this.backToPreviousFormButton.Name = "backToPreviousFormButton";
            this.backToPreviousFormButton.Size = new System.Drawing.Size(114, 29);
            this.backToPreviousFormButton.TabIndex = 7;
            this.backToPreviousFormButton.Text = "Вернуться";
            this.backToPreviousFormButton.UseVisualStyleBackColor = true;
            this.backToPreviousFormButton.Click += new System.EventHandler(this.backToPreviousFormButton_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 322);
            this.Controls.Add(this.backToPreviousFormButton);
            this.Controls.Add(this.passwordConfirmTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitButton);
            this.Name = "Registration";
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registration_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox passwordConfirmTextBox;
        private System.Windows.Forms.Button backToPreviousFormButton;
    }
}