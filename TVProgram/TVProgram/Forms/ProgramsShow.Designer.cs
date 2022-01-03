
namespace TVProgram.Forms
{
    partial class ProgramsShow
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
            this.ShowsDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.GenresComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChannelTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowTextBox = new System.Windows.Forms.TextBox();
            this.Filter = new System.Windows.Forms.Button();
            this.LeftComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RightComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.StartTimeTextBox = new System.Windows.Forms.TextBox();
            this.EndTimeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowsDataGrid
            // 
            this.ShowsDataGrid.AllowUserToAddRows = false;
            this.ShowsDataGrid.AllowUserToDeleteRows = false;
            this.ShowsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowsDataGrid.Location = new System.Drawing.Point(17, 120);
            this.ShowsDataGrid.Name = "ShowsDataGrid";
            this.ShowsDataGrid.ReadOnly = true;
            this.ShowsDataGrid.RowHeadersWidth = 51;
            this.ShowsDataGrid.RowTemplate.Height = 29;
            this.ShowsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShowsDataGrid.Size = new System.Drawing.Size(771, 318);
            this.ShowsDataGrid.TabIndex = 0;
            this.ShowsDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.showsDataGrid_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Жанр";
            // 
            // GenresComboBox
            // 
            this.GenresComboBox.FormattingEnabled = true;
            this.GenresComboBox.Location = new System.Drawing.Point(71, 18);
            this.GenresComboBox.Name = "GenresComboBox";
            this.GenresComboBox.Size = new System.Drawing.Size(151, 28);
            this.GenresComboBox.TabIndex = 2;
            this.GenresComboBox.SelectedIndexChanged += new System.EventHandler(this.genresComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Канал";
            // 
            // ChannelTextBox
            // 
            this.ChannelTextBox.Location = new System.Drawing.Point(285, 18);
            this.ChannelTextBox.Name = "ChannelTextBox";
            this.ChannelTextBox.Size = new System.Drawing.Size(125, 27);
            this.ChannelTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Передача";
            // 
            // ShowTextBox
            // 
            this.ShowTextBox.Location = new System.Drawing.Point(499, 18);
            this.ShowTextBox.Name = "ShowTextBox";
            this.ShowTextBox.Size = new System.Drawing.Size(125, 27);
            this.ShowTextBox.TabIndex = 6;
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(694, 85);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(94, 29);
            this.Filter.TabIndex = 7;
            this.Filter.Text = "Фильтр";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // LeftComboBox
            // 
            this.LeftComboBox.FormattingEnabled = true;
            this.LeftComboBox.Location = new System.Drawing.Point(71, 52);
            this.LeftComboBox.Name = "LeftComboBox";
            this.LeftComboBox.Size = new System.Drawing.Size(151, 28);
            this.LeftComboBox.TabIndex = 8;
            this.LeftComboBox.SelectedIndexChanged += new System.EventHandler(this.leftComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "С:";
            // 
            // RightComboBox
            // 
            this.RightComboBox.FormattingEnabled = true;
            this.RightComboBox.Location = new System.Drawing.Point(71, 86);
            this.RightComboBox.Name = "RightComboBox";
            this.RightComboBox.Size = new System.Drawing.Size(151, 28);
            this.RightComboBox.TabIndex = 10;
            this.RightComboBox.SelectedIndexChanged += new System.EventHandler(this.rightComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "По:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "чч:мм";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "чч:мм";
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(284, 52);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.StartTimeTextBox.TabIndex = 14;
            // 
            // EndTimeTextBox
            // 
            this.EndTimeTextBox.Location = new System.Drawing.Point(285, 86);
            this.EndTimeTextBox.Name = "EndTimeTextBox";
            this.EndTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.EndTimeTextBox.TabIndex = 15;
            // 
            // ProgramsShow
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
            this.Controls.Add(this.ShowTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChannelTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GenresComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowsDataGrid);
            this.Name = "ProgramsShow";
            this.Text = "ProgramsShow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgramsShow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ShowsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ShowsDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GenresComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChannelTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ShowTextBox;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.ComboBox LeftComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox RightComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox StartTimeTextBox;
        private System.Windows.Forms.TextBox EndTimeTextBox;
    }
}