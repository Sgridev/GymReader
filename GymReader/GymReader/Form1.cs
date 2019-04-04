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
            int counter = 0;
           foreach(DataTable dt in dtList)
            {
                TabPage tempTab = new TabPage();
                counter++;
                tempTab.Text = "SCHEDA " + counter;
                AddTitles(tempTab, dt);
                int j = 40;
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                   
                    if(dt.Rows[i][1].ToString() != "")
                    {
                        Label esLabel = new Label
                        {
                            Text = dt.Rows[i][0].ToString(),
                            Location = new System.Drawing.Point(25, j + 10),
                            Size = new System.Drawing.Size(200, 15)
                    };
                        Label repLabel = new Label
                        {
                            Text = dt.Rows[i][2].ToString(),
                            Location = new System.Drawing.Point(300, j + 10),
                            Size = new System.Drawing.Size(50, 15)
                        };
                        Label recLabel = new Label
                        {
                            Text = dt.Rows[i][3].ToString(),
                            Location = new System.Drawing.Point(425, j + 10),
                            Size = new System.Drawing.Size(30, 15)
                        };
                        tempTab.Controls.Add(esLabel);
                        tempTab.Controls.Add(repLabel);
                        tempTab.Controls.Add(recLabel);

                        for (int y = 0; y < Convert.ToInt32(dt.Rows[i][1].ToString()); y++)
                        {
                            CheckBox cb = new CheckBox();
                            cb.Location = new Point(500 + (y * 20), j + 10);
                            tempTab.Controls.Add(cb);
                        }
                        j += 20;
                    }
                   
                }
                tabControl1.TabPages.Add(tempTab);
            }
        }

        private void AddTitles(TabPage tempTab, DataTable dt)
        {
  
                Label esLabel = new Label
                {
                    Text = "ESERCIZIO",
                    Location = new System.Drawing.Point(25, 10),
                    Size = new System.Drawing.Size(200, 15)
                };
                Label repLabel = new Label
                {
                    Text = "RECUPERO",
                    Location = new System.Drawing.Point(425, 10),
                    Size = new System.Drawing.Size(35, 15)
                };
                Label recLabel = new Label
                {
                    Text = "REP",
                    Location = new System.Drawing.Point(300, 10),
                    Size = new System.Drawing.Size(30, 15)
                };
                tempTab.Controls.Add(esLabel);
                tempTab.Controls.Add(repLabel);
                tempTab.Controls.Add(recLabel);
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
