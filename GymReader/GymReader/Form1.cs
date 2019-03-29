using GymReader.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                //DataGridView gridView = new DataGridView();
                //gridView.DataSource = dt;
                //tempTab.Controls.Add(gridView);
                Panel panel = new Panel();
                panel.Location = new System.Drawing.Point(26, 12);
                panel.Name = "Panel1";
                panel.Size = new System.Drawing.Size(228, 200);
                panel.TabIndex = 0;
                tempTab.Controls.Add(panel);
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if(dt.Rows[i][1].ToString() != "")
                    {
                        Label esLabel = new Label
                        {
                            Text = dt.Rows[i][0].ToString()
                        };
                        Label repLabel = new Label
                        {
                            Text = dt.Rows[i][2].ToString()
                        };
                        Label recLabel = new Label
                        {
                            Text = dt.Rows[i][3].ToString()
                        };
                        tempTab.Controls.Add(esLabel);
                        tempTab.Controls.Add(repLabel);
                        tempTab.Controls.Add(recLabel);
                       
                        for (int j = i; j < Convert.ToInt32(dt.Rows[j][1].ToString()); j++)
                        {
                            CheckBox cb = new CheckBox();
                            cb.Location = new Point(160, 30 * j + 10);
                            tempTab.Controls.Add(cb);
                        }
                    }

                }
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
