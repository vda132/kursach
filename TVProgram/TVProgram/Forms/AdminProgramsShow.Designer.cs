
namespace TVProgram.Forms
{
    partial class AdminProgramsShow
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
            this.Filter = new System.Windows.Forms.Button();
            this.ProgramsDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // EndTimeTextBox
            // 
            this.EndTimeTextBox.Location = new System.Drawing.Point(311, 46);
            this.EndTimeTextBox.Name = "EndTimeTextBox";
            this.EndTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.EndTimeTextBox.TabIndex = 31;
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(311, 12);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.StartTimeTextBox.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "чч:мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "чч:мм";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "По:";
            // 
            // RightComboBox
            // 
            this.RightComboBox.FormattingEnabled = true;
            this.RightComboBox.Location = new System.Drawing.Point(71, 46);
            this.RightComboBox.Name = "RightComboBox";
            this.RightComboBox.Size = new System.Drawing.Size(151, 28);
            this.RightComboBox.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "С:";
            // 
            // LeftComboBox
            // 
            this.LeftComboBox.FormattingEnabled = true;
            this.LeftComboBox.Location = new System.Drawing.Point(71, 12);
            this.LeftComboBox.Name = "LeftComboBox";
            this.LeftComboBox.Size = new System.Drawing.Size(151, 28);
            this.LeftComboBox.TabIndex = 24;
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(694, 45);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(94, 29);
            this.Filter.TabIndex = 23;
            this.Filter.Text = "Фильтр";
            this.Filter.UseVisualStyleBackColor = true;
            // 
            // ProgramsDataGrid
            // 
            this.ProgramsDataGrid.AllowUserToAddRows = false;
            this.ProgramsDataGrid.AllowUserToDeleteRows = false;
            this.ProgramsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProgramsDataGrid.Location = new System.Drawing.Point(15, 80);
            this.ProgramsDataGrid.Name = "ProgramsDataGrid";
            this.ProgramsDataGrid.ReadOnly = true;
            this.ProgramsDataGrid.RowHeadersWidth = 51;
            this.ProgramsDataGrid.RowTemplate.Height = 29;
            this.ProgramsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProgramsDataGrid.Size = new System.Drawing.Size(771, 355);
            this.ProgramsDataGrid.TabIndex = 16;
            // 
            // AdminProgramsShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EndTimeTextBox);
            this.Controls.Add(this.StartTimeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RightComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LeftComboBox);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.ProgramsDataGrid);
            this.Name = "AdminProgramsShow";
            this.Text = "AdminProgramsShow";
            ((System.ComponentModel.ISupportInitialize)(this.ProgramsDataGrid)).EndInit();
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
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.DataGridView ProgramsDataGrid;
    }
}