﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ExcelGood
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp; 
        Excel.Workbook xlWB; 
        Excel.Worksheet xlSheet; 


        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        public Form1()
        {
            InitializeComponent();
            LoadData();

            
        }

    private void LoadData()
    {
        Flats = context.Flat.ToList();
            
    }

        private void CreateExcel()
        {
            try
            {
                
                xlApp = new Excel.Application();

               
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                
                xlSheet = xlWB.ActiveSheet;

              
                //CreateTable(); 

                
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) 
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }

        }




    }
}
