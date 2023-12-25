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
                if (textBoxIDTeach_KDR.Text=="" || textBoxFIOTeach_KDR.Text == "" || textBoxFIOTeach_KDR.Text.Length != 5 || textBoxNumberTeach_KDR.Text == "" || textBoxWorkTeach_KDR.Text == "")
                {
                    MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if(textBoxIDTeach_KDR.Text == "")
                    {
                        MessageBox.Show("ID пуст! Пожалуйста перезайдите на страницу \"Преподаватели\"", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    textBoxIDTeach_KDR.Clear();
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
            groupBoxAudi_KDR.Visible = false;
            groupBoxPred_KDR.Visible = false;
            groupBoxKaf_KDR.Visible = false;
        }

        //Кнопка "Аудитории" *****************************************************************************************************************
        private void buttonLoadClass_KDR_Click(object sender, EventArgs e)
        {
            groupBoxPred_KDR.Visible = false;
            groupBoxKaf_KDR.Visible = false;
            groupBoxTeach_KDR.Visible = false;
            groupBoxAudi_KDR.Visible = true;
            int x = 1 + ds.GetCountRows(path2);
            textBoxIDAudi_KDR.Text = Convert.ToString(x);
        }
        private void buttonAddAudi_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIDAudi_KDR.Text == "" || textBoxNumAudi_KDR.Text == "" || textBoxNameAudi_KDR.Text == "")
                {
                    MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (textBoxIDAudi_KDR.Text == "")
                    {
                        MessageBox.Show("ID пуст! Пожалуйста перезайдите на страницу \"Аудитории\"", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string[] row = new string[] { $"{textBoxIDAudi_KDR.Text}", $"{textBoxNumAudi_KDR.Text}", $"{textBoxNameAudi_KDR.Text}"};
                    bool completed = ds.AddNewData(path2, row);
                    if (completed)
                    {
                        MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxNumAudi_KDR.Clear();
                    textBoxNameAudi_KDR.Clear();
                    textBoxIDAudi_KDR.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Кнопка "Кафедры" *******************************************************************************************************************
        private void buttonLoadDepartment_KDR_Click(object sender, EventArgs e)
        {
            groupBoxTeach_KDR.Visible = false;
            groupBoxAudi_KDR.Visible = false;
            groupBoxKaf_KDR.Visible = true;
            groupBoxPred_KDR.Visible = false;
            int x = 1 + ds.GetCountRows(path3);
            textBoxIDKaf_KDR.Text = Convert.ToString(x);
        }
        private void buttonAddKaf_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIDKaf_KDR.Text == "" || textBoxNumZKaf_KDR.Text == "" || textBoxNameKaf_KDR.Text == "")
                {
                    MessageBox.Show("Введите все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (textBoxIDKaf_KDR.Text == "")
                    {
                        MessageBox.Show("ID пуст! Пожалуйста перезайдите на страницу \"Кафедры\"", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string[] row = new string[] { $"{textBoxIDKaf_KDR.Text}", $"{textBoxNumZKaf_KDR.Text}", $"{textBoxNameKaf_KDR.Text}" };
                    bool completed = ds.AddNewData(path3, row);
                    if (completed)
                    {
                        MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxIDKaf_KDR.Clear();
                    textBoxNumZKaf_KDR.Clear();
                    textBoxNameKaf_KDR.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Кнопка "Предметы" ******************************************************************************************************************
        private void buttonLoadLesson_KDR_Click(object sender, EventArgs e)
        {
            groupBoxTeach_KDR.Visible = false;
            groupBoxAudi_KDR.Visible = false;
            groupBoxKaf_KDR.Visible = false;
            groupBoxPred_KDR.Visible = true;
            int x = 1 + ds.GetCountRows(path4);
            textBoxIDPred_KDR.Text = Convert.ToString(x);
        }
        private void buttonAddPred_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIDPred_KDR.Text == "" || textBoxNamePred_KDR.Text == "" || textBoxKolPred_KDR.Text == "" 
                    || textBoxClassPred_KDR.Text == "" || 
                    textBoxTypePred_KDR.Text == "" || textBoxTypePred_KDR.Text != "Экзамен" && textBoxTypePred_KDR.Text != "Зачет")
                {
                    MessageBox.Show("Вы не заполнили все данные или допустили ошибку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (textBoxIDPred_KDR.Text == "")
                    {
                        MessageBox.Show("ID пуст! Пожалуйста перезайдите на страницу \"Предметы\"", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (textBoxTypePred_KDR.Text != "" && (textBoxTypePred_KDR.Text != "Экзамен" || textBoxTypePred_KDR.Text != "Зачет"))
                    {
                        MessageBox.Show("В поле \"Тип контроля\" вы допустили ошибку! Тип контроля может быть лишь: \"Экзамен\" или \"Зачет\" ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string[] row = new string[] { $"{textBoxIDPred_KDR.Text}", $"{textBoxNamePred_KDR.Text}", 
                        $"{textBoxKolPred_KDR.Text}", $"{textBoxTypePred_KDR.Text}", $"{textBoxClassPred_KDR.Text}" };
                    bool completed = ds.AddNewData(path4, row);
                    if (completed)
                    {
                        MessageBox.Show("Данные добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    textBoxIDPred_KDR.Clear();
                    textBoxNamePred_KDR.Clear();
                    textBoxKolPred_KDR.Clear();
                    textBoxTypePred_KDR.Clear();
                    textBoxClassPred_KDR.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Другие функции *********************************************************************************************************************
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
        private void textBoxKolPred_KDR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxCyrillic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }

}
