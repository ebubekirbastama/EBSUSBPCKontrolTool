using System;
using System.IO;
using System.Windows.Forms;

namespace EBSUSBPCKontrolTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool src_takildi = false;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                DriveInfo[] suruculer = DriveInfo.GetDrives();

                foreach (DriveInfo surucu in suruculer)
                {
                    System.Threading.Thread.Sleep(200);
                    if (surucu.IsReady)
                    {
                        if (surucu.VolumeLabel == "")
                        {
                            goto git;
                        }
                        if (surucu.VolumeLabel != "OS")
                        {
                            richTextBox1.AppendText( DateTime.Now.ToString("hh:mm:ss") + " : " + surucu.Name + " : " + surucu.DriveType + " : " + surucu.DriveFormat + " : " + surucu.VolumeLabel + "\r");
                        }


                    }
                git:;
                }
            }
            base.WndProc(ref m);
        }
    }
}
