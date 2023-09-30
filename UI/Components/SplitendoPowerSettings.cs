using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;


namespace LiveSplit.UI.Components
{


    public partial class SplitendoPowerSettings : UserControl
    {

        public bool Display2Rows { get; set; }
        public LayoutMode Mode { get; set; }

        public string SPDir { get; set; }

        public SplitendoPowerSettings()
        {
            InitializeComponent();
            Display2Rows = false;
            SPDir = Directory.GetCurrentDirectory();
            textSPDir.Text = SPDir;

          

        }

        //on load
        private void SplitendoPower_Load(object sender, EventArgs e)
        {

            textSPDir.Text = SPDir;


        }


        //when you click the button this happens
        private void updateSPDir(object sender, EventArgs e)
        {
            if (SPDirDialog.ShowDialog() == DialogResult.OK)
            {
                SPDir = SPDirDialog.SelectedPath;
            }

            else
            {
                SPDir = Directory.GetCurrentDirectory();
                textSPDir.Text = "ERROR: No folder selected! Will try to use the LiveSplit directory...";
            }

            textSPDir.Text = SPDir;
        }


        //Saving Loading Settings
        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "SPDir", SPDir);

        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            SPDir = SettingsHelper.ParseString(element["SPDir"]);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void twitterLink(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://twitter.com/SushiKishi");
            Process.Start(sInfo);
        }

        private void cohostLink(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://cohost.org/SushiKishi");
            Process.Start(sInfo);
        }

        private void githubLink(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://twitter.com/SushiKishi");
            Process.Start(sInfo);
        }
    }

   


}
