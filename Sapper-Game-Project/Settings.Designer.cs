namespace Sapper
{
    partial class Settings
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
            this.rowsUpDown = new System.Windows.Forms.NumericUpDown();
            this.columsUpDown = new System.Windows.Forms.NumericUpDown();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.columsLabel = new System.Windows.Forms.Label();
            this.minesUpDown = new System.Windows.Forms.NumericUpDown();
            this.minesLabel = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rowsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // rowsUpDown
            // 
            this.rowsUpDown.Location = new System.Drawing.Point(86, 20);
            this.rowsUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.rowsUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.rowsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowsUpDown.Name = "rowsUpDown";
            this.rowsUpDown.Size = new System.Drawing.Size(153, 22);
            this.rowsUpDown.TabIndex = 0;
            this.rowsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // columsUpDown
            // 
            this.columsUpDown.Location = new System.Drawing.Point(86, 52);
            this.columsUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.columsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columsUpDown.Name = "columsUpDown";
            this.columsUpDown.Size = new System.Drawing.Size(153, 22);
            this.columsUpDown.TabIndex = 1;
            this.columsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(17, 22);
            this.rowsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(42, 16);
            this.rowsLabel.TabIndex = 2;
            this.rowsLabel.Text = "Rows";
            // 
            // columsLabel
            // 
            this.columsLabel.AutoSize = true;
            this.columsLabel.Location = new System.Drawing.Point(17, 54);
            this.columsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.columsLabel.Name = "columsLabel";
            this.columsLabel.Size = new System.Drawing.Size(53, 16);
            this.columsLabel.TabIndex = 3;
            this.columsLabel.Text = "Colums";
            // 
            // minesUpDown
            // 
            this.minesUpDown.Location = new System.Drawing.Point(86, 84);
            this.minesUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.minesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minesUpDown.Name = "minesUpDown";
            this.minesUpDown.Size = new System.Drawing.Size(153, 22);
            this.minesUpDown.TabIndex = 1;
            this.minesUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minesLabel
            // 
            this.minesLabel.AutoSize = true;
            this.minesLabel.Location = new System.Drawing.Point(17, 86);
            this.minesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minesLabel.Name = "minesLabel";
            this.minesLabel.Size = new System.Drawing.Size(44, 16);
            this.minesLabel.TabIndex = 3;
            this.minesLabel.Text = "Mines";
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(20, 124);
            this.ok.Margin = new System.Windows.Forms.Padding(4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(219, 28);
            this.ok.TabIndex = 6;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 167);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.minesLabel);
            this.Controls.Add(this.columsLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.minesUpDown);
            this.Controls.Add(this.columsUpDown);
            this.Controls.Add(this.rowsUpDown);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.rowsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown rowsUpDown;
        private System.Windows.Forms.NumericUpDown columsUpDown;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label columsLabel;
        private System.Windows.Forms.NumericUpDown minesUpDown;
        private System.Windows.Forms.Label minesLabel;
        private System.Windows.Forms.Button ok;
    }
}