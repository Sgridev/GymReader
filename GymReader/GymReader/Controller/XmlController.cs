using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymReader.Controller
{
    class XmlController
    {
        public Table FromExcelToDt(string schedaPath){
        var workbook = new XLWorkbook(schedaPath);
        var ws1 = workbook.Worksheet(1);
            Table tableAndIndex = new Table();
            tableAndIndex.dataTable = ws1.RangeUsed().AsTable().AsNativeDataTable();
            tableAndIndex.indexes = GetBoldIndex(ws1); 
            return tableAndIndex; }

        private List<int> GetBoldIndex(IXLWorksheet ws1)
        {
            List<int> indexList = new List<int>();
            for (int i = 2; i < ws1.LastRowUsed().RowNumber(); i++) {
                if (ws1.Cell(i, 1).Style.Font.Bold == true && ws1.Cell(i, 1).Value.ToString() != "")
                    indexList.Add(i - 1);
            }
            indexList.Add(ws1.LastRowUsed().RowNumber());
            return indexList;
        }
    }


}
