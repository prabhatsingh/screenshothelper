namespace ScreenshotApp
{
    partial class ScreenshotForm
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
            this.bt_Start = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_TotalScreens = new System.Windows.Forms.Label();
            this.bt_save = new System.Windows.Forms.Button();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.bt_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Start
            // 
            this.bt_Start.BackColor = System.Drawing.Color.LightCyan;
            this.bt_Start.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Start.Location = new System.Drawing.Point(13, 19);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(139, 25);
            this.bt_Start.TabIndex = 0;
            this.bt_Start.Text = "Clear Images";
            this.bt_Start.UseVisualStyleBackColor = false;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(12, 46);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(45, 20);
            this.lbl_status.TabIndex = 1;
            this.lbl_status.Text = "Status";
            // 
            // lbl_TotalScreens
            // 
            this.lbl_TotalScreens.AutoSize = true;
            this.lbl_TotalScreens.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalScreens.Location = new System.Drawing.Point(12, 66);
            this.lbl_TotalScreens.Name = "lbl_TotalScreens";
            this.lbl_TotalScreens.Size = new System.Drawing.Size(113, 20);
            this.lbl_TotalScreens.TabIndex = 2;
            this.lbl_TotalScreens.Text = "Total Screenshots";
            // 
            // bt_save
            // 
            this.bt_save.BackColor = System.Drawing.Color.LightCyan;
            this.bt_save.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.Location = new System.Drawing.Point(328, 19);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 25);
            this.bt_save.TabIndex = 2;
            this.bt_save.Text = "Save";
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // tb_filename
            // 
            this.tb_filename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_filename.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_filename.Location = new System.Drawing.Point(158, 20);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(164, 22);
            this.tb_filename.TabIndex = 1;
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.Transparent;
            this.bt_close.BackgroundImage = global::ScreenshotApp.Properties.Resources.delete;
            this.bt_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_close.FlatAppearance.BorderSize = 0;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Location = new System.Drawing.Point(397, 2);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(15, 15);
            this.bt_close.TabIndex = 3;
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Press F8 to take screenshots";
            // 
            // ScreenshotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(415, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.tb_filename);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.lbl_TotalScreens);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.bt_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenshotForm";
            this.Opacity = 0.7D;
            this.Text = "Screenshot Helper";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenshotForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ScreenshotForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ScreenshotForm_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_TotalScreens;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox tb_filename;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Label label1;
    }
}

