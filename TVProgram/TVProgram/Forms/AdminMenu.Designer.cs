
namespace TVProgram.Forms
{
    partial class AdminMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenreButton = new System.Windows.Forms.Button();
            this.GenreTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RemoveGenreButton = new System.Windows.Forms.Button();
            this.AddGenreButton = new System.Windows.Forms.Button();
            this.GenresDataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChannelButton = new System.Windows.Forms.Button();
            this.ChannelTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RemoveChannelButton = new System.Windows.Forms.Button();
            this.AddChannelButton = new System.Windows.Forms.Button();
            this.ChannelsDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GenresDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GenreButton);
            this.panel1.Controls.Add(this.GenreTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RemoveGenreButton);
            this.panel1.Controls.Add(this.AddGenreButton);
            this.panel1.Controls.Add(this.GenresDataGrid);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 531);
            this.panel1.TabIndex = 0;
            // 
            // GenreButton
            // 
            this.GenreButton.Location = new System.Drawing.Point(225, 17);
            this.GenreButton.Name = "GenreButton";
            this.GenreButton.Size = new System.Drawing.Size(94, 29);
            this.GenreButton.TabIndex = 7;
            this.GenreButton.Text = "Фильтр";
            this.GenreButton.UseVisualStyleBackColor = true;
            this.GenreButton.Click += new System.EventHandler(this.GenreButton_Click);
            // 
            // GenreTextBox
            // 
            this.GenreTextBox.Location = new System.Drawing.Point(94, 18);
            this.GenreTextBox.Name = "GenreTextBox";
            this.GenreTextBox.Size = new System.Drawing.Size(125, 27);
            this.GenreTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Жанр";
            // 
            // RemoveGenreButton
            // 
            this.RemoveGenreButton.Location = new System.Drawing.Point(287, 51);
            this.RemoveGenreButton.Name = "RemoveGenreButton";
            this.RemoveGenreButton.Size = new System.Drawing.Size(94, 29);
            this.RemoveGenreButton.TabIndex = 3;
            this.RemoveGenreButton.Text = "Удалить";
            this.RemoveGenreButton.UseVisualStyleBackColor = true;
            this.RemoveGenreButton.Click += new System.EventHandler(this.RemoveGenreButton_Click);
            // 
            // AddGenreButton
            // 
            this.AddGenreButton.Location = new System.Drawing.Point(187, 51);
            this.AddGenreButton.Name = "AddGenreButton";
            this.AddGenreButton.Size = new System.Drawing.Size(94, 29);
            this.AddGenreButton.TabIndex = 1;
            this.AddGenreButton.Text = "Добавить";
            this.AddGenreButton.UseVisualStyleBackColor = true;
            this.AddGenreButton.Click += new System.EventHandler(this.AddGenreButton_Click);
            // 
            // GenresDataGrid
            // 
            this.GenresDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GenresDataGrid.Location = new System.Drawing.Point(3, 86);
            this.GenresDataGrid.Name = "GenresDataGrid";
            this.GenresDataGrid.RowHeadersWidth = 51;
            this.GenresDataGrid.RowTemplate.Height = 29;
            this.GenresDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GenresDataGrid.Size = new System.Drawing.Size(378, 432);
            this.GenresDataGrid.TabIndex = 0;
            this.GenresDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GenresDataGrid_CellMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ChannelButton);
            this.panel2.Controls.Add(this.ChannelTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.RemoveChannelButton);
            this.panel2.Controls.Add(this.AddChannelButton);
            this.panel2.Controls.Add(this.ChannelsDataGrid);
            this.panel2.Location = new System.Drawing.Point(391, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 531);
            this.panel2.TabIndex = 1;
            // 
            // ChannelButton
            // 
            this.ChannelButton.Location = new System.Drawing.Point(227, 17);
            this.ChannelButton.Name = "ChannelButton";
            this.ChannelButton.Size = new System.Drawing.Size(94, 29);
            this.ChannelButton.TabIndex = 11;
            this.ChannelButton.Text = "Фильтр";
            this.ChannelButton.UseVisualStyleBackColor = true;
            this.ChannelButton.Click += new System.EventHandler(this.ChannelButton_Click);
            // 
            // ChannelTextBox
            // 
            this.ChannelTextBox.Location = new System.Drawing.Point(96, 18);
            this.ChannelTextBox.Name = "ChannelTextBox";
            this.ChannelTextBox.Size = new System.Drawing.Size(125, 27);
            this.ChannelTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Название";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(5, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 37);
            this.label4.TabIndex = 8;
            this.label4.Text = "Канал";
            // 
            // RemoveChannelButton
            // 
            this.RemoveChannelButton.Location = new System.Drawing.Point(287, 51);
            this.RemoveChannelButton.Name = "RemoveChannelButton";
            this.RemoveChannelButton.Size = new System.Drawing.Size(94, 29);
            this.RemoveChannelButton.TabIndex = 6;
            this.RemoveChannelButton.Text = "Удалить";
            this.RemoveChannelButton.UseVisualStyleBackColor = true;
            this.RemoveChannelButton.Click += new System.EventHandler(this.RemoveChannelButton_Click);
            // 
            // AddChannelButton
            // 
            this.AddChannelButton.Location = new System.Drawing.Point(187, 51);
            this.AddChannelButton.Name = "AddChannelButton";
            this.AddChannelButton.Size = new System.Drawing.Size(94, 29);
            this.AddChannelButton.TabIndex = 4;
            this.AddChannelButton.Text = "Добавить";
            this.AddChannelButton.UseVisualStyleBackColor = true;
            this.AddChannelButton.Click += new System.EventHandler(this.AddChannelButton_Click);
            // 
            // ChannelsDataGrid
            // 
            this.ChannelsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChannelsDataGrid.Location = new System.Drawing.Point(3, 86);
            this.ChannelsDataGrid.Name = "ChannelsDataGrid";
            this.ChannelsDataGrid.RowHeadersWidth = 51;
            this.ChannelsDataGrid.RowTemplate.Height = 29;
            this.ChannelsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChannelsDataGrid.Size = new System.Drawing.Size(378, 432);
            this.ChannelsDataGrid.TabIndex = 1;
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 531);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminMenu";
            this.Text = "Меню администратора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminMenu_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GenresDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GenreButton;
        private System.Windows.Forms.TextBox GenreTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveGenreButton;
        private System.Windows.Forms.Button AddGenreButton;
        private System.Windows.Forms.DataGridView GenresDataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ChannelButton;
        private System.Windows.Forms.TextBox ChannelTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RemoveChannelButton;
        private System.Windows.Forms.Button AddChannelButton;
        private System.Windows.Forms.DataGridView ChannelsDataGrid;
    }
}