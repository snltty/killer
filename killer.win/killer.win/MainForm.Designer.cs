namespace killer.win
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbPid = new TextBox();
            label1 = new Label();
            btnKill = new Button();
            SuspendLayout();
            // 
            // tbPid
            // 
            tbPid.Location = new Point(164, 58);
            tbPid.Name = "tbPid";
            tbPid.Size = new Size(215, 38);
            tbPid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 63);
            label1.Name = "label1";
            label1.Size = new Size(54, 31);
            label1.TabIndex = 1;
            label1.Text = "PID";
            // 
            // btnKill
            // 
            btnKill.Location = new Point(173, 122);
            btnKill.Name = "btnKill";
            btnKill.Size = new Size(150, 58);
            btnKill.TabIndex = 2;
            btnKill.Text = "干它";
            btnKill.UseVisualStyleBackColor = true;
            btnKill.Click += OnKillerClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 229);
            Controls.Add(btnKill);
            Controls.Add(label1);
            Controls.Add(tbPid);
            Name = "MainForm";
            Text = "杀手";
            FormClosing += Closing;
            Load += OnLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbPid;
        private Label label1;
        private Button btnKill;
    }
}
