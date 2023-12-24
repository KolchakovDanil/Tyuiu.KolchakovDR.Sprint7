using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.KolchakovDR.Sprint7.Project.V3.Lib
{
    public class DataService
    {
        public string[,] GetData(string path)
        {
            string fileData = File.ReadAllText(path);
            fileData = fileData.Replace('\n', '\r');
            string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length;
            int columns = lines[0].Split(';').Length;

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
        public bool UpData(string path, string[,] Data)
        {
            bool save = false;
            File.WriteAllText(path, string.Empty);
            string str = "";

            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (j != Data.GetLength(1) - 1)
                    {
                        str = str + Data[i, j] + ";";
                    }
                    else
                    {
                        str = str + Data[i, j];
                    }
                }

                if (i != Data.GetLength(0) - 1)
                {
                    File.AppendAllText(path, str + Environment.NewLine, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(path, str + Environment.NewLine, Encoding.UTF8);
                }
                str = "";
            }
            save = true;
            return save;
        }
        public int GetCountRows(string path)
        {
            string[] Row = File.ReadAllLines(path);

            int countRow = Row.Length;

            return countRow;
        }
        public bool AddNewData(string path, string[] line)
        {
            bool add = false;

            string str = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (i != line.Length - 1)
                {
                    str = str + line[i] + ";";
                }
                else
                {
                    str = str + line[i];
                }
            }
            File.AppendAllText(path, str + Environment.NewLine, Encoding.UTF8);
            add = true;
            return add;
        }

    }
}
