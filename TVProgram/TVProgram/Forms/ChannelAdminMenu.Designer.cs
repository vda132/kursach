
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
            ((System.ComponentModel.ISupportInitialize)(this.ShowsDataGrid)).BeginInit();
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
            this.ChannelNameLabel.Location = new System.Drawing.Point(11, 127);
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
            // ChannelAdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 517);
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
    }
}