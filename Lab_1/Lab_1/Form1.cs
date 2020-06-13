using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        DirectoryInfo parent_dir = new DirectoryInfo(dirName);
        DirectoryInfo root_path; 
        Regex file_name;                
        BackgroundWorker bw;
        static string dirName = "\\\\?\\" + Directory.GetCurrentDirectory() + "_T_T_T";

        public Form1()
        {
            InitializeComponent();
            Creating_Deliting_Folders();
        }

        private void ChooseFolder(object sender, EventArgs e)
        {
            choose_folder.ShowDialog();
            choose_folder_field.Text = choose_folder.SelectedPath.ToString();
        }

        private void search_file_field_TextChanged(object sender, EventArgs e)
        {
            if (search_file_field.Text != null && search_file_field.Text != ".txt" && choose_folder_field.Text.Length > 0)
            {
                search_button.Visible = true;
            }
            else
            {
                search_button.Visible = false;
            }

            files_list.Enabled = false;
            open_file_button.Visible = false;
        }

        private void choose_folder_field_TextChanged(object sender, EventArgs e)
        {
            if (search_file_field.Text != null && search_file_field.Text != ".txt" && choose_folder_field.Text.Length > 0)
            {
                search_button.Visible = true;
            }
            else
            {
                search_button.Visible = false;
            }

            files_list.Enabled = false;
            open_file_button.Visible = false;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            root_path = new DirectoryInfo(choose_folder_field.Text);
            file_name = new Regex(search_file_field.Text);

            files_list.Items.Clear();


            bw = new BackgroundWorker();
            bw.DoWork += (obj, ea) => Search_RootFolder(root_path, file_name);
            bw.RunWorkerAsync();

            MessageBox.Show("Searching...");

            bw.Dispose();
            files_list.Enabled = true;
        }

        private void files_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (files_list.SelectedItem != null)
            {
                open_file_button.Visible = true;
            }
            else
            {
                open_file_button.Visible = false;
            }
        }

        private void open_file_button_Click(object sender, EventArgs e)
        {
            using (FileStream fstream = File.OpenRead(files_list.SelectedItem.ToString()))
            {
                // преобразуем строку в байты
                byte[] mass = new byte[fstream.Length];
                // считываем данные
                fstream.Read(mass, 0, mass.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(mass);
                //Console.WriteLine($"Текст из файла: {textFromFile}");
                output_field.Text = textFromFile;
                fstream.Close();
            }
        }

        private void Creating_Deliting_Folders()
        {

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string path = dirName, subfolder;

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    subfolder = "" + i;
                    dirInfo.CreateSubdirectory(subfolder);
                    path += @"\" + subfolder;
                    dirInfo = new DirectoryInfo(path);
                }
                catch (Exception) { }

            }

        }

        private async void Search_RootFolder(DirectoryInfo root_folder, Regex file_name)
        {

            try
            {


                FileInfo[] root_files = root_folder.GetFiles();

                foreach (FileInfo root_file in root_files)
                {
                    if (file_name.IsMatch(root_file.Name))
                    {
                        files_list.Items.Add(root_file.FullName);
                    }
                }
            }
            catch (Exception) { }
            try
            {
                DirectoryInfo[] root_folders = root_folder.GetDirectories();
                foreach (DirectoryInfo root_sub_folder in root_folders)
                {
                    if (root_sub_folder.Name.ToCharArray()[0] == 160)
                        continue;
                    try
                    {
                        Search_SubFolders(root_sub_folder, file_name);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
        }

        private async void Search_SubFolders(DirectoryInfo ko, Regex file_name)
        {
            try
            {
                FileInfo[] sub_files = ko.GetFiles();
                foreach (FileInfo file in sub_files)
                    if (file_name.IsMatch(file.Name))
                    {
                        files_list.Items.Add(file.FullName);
                    }
            }catch(Exception)
            {

            }
             void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                parent_dir.Delete(true);
            }
        }
    }
}