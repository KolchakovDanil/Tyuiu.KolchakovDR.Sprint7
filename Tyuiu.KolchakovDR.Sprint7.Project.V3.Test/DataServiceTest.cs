using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.KolchakovDR.Sprint7.Project.V3.Lib;

namespace Tyuiu.KolchakovDR.Sprint7.Project.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ProjectTestGetData()
        {
            DataService ds = new DataService();

            string path = $@"C:\Users\PC\source\repos\Tyuiu.KolchakovDR.Sprint7\Tyuiu.KolchakovDR.Sprint7.Project.V3\bin\DataSprint7\Classroom.csv"; 
            string[,] res = ds.GetData(path);

            string[,] wait = 
            {
                { "1", "106", "Аудитория" },
                { "2", "1101", "Класс-информатики" },
                { "3", "908", "Аудитория" },
                { "4", "512", "Аудитория" },
            };
            CollectionAssert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ProjectTestGetCountRows()
        {
            DataService ds = new DataService();

            string path = $@"C:\Users\PC\source\repos\Tyuiu.KolchakovDR.Sprint7\Tyuiu.KolchakovDR.Sprint7.Project.V3\bin\DataSprint7\Classroom.csv";
            int res = ds.GetCountRows(path);

            int wait = 4;
            Assert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ProjectTestGetAllHours()
        {
            DataService ds = new DataService();

            string[,] matrix = 
            {
                { "123", "456", "123456" },
                { "123", "456", "123456" },
                { "123", "456", "123456" }
            };
            int[] res = ds.GetAllHours(matrix);

            int[] wait = { 123456, 123456, 123456 };

            CollectionAssert.AreEqual(wait, res);
        }
        [TestMethod]
        public void ProjectTestMinValue()
        {
            DataService ds = new DataService();

            int[] Hours = { 1, 2, 3 };

            int min = ds.MinValue(Hours);

            int wait = 1;

            Assert.AreEqual(wait, min);
        }
        [TestMethod]
        public void ProjectTestMaxValue()
        {
            DataService ds = new DataService();

            int[] Hours = { 1, 2, 3 };

            int min = ds.MaxValue(Hours);

            int wait = 3;

            Assert.AreEqual(wait, min);
        }
    }
}
