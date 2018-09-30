namespace WhatsappAnalyzer
{
    partial class home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.FileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.FileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.selectBtn = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.SortMethod = new System.Windows.Forms.ComboBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // FileDialogOpen
            // 
            this.FileDialogOpen.FileName = "conversation";
            this.FileDialogOpen.Filter = "Text files (*.txt)|*.txt";
            this.FileDialogOpen.Title = "Select conversation";
            this.FileDialogOpen.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialogOpen_FileOk);
            // 
            // FileDialogSave
            // 
            this.FileDialogSave.FileName = "conversationSumary";
            this.FileDialogSave.Filter = "Excel file (*.xlsx)|*.xlsx";
            this.FileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialogSave_FileOk);
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(12, 12);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(109, 23);
            this.selectBtn.TabIndex = 0;
            this.selectBtn.Text = "Select conversation";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // processBtn
            // 
            this.processBtn.Enabled = false;
            this.processBtn.Location = new System.Drawing.Point(127, 12);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(75, 23);
            this.processBtn.TabIndex = 1;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // SortMethod
            // 
            this.SortMethod.FormattingEnabled = true;
            this.SortMethod.Items.AddRange(new object[] {
            "Amount of messages",
            "By name",
            "Do not sort"});
            this.SortMethod.Location = new System.Drawing.Point(12, 648);
            this.SortMethod.Name = "SortMethod";
            this.SortMethod.Size = new System.Drawing.Size(121, 21);
            this.SortMethod.TabIndex = 4;
            this.SortMethod.Text = "Sort by";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(139, 648);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(209, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(91, 13);
            this.label.TabIndex = 6;
            this.label.Text = "Nothing to display";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(220, 648);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(1032, 23);
            this.progress.TabIndex = 7;
            // 
            // home
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.SortMethod);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.selectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "home";
            this.Opacity = 0.95D;
            this.Text = "Whatsapp analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog FileDialogOpen;
        private System.Windows.Forms.SaveFileDialog FileDialogSave;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.ComboBox SortMethod;
        private System.Windows.Forms.Button saveBtn;
        public System.Windows.Forms.ProgressBar progress;
        public System.Windows.Forms.Label label;
    }
}

