using GymReader.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GymReader
{
    public partial class Form1 : Form
    {
        private IGymReader gymReader;
        public Form1()
        {
            InitializeComponent();
            gymReader = new GymController();
            string schedaPath = GetScheda();
            if (schedaPath != null)
            {
                List<DataTable> dtList = gymReader.ReadScheda(schedaPath);
                FillForm(dtList);
            }
        }

        private void FillForm(List<DataTable> dtList)
        {
           foreach(DataTable dt in dtList)
            {
                TabPage tempTab = new TabPage();
                tabControl1.TabPages.Add(tempTab);
                DataGridView gridView = new DataGridView();
                gridView.DataSource = dt;
                tempTab.Controls.Add(gridView);
            }
        }

        private string GetScheda()
        {
        
            //parametri dialog
                fileDialog1.Title = "Load Excel";
                fileDialog1.InitialDirectory = @"c:\";
                fileDialog1.Filter = "(*.xlsx)|*.xlsx";
                DialogResult result = fileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                return fileDialog1.FileName;
                }
                else
                    return null;
            
        }
    }
}
