
namespace TVProgram.Forms
{
    partial class ChannelAdminMenu
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
            this.ShowButton = new System.Windows.Forms.Button();
            this.ShowTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChannelNameLabel = new System.Windows.Forms.Label();
            this.RemoveShowButton = new System.Windows.Forms.Button();
            this.AddShowButton = new System.Windows.Forms.Button();
            this.ShowsDataGrid = new System.Windows.Forms.DataGridView();
            this.GenresComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EndTimeTextBox = new System.Windows.Forms.TextBox();
            this.StartTimeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RightComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProgramsDataGrid = new System.Windows.Forms.DataGridView();
            this.RemoveProgram = new System.Windows.Forms.Button();
            this.AddProgram = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.Button();
            this.GenresProgramsComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.UpdateData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShowsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(228, 49);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(94, 29);
            this.ShowButton.TabIndex = 14;
            this.ShowButton.Text = "Фильтр";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // ShowTextBox
            // 
            this.ShowTextBox.Location = new System.Drawing.Point(97, 50);
            this.ShowTextBox.Name = "ShowTextBox";
            this.ShowTextBox.Size = new System.Drawing.Size(125, 27);
            this.ShowTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Название";
            // 
            // ChannelNameLabel
            // 
            this.ChannelNameLabel.AutoSize = true;
            this.ChannelNameLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChannelNameLabel.Location = new System.Drawing.Point(11, 87);
            this.ChannelNameLabel.Name = "ChannelNameLabel";
            this.ChannelNameLabel.Size = new System.Drawing.Size(0, 37);
            this.ChannelNameLabel.TabIndex = 11;
            // 
            // RemoveShowButton
            // 
            this.RemoveShowButton.Location = new System.Drawing.Point(328, 99);
            this.RemoveShowButton.Name = "RemoveShowButton";
            this.RemoveShowButton.Size = new System.Drawing.Size(94, 29);
            this.RemoveShowButton.TabIndex = 10;
            this.RemoveShowButton.Text = "Удалить";
            this.RemoveShowButton.UseVisualStyleBackColor = true;
            this.RemoveShowButton.Click += new System.EventHandler(this.RemoveShowButton_Click);
            // 
            // AddShowButton
            // 
            this.AddShowButton.Location = new System.Drawing.Point(228, 99);
            this.AddShowButton.Name = "AddShowButton";
            this.AddShowButton.Size = new System.Drawing.Size(94, 29);
            this.AddShowButton.TabIndex = 9;
            this.AddShowButton.Text = "Добавить";
            this.AddShowButton.UseVisualStyleBackColor = true;
            this.AddShowButton.Click += new System.EventHandler(this.AddShowButton_Click);
            // 
            // ShowsDataGrid
            // 
            this.ShowsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowsDataGrid.Location = new System.Drawing.Point(12, 134);
            this.ShowsDataGrid.Name = "ShowsDataGrid";
            this.ShowsDataGrid.RowHeadersWidth = 51;
            this.ShowsDataGrid.RowTemplate.Height = 29;
            this.ShowsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShowsDataGrid.Size = new System.Drawing.Size(410, 373);
            this.ShowsDataGrid.TabIndex = 8;
            this.ShowsDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ShowsDataGrid_CellMouseDoubleClick);
            // 
            // GenresComboBox
            // 
            this.GenresComboBox.FormattingEnabled = true;
            this.GenresComboBox.Location = new System.Drawing.Point(68, 12);
            this.GenresComboBox.Name = "GenresComboBox";
            this.GenresComboBox.Size = new System.Drawing.Size(151, 28);
            this.GenresComboBox.TabIndex = 16;
            this.GenresComboBox.SelectedIndexChanged += new System.EventHandler(this.GenresComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Жанр";
            // 
            // EndTimeTextBox
            // 
            this.EndTimeTextBox.Location = new System.Drawing.Point(722, 80);
            this.EndTimeTextBox.Name = "EndTimeTextBox";
            this.EndTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.EndTimeTextBox.TabIndex = 28;
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(722, 47);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.StartTimeTextBox.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "чч:мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(639, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "чч:мм";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "По:";
            // 
            // RightComboBox
            // 
            this.RightComboBox.FormattingEnabled = true;
            this.RightComboBox.Location = new System.Drawing.Point(482, 80);
            this.RightComboBox.Name = "RightComboBox";
            this.RightComboBox.Size = new System.Drawing.Size(151, 28);
            this.RightComboBox.TabIndex = 23;
            this.RightComboBox.SelectedIndexChanged += new System.EventHandler(this.RightComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "С:";
            // 
            // LeftComboBox
            // 
            this.LeftComboBox.FormattingEnabled = true;
            this.LeftComboBox.Location = new System.Drawing.Point(482, 46);
            this.LeftComboBox.Name = "LeftComboBox";
            this.LeftComboBox.Size = new System.Drawing.Size(151, 28);
            this.LeftComboBox.TabIndex = 21;
            this.LeftComboBox.SelectedIndexChanged += new System.EventHandler(this.LeftComboBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(722, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Передача";
            // 
            // ProgramsDataGrid
            // 
            this.ProgramsDataGrid.AllowUserToAddRows = false;
            this.ProgramsDataGrid.AllowUserToDeleteRows = false;
            this.ProgramsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProgramsDataGrid.Location = new System.Drawing.Point(428, 134);
            this.ProgramsDataGrid.Name = "ProgramsDataGrid";
            this.ProgramsDataGrid.ReadOnly = true;
            this.ProgramsDataGrid.RowHeadersWidth = 51;
            this.ProgramsDataGrid.RowTemplate.Height = 29;
            this.ProgramsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProgramsDataGrid.Size = new System.Drawing.Size(771, 373);
            this.ProgramsDataGrid.TabIndex = 17;
            this.ProgramsDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProgramsDataGrid_CellMouseDoubleClick);
            // 
            // RemoveProgram
            // 
            this.RemoveProgram.Location = new System.Drawing.Point(1005, 99);
            this.RemoveProgram.Name = "RemoveProgram";
            this.RemoveProgram.Size = new System.Drawing.Size(94, 29);
            this.RemoveProgram.TabIndex = 30;
            this.RemoveProgram.Text = "Удалить";
            this.RemoveProgram.UseVisualStyleBackColor = true;
            this.RemoveProgram.Click += new System.EventHandler(this.RemoveProgram_Click);
            // 
            // AddProgram
            // 
            this.AddProgram.Location = new System.Drawing.Point(905, 99);
            this.AddProgram.Name = "AddProgram";
            this.AddProgram.Size = new System.Drawing.Size(94, 29);
            this.AddProgram.TabIndex = 29;
            this.AddProgram.Text = "Добавить";
            this.AddProgram.UseVisualStyleBackColor = true;
            this.AddProgram.Click += new System.EventHandler(this.AddProgram_Click);
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(1105, 99);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(94, 29);
            this.Filter.TabIndex = 20;
            this.Filter.Text = "Фильтр";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // GenresProgramsComboBox
            // 
            this.GenresProgramsComboBox.FormattingEnabled = true;
            this.GenresProgramsComboBox.Location = new System.Drawing.Point(482, 12);
            this.GenresProgramsComboBox.Name = "GenresProgramsComboBox";
            this.GenresProgramsComboBox.Size = new System.Drawing.Size(151, 28);
            this.GenresProgramsComboBox.TabIndex = 32;
            this.GenresProgramsComboBox.SelectedIndexChanged += new System.EventHandler(this.GenresProgramsComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Жанр";
            // 
            // UpdateData
            // 
            this.UpdateData.Location = new System.Drawing.Point(1105, 6);
            this.UpdateData.Name = "UpdateData";
            this.UpdateData.Size = new System.Drawing.Size(94, 29);
            this.UpdateData.TabIndex = 33;
            this.UpdateData.Text = "Обновить";
            this.UpdateData.UseVisualStyleBackColor = true;
            this.UpdateData.Click += new System.EventHandler(this.UpdateData_Click);
            // 
            // ChannelAdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 517);
            this.Controls.Add(this.UpdateData);
            this.Controls.Add(this.GenresProgramsComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RemoveProgram);
            this.Controls.Add(this.AddProgram);
            this.Controls.Add(this.EndTimeTextBox);
            this.Controls.Add(this.StartTimeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RightComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LeftComboBox);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProgramsDataGrid);
            this.Controls.Add(this.GenresComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.ShowTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChannelNameLabel);
            this.Controls.Add(this.RemoveShowButton);
            this.Controls.Add(this.AddShowButton);
            this.Controls.Add(this.ShowsDataGrid);
            this.Name = "ChannelAdminMenu";
            this.Text = "ChannelAdminMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChannelAdminMenu_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ShowsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.TextBox ShowTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ChannelNameLabel;
        private System.Windows.Forms.Button RemoveShowButton;
        private System.Windows.Forms.Button AddShowButton;
        private System.Windows.Forms.DataGridView ShowsDataGrid;
        private System.Windows.Forms.ComboBox GenresComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EndTimeTextBox;
        private System.Windows.Forms.TextBox StartTimeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox RightComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LeftComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ProgramsDataGrid;
        private System.Windows.Forms.Button RemoveProgram;
        private System.Windows.Forms.Button AddProgram;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.ComboBox GenresProgramsComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button UpdateData;
    }
}