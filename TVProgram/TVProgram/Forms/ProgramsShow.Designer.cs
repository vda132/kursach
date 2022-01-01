
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
            this.showsDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.genresComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.channelTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowTextBox = new System.Windows.Forms.TextBox();
            this.Filter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showsDataGrid
            // 
            this.showsDataGrid.AllowUserToAddRows = false;
            this.showsDataGrid.AllowUserToDeleteRows = false;
            this.showsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showsDataGrid.Location = new System.Drawing.Point(17, 62);
            this.showsDataGrid.Name = "showsDataGrid";
            this.showsDataGrid.ReadOnly = true;
            this.showsDataGrid.RowHeadersWidth = 51;
            this.showsDataGrid.RowTemplate.Height = 29;
            this.showsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showsDataGrid.Size = new System.Drawing.Size(771, 376);
            this.showsDataGrid.TabIndex = 0;
            this.showsDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.showsDataGrid_CellMouseDoubleClick);
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
            // genresComboBox
            // 
            this.genresComboBox.FormattingEnabled = true;
            this.genresComboBox.Location = new System.Drawing.Point(71, 18);
            this.genresComboBox.Name = "genresComboBox";
            this.genresComboBox.Size = new System.Drawing.Size(151, 28);
            this.genresComboBox.TabIndex = 2;
            this.genresComboBox.SelectedIndexChanged += new System.EventHandler(this.genresComboBox_SelectedIndexChanged);
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
            // channelTextBox
            // 
            this.channelTextBox.Location = new System.Drawing.Point(285, 18);
            this.channelTextBox.Name = "channelTextBox";
            this.channelTextBox.Size = new System.Drawing.Size(125, 27);
            this.channelTextBox.TabIndex = 4;
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
            this.Filter.Location = new System.Drawing.Point(694, 16);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(94, 29);
            this.Filter.TabIndex = 7;
            this.Filter.Text = "Фильтр";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // ProgramsShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.ShowTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.channelTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genresComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showsDataGrid);
            this.Name = "ProgramsShow";
            this.Text = "ProgramsShow";
            ((System.ComponentModel.ISupportInitialize)(this.showsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView showsDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox genresComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox channelTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ShowTextBox;
        private System.Windows.Forms.Button Filter;
    }
}