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
        //String path = "D:\\EPMAgent0.log";
        String path = "C:\\Users\\User\\Documents\\ProLAN\\EPMAgent\\EPMAgent0.log";
        String[] nicks = { "псевдоним: \'1\'", "псевдоним: \'2\'", "псевдоним: \'3\'" };
        String[] nameButton = {" Нажатие зеленой кнопки  ", " Нажатие серой кнопки  ", " Нажатие красной кнопки  "};
        StreamReader sr;

        public MainForm()
        {
            InitializeComponent();
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
            selectBox.SelectedIndex = 0;
            officeBox.SelectedIndex = 0;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            sr = new StreamReader(path, Encoding.Default);
            String line;
            String quality = nicks[selectBox.SelectedIndex];
            String office = officeBox.Items[officeBox.SelectedIndex].ToString();
            infoField.Text = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(quality))
                {
                    if (officeBox.SelectedIndex==0 || line.Contains(office))
                        if (line.Contains("Офис 1") || line.Contains("Офис 2") || line.Contains("Офис 3"))
                            infoField.Text += line.Substring(0, 20) + nameButton[selectBox.SelectedIndex] + line.Substring(133, 6) + "  Окно " + line.Substring(125, 2) + "\n";
                        else if (line.Contains("Белогорск") || line.Contains("Свободный"))
                            infoField.Text += line.Substring(0, 20) + nameButton[selectBox.SelectedIndex] + line.Substring(125, 9) + "  " + line.Substring(135, 7) + "\n";
                }
            }
        }

        private void aboutImage_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(aboutImage, "(c) Aladser Версия 1.07 2022");
        }
    }
}
