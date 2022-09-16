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
using EnvDTE;
using System.Runtime.InteropServices;

namespace RobloxIPFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Made by daymon - twitter.com/disband

        // Fixed by Nick.
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string FilePath = Path.Combine(LocalAppDataPath, "Roblox", "logs");


            DateTime LastedUpdated = DateTime.MinValue;

            DirectoryInfo Info = new DirectoryInfo(FilePath);
            FileInfo[] Files = Info.GetFiles().OrderByDescending(f => f.CreationTime).ToArray();

            string Line;

            var files = new DirectoryInfo(FilePath).GetFiles("*.*");
            string latestfile = " ";
            DateTime lastupdated = DateTime.MinValue;
            int count = 0;
            foreach (FileInfo file in files.Reverse())
            {
                if (file.LastWriteTime > lastupdated)
                {
                    lastupdated = file.LastWriteTime;
                    count++;
                    Console.WriteLine(" LatestFileName : " + file.Name + " " + count);
                    //Console.ReadLine();
                    {
                        latestfile = file.Name;

                        StreamReader FileZ = new StreamReader(new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                        while ((Line = FileZ.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);

                            if (Line.Contains("Connecting to"))
                            {
                                int index = Line.IndexOf("to") + 2;
                                string piece = Line.Substring(index);
                                MessageBox.Show("IP: " + piece + "\n" + "Path: " + file.FullName);
                                return;
                            }
                        }
                    }
                }
            }

        }
    }
}
