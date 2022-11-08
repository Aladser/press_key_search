using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PressKeySearch
{
    public partial class MainForm : Form
    { 
        String infoFieldText = ""; // текстовый буфер
        // Названия оценок качеств в файле
        String[] nicks = { "псевдоним: \'1\'", "псевдоним: \'2\'", "псевдоним: \'3\'" };
        String[] qualities = {" ЗЕЛЕНАЯ КНОПКА  ", " СЕРАЯ КНОПКА  ", " КРАСНАЯ КНОПКА  "};
        StreamReader sr;

        public MainForm()
        {
            InitializeComponent();
            // фоновая задача
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            selectQualityElement.SelectedIndex = 0; // выбор качества
            officeBox.SelectedIndex = 0;            // выбор офиса
            selectedUnitsComboBox.SelectedIndex = 0;// выбор окна
            // файл логов
            if (!File.Exists(Program.logPath))
            {
                MessageBox.Show("Файл EPMAgent.log не найден. Укажите путь к файлу");
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Логи (*.log)|*.log|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(Program.configPath, false);
                    Program.logPath = ofd.FileName;
                    writer.WriteLine("logpath = " + Program.logPath + "\n");
                    writer.Close();
                }
                else
                    Environment.Exit(0);
            }
            Program.textLength = File.ReadAllLines(Program.logPath).Length;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void aboutImage_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(aboutImage, "Поиск нажатий кнопок\nВерсия 1.12\nby Aladser\n2022");
        }

        private void clear()
        {
            selectedUnitsComboBox.Items.Clear();
        }
        // тело backgroundworker
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            selectedUnitsComboBox.Invoke(new Action(clear));
            selectedUnitsComboBox.Invoke(new Action(() => { selectedUnitsComboBox.Items.Add("Все"); }));
            infoFieldText = "";
            infoField.Invoke(new Action(() => { infoField.Text = ""; }));
            sr = new StreamReader(Program.logPath, Encoding.Default);
            String line;
            String qualityName = ""; // выбранная оценка для поиска
            selectQualityElement.Invoke(new Action(() => { qualityName = nicks[selectQualityElement.SelectedIndex]; }));
            string office = ""; // выбранный офис для поиска
            officeBox.Invoke(new Action(() => { office = officeBox.Items[officeBox.SelectedIndex].ToString(); }));
            List<String> selectedWindows = new List<String>(); // Список
            String selectedQuality = ""; // цвет кнопки
            String window = "";
            int officeNumber = 0;
            selectQualityElement.Invoke(new Action(() => { officeNumber = officeBox.SelectedIndex;  }));
            int li = 0;
            // Считывание нужных строк из лог-файла
            // window = '${Название отделения}' + ' Окно ' + '${номер окна}'
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(qualityName))
                {
                    if (officeNumber == 0 || line.Contains(office))
                    {
                        // выбор цвета кнопки
                        selectQualityElement.Invoke(new Action(() => { 
                            selectedQuality = qualities[selectQualityElement.SelectedIndex]; 
                        }));

                        if (line.Contains("Офис 1") || line.Contains("Офис 2") || line.Contains("Офис 3"))
                        {
                            window = line.Substring(133, 6) + " Окно " + line.Substring(125, 2);
                            infoFieldText += line.Substring(0, 20) + selectedQuality + window + "\n";
                        }
                        else if (line.Contains("Белогорск") || line.Contains("Свободный"))
                        {
                            window = line.Substring(125, 9) + " " + line.Substring(135, 7);
                            infoFieldText += line.Substring(0, 20) + selectedQuality + window + "\n";
                        }
                        else if (line.Contains("Тында"))
                        {
                            window = "Тында " + line.Substring(131, 7);
                            infoFieldText += line.Substring(0, 20) + selectedQuality + window + "\n";
                        }
                        if (!selectedWindows.Contains(window))
                        {
                            selectedWindows.Add(window);
                        }
                        bw.ReportProgress(li*100/Program.textLength);
                        li++;
                    }
                }
            }
            selectedWindows.Sort();
            foreach (String elem in selectedWindows)
            {
                selectedUnitsComboBox.Invoke(new Action(() => { selectedUnitsComboBox.Items.Add(elem); }));
            }
        }
        // обработка процесса backgroundworker
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressLabel.Text = e.ProgressPercentage + "%";
        }

        // Обработка окончания backgroundworker
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                progressLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                progressLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                progressLabel.Text = "Ок";
                selectedUnitsComboBox.SelectedIndex = 0;
                infoField.Text = infoFieldText;
            }
        }
        // Выбор окна для фильтрации
        private void selectedUnitsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (selectedUnitsComboBox.SelectedIndex != 0)
                filterButton.Enabled = true;
            else
                filterButton.Enabled = false;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            String[] textArray = infoFieldText.Split('\n');
            String filterText = "";
            for(int i=0; i<textArray.Length; i++)
            {
                if (textArray[i].Contains(selectedUnitsComboBox.SelectedItem.ToString())) 
                    filterText += textArray[i]+"\n";
            }
            infoField.Text = filterText;
        }
    }
}
