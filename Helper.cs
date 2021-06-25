using CV_creator.Entity;
using CV_creator.MyMessageBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CV_creator
{
    class Helper
    {
        public static void CreateStandartImage()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory + @"\Images";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            Properties.Resources.user.Save(directory + @"\Standart_image.png");
        }

        public static void CopyFile(string sourceFileName, string directory, string fileName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var f = new FileInfo(sourceFileName);
            string destFileName = directory + @"\" + fileName + f.Extension;
            File.Copy(sourceFileName, destFileName, true);
        }
        public static List<string[]> ReadTextFileToList(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            List<string[]> list = new List<string[]>();
            if (File.Exists(fileName) && file.Extension == ".txt")
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] items = line.Split(',');
                    if (items.Length == 3 && items[0] != "" && items[1] != "" && items[2] != "")
                    {
                        list.Add(items);
                    }
                }
            }
            return list;
        }

        public static string Backup()
        {
            string directory = Properties.Settings.Default.DirectorySaveBackupCv + @"\" + Properties.Settings.Default.FolderNameBackupCv;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + @"data\database.accdb";

            if (File.Exists(sourceFileName))
            {
                DateTime d = DateTime.Now;
                string date = d.Year + "_" + d.Month + "_" + d.Day + " ";
                string time = d.Hour.ToString() + "h_" + d.Minute.ToString() + "m_" + d.Second.ToString() + "s";
                string disFileName = directory + @"\" + "backup CV " + date + time + ".accdb";
                File.Copy(sourceFileName, disFileName, true);
                new MessageOk(Words.BackupSuccess + "\n" + disFileName, Words.Backup, MessageIcon.Success).ShowDialog();
                return disFileName;
            }
            else return "";
        }

        public static void Restore()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = Words.Open;
            dialog.Filter = "MS Access database|*.accdb;";
            dialog.InitialDirectory = Properties.Settings.Default.DirectorySaveBackupCv + @"\" + Properties.Settings.Default.FolderNameBackupCv;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string dis = AppDomain.CurrentDomain.BaseDirectory + @"data\database.accdb";
                if (File.Exists(dis))
                {
                    File.Copy(dialog.FileName, dis, true);
                }
                else
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data"))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"data");
                    }
                    File.Copy(dialog.FileName, dis);
                }
                new MessageOk(Words.RestoreSuccess + "\n" + dialog.FileName, Words.RestoreDatabase, MessageIcon.Success).ShowDialog();
            }
        }

        public static void CreateDlls()
        {
            if (!File.Exists(@".\Microsoft.ReportViewer.WinForms.dll"))
            {
                File.WriteAllBytes(@".\Microsoft.ReportViewer.WinForms.dll", Properties.Resources.Microsoft_ReportViewer_WinForms);
            }
            if (!File.Exists(@".\Microsoft.ReportViewer.Common.dll"))
            {
                File.WriteAllBytes(@".\Microsoft.ReportViewer.Common.dll", Properties.Resources.Microsoft_ReportViewer_Common);
            }
            if (!File.Exists(@".\Microsoft.ReportViewer.ProcessingObjectModel.dll"))
            {
                File.WriteAllBytes(@".\Microsoft.ReportViewer.ProcessingObjectModel.dll", Properties.Resources.Microsoft_ReportViewer_ProcessingObjectModel);
            }
            if (!File.Exists(@".\Microsoft.SqlServer.Types.dll"))
            {
                File.WriteAllBytes(@".\Microsoft.SqlServer.Types.dll", Properties.Resources.Microsoft_SqlServer_Types);
            }
        }
        public static void CreateLanguageDll()
        {
            if (!Directory.Exists(@".\ar"))
            {
                Directory.CreateDirectory(@".\ar");
            }
            if (!File.Exists(@".\ar\CV creator.resources.dll"))
            {
                File.WriteAllBytes(@".\ar\CV creator.resources.dll", Properties.Resources.CV_creator_resources);
            }
        }

        public static void ExportCvGenerator()
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {

                string directory = f.SelectedPath + @"\CV Generator";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Begin Sections
                cSection section = new cSection();
                DataTable dtSections = section.getSections();
                string sectiontext = "";
                for (int i = 0; i < dtSections.Rows.Count; i++)
                {
                    string directorySection = directory + @"\" + dtSections.Rows[i][1].ToString();
                    sectiontext = sectiontext + "\n" + dtSections.Rows[i][1].ToString() + "," + dtSections.Rows[i][3].ToString() + "," + dtSections.Rows[i][2].ToString();
                    if (!Directory.Exists(directorySection))
                    {
                        Directory.CreateDirectory(directorySection);
                    }

                    // Begin Sub_sections
                    cItem2 sub_section = new cItem2();
                    DataTable dtSub_sections = sub_section.getItems((int)dtSections.Rows[i][0]);

                    string sub_ectionText = "";
                    for (int j = 0; j < dtSub_sections.Rows.Count; j++)
                    {

                        string directorySub_section = directorySection + @"\" + dtSub_sections.Rows[j][1].ToString();
                        sub_ectionText = sub_ectionText + "\n" + dtSub_sections.Rows[j][1].ToString() + "," + dtSub_sections.Rows[j][3].ToString() + "," + dtSub_sections.Rows[j][2].ToString();
                        if (!Directory.Exists(directorySub_section))
                        {
                            Directory.CreateDirectory(directorySub_section);
                        }

                        // Begin Selections ----
                        cDetails selections = new cDetails();
                        DataTable dtSelections = selections.getDetails((int)dtSub_sections.Rows[j][0]);
                        dtSelections.Rows.RemoveAt(0);
                        string selectionText = "";
                        for (int k = 0; k < dtSelections.Rows.Count; k++)
                        {
                            selectionText = selectionText + "\n" + dtSelections.Rows[k][1].ToString() + "," + dtSelections.Rows[k][3].ToString() + "," + dtSelections.Rows[k][2].ToString();
                        }

                        Helper.CreateFileText(directorySub_section, dtSub_sections.Rows[j][1].ToString(), selectionText);
                        // End Selections ----
                    }

                    Helper.CreateFileText(directorySection, dtSections.Rows[i][1].ToString(), sub_ectionText);
                    // End Sub_sections
                }

                Helper.CreateFileText(directory, "Sections", sectiontext);
                // End Sections
            }
        }

        public static bool CreateFileText(string directory, string fileName, string text)
        {
            string path = directory + @"\" + fileName + ".txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                byte[] data = Encoding.UTF8.GetBytes(text);
                File.WriteAllBytes(path, data);
                return true;
            }
            else return false;
        }
        public static bool CreateFileText_SaveFileDialog(string text)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Text file|*.txt";
            if (f.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(f.FileName);

                return CreateFileText(info.DirectoryName, info.Name.Remove(info.Name.Length - 4), text);
            }
            else return false;
        }
        public static bool AppendTextToFileText(string path, string text)
        {
            FileInfo file = new FileInfo(path);
            if (file.Extension == ".txt")
            {
                if (File.Exists(path))
                {
                    File.AppendAllText(path, "\n" + text);
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public static bool AppendTextToFileText_OpenFileDialog(string text)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files |*.txt;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;

                return AppendTextToFileText(path, text);
            }
            else return false;
        }
    }
}
