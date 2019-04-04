using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GymReader.Controller
{
    internal class EntityController
    {
        internal List<DataTable> DivideDt(Table dt)
        {
            List<DataTable> tableList = new List<DataTable>();
            foreach (var dt1 in SplitTable(dt.dataTable, dt.indexes))
            {
                DataTable dtx = dt1;
                tableList.Add(dtx);

            }
            return tableList;
        }


        private static List<DataTable> SplitTable(DataTable originalTable, List<int> batchSize)
        {
            List<DataTable> tables = new List<DataTable>();
            int i = 0;
            int j = 1;
            DataTable newDt = originalTable.Clone();
            newDt.TableName = "Table_" + j;
            newDt.Clear();
            int counter = 1;
            foreach (DataRow row in originalTable.Rows)
            {
                if (counter < batchSize.Count)
                {
                    DataRow newRow = newDt.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    newDt.Rows.Add(newRow);
                    i++;
                    if (i == batchSize[counter] - 1)
                    {
                        tables.Add(newDt);
                        j++;
                        newDt = originalTable.Clone();
                        newDt.TableName = "Table_" + j;
                        newDt.Clear();
                        counter++;


                    }

                }
             }
            if (newDt.Rows.Count > 0)
            {
                tables.Add(newDt);
                j++;
                newDt = originalTable.Clone();
                newDt.TableName = "Table_" + j;
                newDt.Clear();

            }
            return tables;
        }




}
}