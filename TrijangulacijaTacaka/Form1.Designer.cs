namespace TrijangulacijaTacaka
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btGenerateNext = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btFileInput = new System.Windows.Forms.Button();
            this.btSaveToFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bt_prost = new System.Windows.Forms.Button();
            this.bt_hull = new System.Windows.Forms.Button();
            this.bt_triangulation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(34, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(728, 346);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // btGenerateNext
            // 
            this.btGenerateNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btGenerateNext.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerateNext.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btGenerateNext.Location = new System.Drawing.Point(28, 12);
            this.btGenerateNext.Name = "btGenerateNext";
            this.btGenerateNext.Size = new System.Drawing.Size(96, 40);
            this.btGenerateNext.TabIndex = 1;
            this.btGenerateNext.Text = "Next";
            this.btGenerateNext.UseVisualStyleBackColor = true;
            this.btGenerateNext.Click += new System.EventHandler(this.btGenerateNext_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btFileInput
            // 
            this.btFileInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btFileInput.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFileInput.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btFileInput.Location = new System.Drawing.Point(578, 12);
            this.btFileInput.Name = "btFileInput";
            this.btFileInput.Size = new System.Drawing.Size(87, 40);
            this.btFileInput.TabIndex = 2;
            this.btFileInput.Text = "File";
            this.btFileInput.UseVisualStyleBackColor = true;
            this.btFileInput.Click += new System.EventHandler(this.btFileInput_Click);
            // 
            // btSaveToFile
            // 
            this.btSaveToFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSaveToFile.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveToFile.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btSaveToFile.Location = new System.Drawing.Point(681, 12);
            this.btSaveToFile.Name = "btSaveToFile";
            this.btSaveToFile.Size = new System.Drawing.Size(81, 40);
            this.btSaveToFile.TabIndex = 3;
            this.btSaveToFile.Text = "Save";
            this.btSaveToFile.UseVisualStyleBackColor = true;
            this.btSaveToFile.Click += new System.EventHandler(this.btSaveToFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bt_prost
            // 
            this.bt_prost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_prost.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_prost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_prost.Location = new System.Drawing.Point(205, 12);
            this.bt_prost.Name = "bt_prost";
            this.bt_prost.Size = new System.Drawing.Size(108, 40);
            this.bt_prost.TabIndex = 5;
            this.bt_prost.Text = "Poligon";
            this.bt_prost.UseVisualStyleBackColor = true;
            // 
            // bt_hull
            // 
            this.bt_hull.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_hull.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_hull.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_hull.Location = new System.Drawing.Point(332, 12);
            this.bt_hull.Name = "bt_hull";
            this.bt_hull.Size = new System.Drawing.Size(96, 40);
            this.bt_hull.TabIndex = 6;
            this.bt_hull.Text = "Hull";
            this.bt_hull.UseVisualStyleBackColor = true;
            // 
            // bt_triangulation
            // 
            this.bt_triangulation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_triangulation.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_triangulation.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_triangulation.Location = new System.Drawing.Point(444, 12);
            this.bt_triangulation.Name = "bt_triangulation";
            this.bt_triangulation.Size = new System.Drawing.Size(114, 40);
            this.bt_triangulation.TabIndex = 7;
            this.bt_triangulation.Text = "Triang";
            this.bt_triangulation.UseVisualStyleBackColor = true;
            this.bt_triangulation.Click += new System.EventHandler(this.bt_triangulation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_triangulation);
            this.Controls.Add(this.bt_hull);
            this.Controls.Add(this.bt_prost);
            this.Controls.Add(this.btSaveToFile);
            this.Controls.Add(this.btFileInput);
            this.Controls.Add(this.btGenerateNext);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btGenerateNext;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btFileInput;
        private System.Windows.Forms.Button btSaveToFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button bt_prost;
        private System.Windows.Forms.Button bt_hull;
        private System.Windows.Forms.Button bt_triangulation;
    }
}

