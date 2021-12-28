
namespace Library.Forms
{
    partial class WorkSpace
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
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.editInfoButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ApplyChanges = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DeleteLibrarianButton = new System.Windows.Forms.Button();
            this.AddLibrarianbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.libLoginTextBox = new System.Windows.Forms.TextBox();
            this.libPasswordTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoginLibrary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordLibrary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(71, 57);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(76, 17);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Мой логин";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(71, 135);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(86, 17);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Мой пароль";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(71, 77);
            this.loginTextBox.Multiline = true;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(130, 27);
            this.loginTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(71, 155);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(130, 27);
            this.passwordTextBox.TabIndex = 5;
            // 
            // editInfoButton
            // 
            this.editInfoButton.Location = new System.Drawing.Point(71, 216);
            this.editInfoButton.Name = "editInfoButton";
            this.editInfoButton.Size = new System.Drawing.Size(130, 30);
            this.editInfoButton.TabIndex = 6;
            this.editInfoButton.Text = "Редактировать";
            this.editInfoButton.UseVisualStyleBackColor = true;
            this.editInfoButton.Click += new System.EventHandler(this.editInfoButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 400);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ApplyChanges);
            this.tabPage1.Controls.Add(this.loginLabel);
            this.tabPage1.Controls.Add(this.passwordLabel);
            this.tabPage1.Controls.Add(this.editInfoButton);
            this.tabPage1.Controls.Add(this.loginTextBox);
            this.tabPage1.Controls.Add(this.passwordTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Мой кабинет";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ApplyChanges
            // 
            this.ApplyChanges.Location = new System.Drawing.Point(71, 266);
            this.ApplyChanges.Name = "ApplyChanges";
            this.ApplyChanges.Size = new System.Drawing.Size(188, 30);
            this.ApplyChanges.TabIndex = 7;
            this.ApplyChanges.Text = "Применить изменения";
            this.ApplyChanges.UseVisualStyleBackColor = true;
            this.ApplyChanges.Click += new System.EventHandler(this.ApplyChanges_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DeleteLibrarianButton);
            this.tabPage2.Controls.Add(this.AddLibrarianbutton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.libLoginTextBox);
            this.tabPage2.Controls.Add(this.libPasswordTextBox);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Библиотекари";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DeleteLibrarianButton
            // 
            this.DeleteLibrarianButton.Location = new System.Drawing.Point(10, 247);
            this.DeleteLibrarianButton.Name = "DeleteLibrarianButton";
            this.DeleteLibrarianButton.Size = new System.Drawing.Size(211, 32);
            this.DeleteLibrarianButton.TabIndex = 14;
            this.DeleteLibrarianButton.Text = "Удалить библиотекаря";
            this.DeleteLibrarianButton.UseVisualStyleBackColor = true;
            this.DeleteLibrarianButton.Click += new System.EventHandler(this.DeleteLibrarianButton_Click);
            // 
            // AddLibrarianbutton
            // 
            this.AddLibrarianbutton.Location = new System.Drawing.Point(10, 192);
            this.AddLibrarianbutton.Name = "AddLibrarianbutton";
            this.AddLibrarianbutton.Size = new System.Drawing.Size(211, 33);
            this.AddLibrarianbutton.TabIndex = 13;
            this.AddLibrarianbutton.Text = "Добавить библиотекаря";
            this.AddLibrarianbutton.UseVisualStyleBackColor = true;
            this.AddLibrarianbutton.Click += new System.EventHandler(this.AddLibrarianbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин библиотекаря";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Пароль библиотекаря";
            // 
            // libLoginTextBox
            // 
            this.libLoginTextBox.Location = new System.Drawing.Point(47, 58);
            this.libLoginTextBox.Multiline = true;
            this.libLoginTextBox.Name = "libLoginTextBox";
            this.libLoginTextBox.Size = new System.Drawing.Size(130, 27);
            this.libLoginTextBox.TabIndex = 11;
            // 
            // libPasswordTextBox
            // 
            this.libPasswordTextBox.Location = new System.Drawing.Point(47, 136);
            this.libPasswordTextBox.Multiline = true;
            this.libPasswordTextBox.Name = "libPasswordTextBox";
            this.libPasswordTextBox.Size = new System.Drawing.Size(130, 27);
            this.libPasswordTextBox.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginLibrary,
            this.PasswordLibrary,
            this.Type});
            this.dataGridView1.Location = new System.Drawing.Point(227, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(491, 341);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // LoginLibrary
            // 
            this.LoginLibrary.HeaderText = "Логин библиотекаря";
            this.LoginLibrary.MinimumWidth = 6;
            this.LoginLibrary.Name = "LoginLibrary";
            this.LoginLibrary.ReadOnly = true;
            this.LoginLibrary.Width = 125;
            // 
            // PasswordLibrary
            // 
            this.PasswordLibrary.HeaderText = "Пароль библиотекаря";
            this.PasswordLibrary.MinimumWidth = 6;
            this.PasswordLibrary.Name = "PasswordLibrary";
            this.PasswordLibrary.ReadOnly = true;
            this.PasswordLibrary.Width = 125;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 125;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(750, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 30);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // WorkSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 460);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "WorkSpace";
            this.Text = "WorkSpace";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button editInfoButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginLibrary;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasswordLibrary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ApplyChanges;
        private System.Windows.Forms.Button AddLibrarianbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox libLoginTextBox;
        private System.Windows.Forms.TextBox libPasswordTextBox;
        private System.Windows.Forms.Button DeleteLibrarianButton;
    }
}