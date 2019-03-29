using System;
using System.Collections.Generic;
using System.Data;


namespace GymReader.Controller
{
    internal class EntityController
    {
        internal List<DataTable> DivideDt(DataTable dt)
        {
            List<DataTable> tableList = new List<DataTable>();
            foreach (var dt1 in SplitTable(dt, 11))
            {
                DataTable dtx = dt1;
                tableList.Add(dtx);

            }
            return tableList;
        }


        private static List<DataTable> SplitTable(DataTable originalTable, int batchSize)
        {
            List<DataTable> tables = new List<DataTable>();
            int i = 0;
            int j = 1;
            DataTable newDt = originalTable.Clone();
            newDt.TableName = "Table_" + j;
            newDt.Clear();
            foreach (DataRow row in originalTable.Rows)
            {
                DataRow newRow = newDt.NewRow();
                newRow.ItemArray = row.ItemArray;
                newDt.Rows.Add(newRow);
                i++;
                if (i == batchSize)
                {
                    tables.Add(newDt);
                    j++;
                    newDt = originalTable.Clone();
                    newDt.TableName = "Table_" + j;
                    newDt.Clear();
                    i = 0;
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