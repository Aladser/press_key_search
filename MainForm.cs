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

namespace PressKeySearch
{
    public partial class MainForm : Form
    {
        int textLength; // число строк в EPMAgent0.log
        String text = "";
        //String path = "D:\\EPMAgent0.log";
        String path = "C:\\Users\\User\\Documents\\ProLAN\\EPMAgent\\EPMAgent0.log";
        /// <summary>
        /// Названия оценок качеств в файле
        /// </summary>
        String[] nicks = { "псевдоним: \'1\'", "псевдоним: \'2\'", "псевдоним: \'3\'" };
        String[] qualities = {" Нажата зеленая кнопка  ", " Нажата серая кнопка  ", " Нажата красная кнопка  "};
        StreamReader sr;

        public MainForm()
        {
            InitializeComponent();

            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;


            if (!File.Exists(path))
            {
                MessageBox.Show("Файл " + path + " не существует. Укажите путь к файлу");
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Логи (*.log)|*.log|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            textLength = System.IO.File.ReadAllLines(path).Length;
            selectQualityElement.SelectedIndex = 0;
            officeBox.SelectedIndex = 0;
            selectedUnitsComboBox.SelectedIndex = 0;
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
            toolTip.SetToolTip(aboutImage, "Поиск вызов кнопок\nВерсия 1.1\nby Aladser\n2022");
        }
        // тело backgroundworker
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            selectedUnitsComboBox.Invoke(new Action(() => { selectedUnitsComboBox.Items.Clear(); }));
            selectedUnitsComboBox.Invoke(new Action(() => { selectedUnitsComboBox.Items.Add("Все"); }));
            text = "";
            infoField.Invoke(new Action(() => { infoField.Text = ""; }));
            sr = new StreamReader(path, Encoding.Default);
            String line;
            String qualityName = ""; // выбранная оценка для поиска
            String office = ""; // выбранный офис для поиска
            selectQualityElement.Invoke(new Action(() => { qualityName = nicks[selectQualityElement.SelectedIndex]; }));
            officeBox.Invoke(new Action(() => { office = officeBox.Items[officeBox.SelectedIndex].ToString(); }));

            List<String> selectedWindows = new List<String>(); // Список
            String selectedQuality = "";
            String window = "";
            int officeNumber = 0;
            selectQualityElement.Invoke(new Action(() => { officeNumber = officeBox.SelectedIndex;  }));
            int li = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(qualityName))
                {
                    if (officeNumber == 0 || line.Contains(office))
                    {
                        selectQualityElement.Invoke(new Action(() => { selectedQuality = qualities[selectQualityElement.SelectedIndex]; }));
                        if (line.Contains("Офис 1") || line.Contains("Офис 2") || line.Contains("Офис 3"))
                        {
                            window = line.Substring(133, 6) + " " + "Окно " + line.Substring(125, 2);
                            text += line.Substring(0, 20) + selectedQuality + window + "\n";
                        }
                        else if (line.Contains("Белогорск") || line.Contains("Свободный"))
                        {
                            window = line.Substring(125, 9) + " " + line.Substring(135, 7);
                            text += line.Substring(0, 20) + selectedQuality + window + "\n";    
                        }
                        if (!selectedWindows.Contains(window))
                        {
                            selectedWindows.Add(window);
                        }
                        bw.ReportProgress(li*100/textLength);
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
                infoField.Text = text;
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
            String[] textArray = text.Split('\n');
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
