namespace LogicTree
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonTextConjunction = new System.Windows.Forms.Button();
            this.buttonTextDisjunction = new System.Windows.Forms.Button();
            this.buttonTextSubjunction = new System.Windows.Forms.Button();
            this.buttonTextNegation = new System.Windows.Forms.Button();
            this.buttonTextBisubjunction = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(13, 395);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(433, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "run tests";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(352, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "add premise";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonTextConjunction
            // 
            this.buttonTextConjunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTextConjunction.Location = new System.Drawing.Point(13, 366);
            this.buttonTextConjunction.Name = "buttonTextConjunction";
            this.buttonTextConjunction.Size = new System.Drawing.Size(26, 23);
            this.buttonTextConjunction.TabIndex = 3;
            this.buttonTextConjunction.Text = "∧";
            this.buttonTextConjunction.UseVisualStyleBackColor = true;
            this.buttonTextConjunction.Click += new System.EventHandler(this.buttonTextConjunction_Click);
            // 
            // buttonTextDisjunction
            // 
            this.buttonTextDisjunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTextDisjunction.Location = new System.Drawing.Point(45, 366);
            this.buttonTextDisjunction.Name = "buttonTextDisjunction";
            this.buttonTextDisjunction.Size = new System.Drawing.Size(26, 23);
            this.buttonTextDisjunction.TabIndex = 4;
            this.buttonTextDisjunction.Text = "∨";
            this.buttonTextDisjunction.UseVisualStyleBackColor = true;
            this.buttonTextDisjunction.Click += new System.EventHandler(this.buttonTextDisjunction_Click);
            // 
            // buttonTextSubjunction
            // 
            this.buttonTextSubjunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTextSubjunction.Location = new System.Drawing.Point(77, 366);
            this.buttonTextSubjunction.Name = "buttonTextSubjunction";
            this.buttonTextSubjunction.Size = new System.Drawing.Size(26, 23);
            this.buttonTextSubjunction.TabIndex = 5;
            this.buttonTextSubjunction.Text = "→";
            this.buttonTextSubjunction.UseVisualStyleBackColor = true;
            this.buttonTextSubjunction.Click += new System.EventHandler(this.buttonTextSubjunction_Click);
            // 
            // buttonTextNegation
            // 
            this.buttonTextNegation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTextNegation.Location = new System.Drawing.Point(109, 366);
            this.buttonTextNegation.Name = "buttonTextNegation";
            this.buttonTextNegation.Size = new System.Drawing.Size(26, 23);
            this.buttonTextNegation.TabIndex = 6;
            this.buttonTextNegation.Text = "¬";
            this.buttonTextNegation.UseVisualStyleBackColor = true;
            this.buttonTextNegation.Click += new System.EventHandler(this.buttonTextNegation_Click);
            // 
            // buttonTextBisubjunction
            // 
            this.buttonTextBisubjunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTextBisubjunction.Location = new System.Drawing.Point(141, 366);
            this.buttonTextBisubjunction.Name = "buttonTextBisubjunction";
            this.buttonTextBisubjunction.Size = new System.Drawing.Size(26, 23);
            this.buttonTextBisubjunction.TabIndex = 7;
            this.buttonTextBisubjunction.Text = "↔";
            this.buttonTextBisubjunction.UseVisualStyleBackColor = true;
            this.buttonTextBisubjunction.Click += new System.EventHandler(this.buttonTextBisubjunction_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 347);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonTextBisubjunction);
            this.Controls.Add(this.buttonTextNegation);
            this.Controls.Add(this.buttonTextSubjunction);
            this.Controls.Add(this.buttonTextDisjunction);
            this.Controls.Add(this.buttonTextConjunction);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonTextConjunction;
        private System.Windows.Forms.Button buttonTextDisjunction;
        private System.Windows.Forms.Button buttonTextSubjunction;
        private System.Windows.Forms.Button buttonTextNegation;
        private System.Windows.Forms.Button buttonTextBisubjunction;
        private System.Windows.Forms.Panel panel1;
    }
}

