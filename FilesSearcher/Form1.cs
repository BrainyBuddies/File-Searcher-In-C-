
using System.IO;
using System;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FilesSearcher
{
    
    public partial class Form1 : Form
    {
        string DiskSelectedByUser = string.Empty;
        int check = 0;
        
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.BackColor = Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            Text_Searching.BackColor = System.Drawing.Color.Transparent;    
            label2.Text = "Select Path:     No Paths Selected. ";
            Text_Searching.Hide();
            progressBar1.Hide();
            pictureBox1.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            {
                progressBar1.Value = 0;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Something to search...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                {
                    label3.Hide();
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    string startPath = (folderBrowserDialog1.SelectedPath);
                    folderBrowserDialog1.ShowNewFolderButton = true;
                    folderBrowserDialog1.AutoUpgradeEnabled = false;
                    Text_Searching.Show();
                    pictureBox1.Show();
                    Thread.Sleep(1000);
                    progressBar1.Value = 10;
                    folderBrowserDialog1.ShowDialog();
                    string[] oDirectories = Directory.GetFiles(@folderBrowserDialog1.SelectedPath.ToString(), textBox1.Text, SearchOption.AllDirectories);
                    if (Directory.Exists(textBox1.Text))
                    {
                        Files_Found.Items.Add("----------------------------Start------------------------------");
                        Files_Found.Items.Add(Directory.GetFiles(@folderBrowserDialog1.SelectedPath.ToString(), textBox1.Text, SearchOption.AllDirectories));
                        Files_Found.Items.Add(Directory.GetDirectories(@folderBrowserDialog1.SelectedPath.ToString(), textBox1.Text, SearchOption.AllDirectories));

                    }
                    progressBar1.Show();
                    label2.Text = "Selected Path: " + folderBrowserDialog1.SelectedPath;

                    progressBar1.Value = 5;
                    Thread.Sleep(1000);
                    progressBar1.Value = 10;
                    Thread.Sleep(1000);
                    progressBar1.Value = 15;

                    Files_Found.Items.Add("Results: " + oDirectories.Length.ToString());
                    foreach (string oCurrent in oDirectories)
                        Files_Found.Items.Add(oCurrent);
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    progressBar1.Value = 30;
                    Thread.Sleep(1000);
                    progressBar1.Value = 56;

                    progressBar1.Value = 70;

                    Thread.Sleep(3000);
                    progressBar1.Value = 80;
                    Thread.Sleep(2000);
                    progressBar1.Value = 95;
                    Thread.Sleep(1000);
                    progressBar1.Value = 100;
                    Thread.Sleep(1000);



                    Text_Searching.Hide();
                    pictureBox1.Hide();
                    Files_Found.Show();
                    Files_Found.Items.Add("----------------------------END------------------------------");
                    progressBar1.Value = 0;
                    if (oDirectories.Length == 0)
                    {
                        MessageBox.Show("No Items Found In The Name: " + textBox1.Text + " in " + folderBrowserDialog1.SelectedPath.ToString(), "Nothing Found....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {


                Files_Found.Items.Add("----------------------------Start------------------------------");
                

                    File.WriteAllText(saveFileDialog1.FileName, Files_Found.Items.ToString());
                    FileStream f = new FileStream(saveFileDialog1.FileName, FileMode.Append);
                   StreamWriter s = new StreamWriter(f);

                    s.WriteLine("ERROR CF30938: Could not create host parent directory path.");
                s.WriteLine("ERROR CF5645: Could not add appends to the text file...");
                s.WriteLine(Files_Found.Items.ToString());
                s.Close();
                    f.Close();              
                    

                
            }
    }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           
            Thread.Sleep(2000);
            DriveInfo[] ListDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in ListDrives)
            {
                if (drive.IsReady)
                {
                    
                }
            }

        }



        private void button4_Click(object sender, EventArgs e)
        {
            label3.Hide();
            Files_Found.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
                        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.AutoUpgradeEnabled = false;
            string Path = folderBrowserDialog1.SelectedPath;
            label2.Text = "Selected Path:  "+Path;
            folderBrowserDialog1.ShowDialog();
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}