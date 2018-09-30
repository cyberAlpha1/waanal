using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WhatsappAnalyzer.procesing;

namespace WhatsappAnalyzer
{
    public partial class home : Form
    {
        private static home form = null;

        private delegate void changeDelegate(int value);

        public static void changeStaticProgressBar(int value)
        {
            if (form != null)
            {
                form.changeProgressBar(value);
            }
        }

        private void changeProgressBar(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new changeDelegate(changeProgressBar), new object[] {value});
                return;
            }

            progress.Value = value;
        }

        public home()
        {
            InitializeComponent();
            form = this;
        }

        private void button1_Click(object sender, EventArgs e) // Select conversation
        {
            FileDialogOpen.ShowDialog();
        }

        private void processBtn_Click(object sender, EventArgs e) // Process conversation
        {
            processBtn.Enabled = false;
            resetEverything();
            process(FileDialogOpen.FileName);
            processBtn.Enabled = true;
            saveBtn.Enabled = true;
        }

        private void saveBtn_Click(object sender, EventArgs e) // Save sumary
        {
            FileDialogSave.ShowDialog();
        }

        private void FileDialogOpen_FileOk(object sender, CancelEventArgs e) // Opened file is valid
        {
            processBtn.Enabled = true;
        }

        private void FileDialogSave_FileOk(object sender, CancelEventArgs e)
        {
            save(FileDialogSave.FileName);
        }
    }
}
