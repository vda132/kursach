
namespace TVProgram.Forms
{
    partial class AddEditProgram
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
            this.EndTimeTextBox = new System.Windows.Forms.TextBox();
            this.StartTimeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RightComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftComboBox = new System.Windows.Forms.ComboBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.AddEditButton = new System.Windows.Forms.Button();
            this.ShowName = new System.Windows.Forms.Label();
            this.ShowsComboBox = new System.Windows.Forms.ComboBox();
            this.ShowLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EndTimeTextBox
            // 
            this.EndTimeTextBox.Location = new System.Drawing.Point(306, 105);
            this.EndTimeTextBox.Name = "EndTimeTextBox";
            this.EndTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.EndTimeTextBox.TabIndex = 42;
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(306, 72);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.StartTimeTextBox.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "чч:мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "чч:мм";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "По:";
            // 
            // RightComboBox
            // 
            this.RightComboBox.FormattingEnabled = true;
            this.RightComboBox.Location = new System.Drawing.Point(66, 105);
            this.RightComboBox.Name = "RightComboBox";
            this.RightComboBox.Size = new System.Drawing.Size(151, 28);
            this.RightComboBox.TabIndex = 37;
            this.RightComboBox.SelectedIndexChanged += new System.EventHandler(this.RightComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "С:";
            // 
            // LeftComboBox
            // 
            this.LeftComboBox.FormattingEnabled = true;
            this.LeftComboBox.Location = new System.Drawing.Point(66, 71);
            this.LeftComboBox.Name = "LeftComboBox";
            this.LeftComboBox.Size = new System.Drawing.Size(151, 28);
            this.LeftComboBox.TabIndex = 35;
            this.LeftComboBox.SelectedIndexChanged += new System.EventHandler(this.LeftComboBox_SelectedIndexChanged);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(237, 138);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(94, 29);
            this.BackButton.TabIndex = 46;
            this.BackButton.Text = "Вернуться";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddEditButton
            // 
            this.AddEditButton.Location = new System.Drawing.Point(337, 138);
            this.AddEditButton.Name = "AddEditButton";
            this.AddEditButton.Size = new System.Drawing.Size(94, 29);
            this.AddEditButton.TabIndex = 45;
            this.AddEditButton.UseVisualStyleBackColor = true;
            this.AddEditButton.Click += new System.EventHandler(this.AddEditButton_Click);
            // 
            // ShowName
            // 
            this.ShowName.AutoSize = true;
            this.ShowName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowName.Location = new System.Drawing.Point(12, 9);
            this.ShowName.Name = "ShowName";
            this.ShowName.Size = new System.Drawing.Size(0, 41);
            this.ShowName.TabIndex = 47;
            // 
            // ShowsComboBox
            // 
            this.ShowsComboBox.FormattingEnabled = true;
            this.ShowsComboBox.Location = new System.Drawing.Point(96, 22);
            this.ShowsComboBox.Name = "ShowsComboBox";
            this.ShowsComboBox.Size = new System.Drawing.Size(151, 28);
            this.ShowsComboBox.TabIndex = 48;
            this.ShowsComboBox.SelectedIndexChanged += new System.EventHandler(this.ShowsComboBox_SelectedIndexChanged);
            // 
            // ShowLabel
            // 
            this.ShowLabel.AutoSize = true;
            this.ShowLabel.Location = new System.Drawing.Point(12, 25);
            this.ShowLabel.Name = "ShowLabel";
            this.ShowLabel.Size = new System.Drawing.Size(77, 20);
            this.ShowLabel.TabIndex = 49;
            this.ShowLabel.Text = "Передача";
            // 
            // AddEditProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 176);
            this.Controls.Add(this.ShowLabel);
            this.Controls.Add(this.ShowsComboBox);
            this.Controls.Add(this.ShowName);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AddEditButton);
            this.Controls.Add(this.EndTimeTextBox);
            this.Controls.Add(this.StartTimeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RightComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LeftComboBox);
            this.Name = "AddEditProgram";
            this.Text = "AddEditProgram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox EndTimeTextBox;
        private System.Windows.Forms.TextBox StartTimeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox RightComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LeftComboBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button AddEditButton;
        private System.Windows.Forms.Label ShowName;
        private System.Windows.Forms.ComboBox ShowsComboBox;
        private System.Windows.Forms.Label ShowLabel;
    }
}