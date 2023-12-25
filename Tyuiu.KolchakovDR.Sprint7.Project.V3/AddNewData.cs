using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.KolchakovDR.Sprint7.Project.V3.Lib;
using System.IO;
using System.Diagnostics;

namespace Tyuiu.KolchakovDR.Sprint7.Project.V3
{
    public partial class AddNewData : Form
    {
        public AddNewData()
        {
            InitializeComponent();
        }
        DataService ds = new DataService();

        static string openFilePath = @"..\DataSprint7";
        string path1 = @"..\DataSprint7\Teacher.csv";
        string path2 = @"..\DataSprint7\Classroom.csv";
        string path3 = @"..\DataSprint7\Department.csv";
        string path4 = @"..\DataSprint7\Lesson.csv";


        //Кнопка "Преподаватель" *****************************************************************************************************************
        private void AddNewData_Load(object sender, EventArgs e)
        {
            int x = 1 + ds.GetCountRows(path1);
            textBoxIDTeach_KDR.Text = Convert.ToString(x);
        }
        private void textBoxFIOTeach_KDR_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (!IsValidInput(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxFIOTeach_KDR_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFIOTeach_KDR.Text.Length == 2 || textBoxFIOTeach_KDR.Text.Length == 4 || textBoxFIOTeach_KDR.Text.Length == 6)
            {
                if (textBoxFIOTeach_KDR.Text.Last() != '.')
                {
                    textBoxFIOTeach_KDR.Text = textBoxFIOTeach_KDR.Text.Insert(textBoxFIOTeach_KDR.Text.Length - 1, ".");
                    textBoxFIOTeach_KDR.SelectionStart = textBoxFIOTeach_KDR.Text.Length;
                }
            }
        }
        private bool IsValidInput(char inputChar)
        {
            return Char.IsLetter(inputChar) || inputChar == '.';
        }

        private void buttonAddNewTeach_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxFIOTeach_KDR.Text == "" || textBoxFIOTeach_KDR.Text.Length != 5 || textBoxNumberTeach_KDR.Text == "" || textBoxWorkTeach_KDR.Text == "")
                {
                    MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string[] row = new string[] { $"{textBoxIDTeach_KDR.Text}", $"{textBoxFIOTeach_KDR.Text}", $"{textBoxNumberTeach_KDR.Text}",
                    $"{textBoxWorkTeach_KDR.Text}"};
                    bool completed = ds.AddNewData(path1, row);
                    if (completed)
                    {
                        MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxFIOTeach_KDR.Clear();
                    textBoxNumberTeach_KDR.Clear();
                    textBoxWorkTeach_KDR.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLoadTeacher_KDR_Click(object sender, EventArgs e)
        {
            int x = 1 + ds.GetCountRows(path1);
            textBoxIDTeach_KDR.Text = Convert.ToString(x);
            groupBoxTeach_KDR.Visible = true;
        }

        private void buttonInfo_KDR_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void buttonManagement_KDR_Click(object sender, EventArgs e)
        {
            Management manag = new Management();
            manag.ShowDialog();
        }

    }
    
}
