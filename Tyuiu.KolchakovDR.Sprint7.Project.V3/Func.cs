using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using Tyuiu.KolchakovDR.Sprint7.Project.V3.Lib;

namespace Tyuiu.KolchakovDR.Sprint7.Project.V3
{
    public partial class Func : Form
    {
        public Func()
        {
            InitializeComponent();
        }
        string path = @"..\DataSprint7\Lesson.csv";
        DataService ds = new DataService();
        private void FormFunc_Load(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetData(path);
            int[] HoursArray = new int[DataMatrix.GetLength(0)];
            for (int i = 0; i < HoursArray.Length; i++)
            {
                HoursArray[i] = Convert.ToInt32(DataMatrix[i, 2]);
            }

            int countRows = 0;
            for (int i = 0; i < DataMatrix.GetLength(0); i++)
            {
                countRows += 1;
            }

            string[] nameArray = new string[DataMatrix.GetLength(0)];
            for (int i = 0; i < nameArray.Length; i++)
            {
                nameArray[i] = DataMatrix[i, 0];
            }

            int min = ds.MinValue(HoursArray);

            int max = ds.MaxValue(HoursArray);

            //double avgPrice = ds.AverageValue(pricePC);

            double sum = 0;
            for (int i = 0; i < HoursArray.Length; i++)
            {
                sum += HoursArray[i];
            }

            Title title = new Title();
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.Text = "Статистика количества часов предметов на семестр";

            chartPre_KDR.Titles.Add(title);

            for (int i = 0; i < HoursArray.Length; i++)
            {
                chartPre_KDR.Series["Series1"].IsValueShownAsLabel = true;
                chartPre_KDR.Series["Series1"].Points.AddXY(nameArray[i], HoursArray[i]);
            }
            chartPre_KDR.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartPre_KDR.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        private void buttonInfo_KDR_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }
    }
}
