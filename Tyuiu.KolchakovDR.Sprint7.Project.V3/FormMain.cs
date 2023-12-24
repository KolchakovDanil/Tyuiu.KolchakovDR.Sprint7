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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        static int rows;
        static int columns;
        static string openFilePath = @"..\DataSprint7"; 
        string path1 = @"..\DataSprint7\Teacher.csv";
        string path2 = @"..\DataSprint7\Classroom.csv";
        string path3 = @"..\DataSprint7\Department.csv";
        string path4 = @"..\DataSprint7\Lesson.csv";
        
        DataService ds = new DataService();

        private void dataGridViewOut_KDR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void buttonLoadTeacher_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] DataMatrix = ds.GetData(path1);

                int rows = DataMatrix.GetLength(0);
                int columns = DataMatrix.GetLength(1);

                dataGridViewOut_KDR.RowCount = rows;
                dataGridViewOut_KDR.ColumnCount = columns;

                dataGridViewOut_KDR.Columns[0].HeaderText = "ID";
                dataGridViewOut_KDR.Columns[1].HeaderText = "ФИО преподавателя";
                dataGridViewOut_KDR.Columns[2].HeaderText = "Номер преподавателя";
                dataGridViewOut_KDR.Columns[3].HeaderText = "Должность преподавателя";


                for (int i = 0; i < columns; i++)
                {
                    dataGridViewOut_KDR.Columns[i].Width = 160;
                    dataGridViewOut_KDR.Columns[0].Width = 40;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewOut_KDR.Rows[r].Cells[c].Value = DataMatrix[r, c];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonRed_KDR.Visible = true;
            buttonChekFileTeacher_KDR.Visible = true;
            buttonKol_KDR.Visible = true;
            groupBoxFunc_KDR.Visible = true;
            groupBoxRed_KDR.Visible = true;
            buttonAddTeach_KDR.Visible = true;
            buttonSaveTeachers_KDR.Visible = false;
            panelBottomAudi_KDR.Visible = false;
            panelLeftAudi_KDR.Visible = false;
            buttonRed_KDR.Visible = true;
            buttonSaveTeachers_KDR.Visible = false;
            dataGridViewOut_KDR.ReadOnly = true;
            buttonCansel_KDR.Visible = false;
        }

        private void buttonLoadClass_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] DataMatrix = ds.GetData(path2);

                int rows = DataMatrix.GetLength(0);
                int columns = DataMatrix.GetLength(1);

                dataGridViewOut_KDR.RowCount = rows;
                dataGridViewOut_KDR.ColumnCount = columns;

                dataGridViewOut_KDR.Columns[0].HeaderText = "ID";
                dataGridViewOut_KDR.Columns[1].HeaderText = "Номер аудитории";
                dataGridViewOut_KDR.Columns[2].HeaderText = "Назавание аудитории";

                for (int i = 0; i < columns; i++)
                {
                    dataGridViewOut_KDR.Columns[i].Width = 160;
                    dataGridViewOut_KDR.Columns[0].Width = 40;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewOut_KDR.Rows[r].Cells[c].Value = DataMatrix[r, c];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            panelBottomAudi_KDR.Visible = true;
            panelLeftAudi_KDR.Visible = true;
        }

        private void buttonLoadDepartment_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] DataMatrix = ds.GetData(path3);

                int rows = DataMatrix.GetLength(0);
                int columns = DataMatrix.GetLength(1);

                dataGridViewOut_KDR.RowCount = rows;
                dataGridViewOut_KDR.ColumnCount = columns;

                dataGridViewOut_KDR.Columns[0].HeaderText = "ID";
                dataGridViewOut_KDR.Columns[1].HeaderText = "Назавание кафедры";
                dataGridViewOut_KDR.Columns[2].HeaderText = "Номер зав. кафедры";

                for (int i = 0; i < columns; i++)
                {
                    dataGridViewOut_KDR.Columns[i].Width = 160;
                    dataGridViewOut_KDR.Columns[0].Width = 40;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewOut_KDR.Rows[r].Cells[c].Value = DataMatrix[r, c];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            panelBottom_KDR.Visible = false;
            panelLeftButton_KDR.Visible = false;
            panelBottomAudi_KDR.Visible = false;
            panelLeftAudi_KDR.Visible = false;
        }

        private void buttonLoadLesson_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] DataMatrix = ds.GetData(path4);

                int rows = DataMatrix.GetLength(0);
                int columns = DataMatrix.GetLength(1);

                dataGridViewOut_KDR.RowCount = rows;
                dataGridViewOut_KDR.ColumnCount = columns;

                dataGridViewOut_KDR.Columns[0].HeaderText = "ID";
                dataGridViewOut_KDR.Columns[1].HeaderText = "Название предмета";
                dataGridViewOut_KDR.Columns[2].HeaderText = "Кол-во часов за семестр";
                dataGridViewOut_KDR.Columns[3].HeaderText = "Тип контроля";
                dataGridViewOut_KDR.Columns[4].HeaderText = "Раздел предмета";

                for (int i = 0; i < columns; i++)
                {
                    dataGridViewOut_KDR.Columns[i].Width = 160;
                    dataGridViewOut_KDR.Columns[0].Width = 40;
                    dataGridViewOut_KDR.Columns[2].Width = 100;
                    dataGridViewOut_KDR.Columns[3].Width = 100;
                    dataGridViewOut_KDR.Columns[4].Width = 100;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewOut_KDR.Rows[r].Cells[c].Value = DataMatrix[r, c];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenFile_KDR_Click(object sender, EventArgs e)
        {
            string[] PathCsv = Directory.GetFiles(openFilePath, "*.csv");

            if (PathCsv.Length > 0)
            {
            Process.Start("explorer.exe", openFilePath);
            }
            else
            {
                MessageBox.Show("В выбранной папке нет файлов с расширением .csv.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }

        private void buttonChekFileTeacher_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process csv = new System.Diagnostics.Process();
                csv.StartInfo.FileName = "Excel.exe";
                csv.StartInfo.Arguments = path1;
                csv.Start();
            }
            catch
            {
                MessageBox.Show("Сбой открытия файла", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonChekFileAudi_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process csv = new System.Diagnostics.Process();
                csv.StartInfo.FileName = "Excel.exe";
                csv.StartInfo.Arguments = path2;
                csv.Start();
            }
            catch
            {
                MessageBox.Show("Сбой открытия файла", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonChekFileKaf_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process csv = new System.Diagnostics.Process();
                csv.StartInfo.FileName = "Excel.exe";
                csv.StartInfo.Arguments = path3;
                csv.Start();
            }
            catch
            {
                MessageBox.Show("Сбой открытия файла", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonChekFilePred_KDR_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process csv = new System.Diagnostics.Process();
                csv.StartInfo.FileName = "Excel.exe";
                csv.StartInfo.Arguments = path4;
                csv.Start();
            }
            catch
            {
                MessageBox.Show("Сбой открытия файла", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSaveTeachers_KDR_Click(object sender, EventArgs e)
        {
            List<string[]> dataList = new List<string[]>();

            for (int i = 0; i < dataGridViewOut_KDR.RowCount; i++)
            {
                bool hasEmptyValue = false;
                string[] rowData = new string[dataGridViewOut_KDR.ColumnCount];

                for (int j = 0; j < dataGridViewOut_KDR.ColumnCount; j++)
                {
                    object cellValue = dataGridViewOut_KDR.Rows[i].Cells[j].Value;
                    rowData[j] = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    if (string.IsNullOrEmpty(rowData[j]))
                    {
                        hasEmptyValue = true;
                        break;
                    }
                }
                if (hasEmptyValue)
                {
                    DialogResult result = MessageBox.Show("Обнаружены пустые значения в строке. Хотите удалить эту строку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        continue;
                    }
                    if(result == DialogResult.No)
                    {
                        return;
                    }
                }
                dataList.Add(rowData);
            }

            string[,] data = new string[dataList.Count, dataGridViewOut_KDR.ColumnCount];
            for (int i = 0; i < dataList.Count; i++)
            {
                for (int j = 0; j < dataGridViewOut_KDR.ColumnCount; j++)
                {
                    data[i, j] = dataList[i][j];
                }
            }
            bool save = ds.UpData(path1, data);

            if (save)
            {
                MessageBox.Show("Таблица обновлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            buttonLoadTeacher_KDR.PerformClick();
            buttonRed_KDR.Visible = true;
            buttonSaveTeachers_KDR.Visible = false;
            dataGridViewOut_KDR.ReadOnly = true;
            buttonCansel_KDR.Visible = false;
        }

        private void buttonRed_KDR_Click(object sender, EventArgs e)
        {
            dataGridViewOut_KDR.ReadOnly = false;
            buttonSaveTeachers_KDR.Visible = true;
            buttonRed_KDR.Visible = false;
            buttonCansel_KDR.Visible = true;
        }
        private void buttonCansel_KDR_Click(object sender, EventArgs e)
        {
            buttonRed_KDR.Visible = true;
            buttonSaveTeachers_KDR.Visible = false;
            buttonCansel_KDR.Visible = false;
            dataGridViewOut_KDR.ReadOnly = true;
            buttonLoadTeacher_KDR.PerformClick();
        }

        private void buttonSumTeacher_KDR_Click(object sender, EventArgs e)
        {
            int rows = ds.GetCountRows(path1);

            textBoxSum_KDR.Text = Convert.ToString(rows);
        }

        private void buttonKol_KDR_Click(object sender, EventArgs e)
        {
            groupBoxKolTeach_KDR.Visible = true;
            buttonSumTeacher_KDR.Visible = true;
            textBoxSum_KDR.Visible = true;
        }

        private void buttonSaveAudi_KDR_Click(object sender, EventArgs e)
        {
            string[,] Data = new string[dataGridViewOut_KDR.RowCount, dataGridViewOut_KDR.ColumnCount];
            for (int i = 0; i < dataGridViewOut_KDR.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewOut_KDR.ColumnCount; j++)
                {
                    Data[i, j] = dataGridViewOut_KDR.Rows[i].Cells[j].Value.ToString();
                }
            }
            bool save = ds.UpData(path2, Data);

            if (save)
            {
                MessageBox.Show("Таблица обновлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            buttonRedAudi_KDR.Visible = true;
            dataGridViewOut_KDR.ReadOnly = false;
            buttonCansaleAudi_KDR.Visible = false;
            buttonSaveAudi_KDR.Visible = false;
        }

        private void buttonRedAudi_KDR_Click(object sender, EventArgs e)
        {
            buttonRedAudi_KDR.Visible = false;
            buttonSaveAudi_KDR.Visible = true;
            dataGridViewOut_KDR.ReadOnly = true;
            buttonCansaleAudi_KDR.Visible = true;
        }

        private void buttonRezAudi_KDR_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddAudi_KDR_Click(object sender, EventArgs e)
        {
            AddNewData add = new AddNewData();
            add.ShowDialog();
        }

        private void buttonCansaleAudi_KDR_Click(object sender, EventArgs e)
        {
            buttonRedAudi_KDR.Visible = true;
            buttonSaveAudi_KDR.Visible = false;
            buttonCansaleAudi_KDR.Visible = false;
            dataGridViewOut_KDR.ReadOnly = true;
            buttonLoadClass_KDR.PerformClick();
        }

        private void buttonAddTeach_KDR_Click(object sender, EventArgs e)
        {
            AddNewData add = new AddNewData();
            add.ShowDialog();
        }


    }
    
}