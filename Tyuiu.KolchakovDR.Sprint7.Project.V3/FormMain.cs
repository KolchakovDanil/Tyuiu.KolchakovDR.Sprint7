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
        string path = @"C:\Users\d4six\source\repos\Tyuiu.KolchakovDR.Sprint7\DataSprint7\Teacher.csv";
        DataService ds = new DataService();

        public static string[,] LoadFromFileData(string filePath)
        {
            string fileData = File.ReadAllText(filePath);
            fileData = fileData.Replace('\n', '\r');
            string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            rows = lines.Length;
            columns = lines[0].Split(';').Length;

            string[,] arrayValues = new string[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < columns; c++)
                {
                    arrayValues[r, c] = line_r[c];
                }
            }
            return arrayValues;
        }
        private void buttonLoadFile_KDR_Click(object sender, EventArgs e)
        {
            string[,] arrayValues = new string[rows, columns];
            arrayValues = ds.GetData(path);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewOut_KDR.Rows[r].Cells[c].Value = arrayValues[r, c];
                }
            }
        }
    }
}
