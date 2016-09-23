using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RobloxIPFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Made by daymon - twitter.com/disband
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;
            string appDataFolder = Environment.GetEnvironmentVariable("LocalAppData");
            string filePath = Path.Combine(appDataFolder, "Roblox\\logs");
            DirectoryInfo info = new DirectoryInfo(filePath);
            FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
            foreach (FileInfo fil in files)
            {
                if(Convert.ToString(fil).Contains("GameStartScript"))
                {
                    filePath = Path.Combine(filePath, Convert.ToString(fil));
                    break;
                }   
            }
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if(line.Contains("Connecting to"))
                {
                    int index = line.IndexOf("to") + 2;
                    string piece = line.Substring(index);
                    MessageBox.Show(piece);
                }
                counter++;
            }
            file.Close();
        }
    }
}
