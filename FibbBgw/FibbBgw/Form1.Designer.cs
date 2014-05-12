namespace FibbBgw
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
            this.nInput = new System.Windows.Forms.TextBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.resOutput = new System.Windows.Forms.TextBox();
            this.fibbLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // nInput
            // 
            this.nInput.Location = new System.Drawing.Point(13, 13);
            this.nInput.Name = "nInput";
            this.nInput.Size = new System.Drawing.Size(100, 20);
            this.nInput.TabIndex = 0;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(331, 10);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 1;
            this.calcButton.Text = "oblicz";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 39);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(394, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // resOutput
            // 
            this.resOutput.Location = new System.Drawing.Point(13, 69);
            this.resOutput.Multiline = true;
            this.resOutput.Name = "resOutput";
            this.resOutput.Size = new System.Drawing.Size(393, 88);
            this.resOutput.TabIndex = 3;
            // 
            // fibbLabel
            // 
            this.fibbLabel.AutoSize = true;
            this.fibbLabel.Location = new System.Drawing.Point(13, 164);
            this.fibbLabel.Name = "fibbLabel";
            this.fibbLabel.Size = new System.Drawing.Size(0, 13);
            this.fibbLabel.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 207);
            this.Controls.Add(this.fibbLabel);
            this.Controls.Add(this.resOutput);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.nInput);
            this.Name = "Form1";
            this.Text = "Fibb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nInput;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox resOutput;
        private System.Windows.Forms.Label fibbLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

