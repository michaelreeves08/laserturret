using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;
using SwearingIsFun.Library;

namespace SwearingIsFun
{
    public partial class MainForm : Form
    {
        private readonly CloudInterface cloud;

        public MainForm()
        {
            InitializeComponent();
            cloud = new CloudInterface();
        }

        public void PostToForm(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(PostToForm));
                return;
            }
            else
                trancriptBox.AppendText(text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cloud.GetTranscript("test.flac", PostToForm);
        }
    }
}
