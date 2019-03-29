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
        public DataTable FromExcelToDt(string schedaPath){
        var workbook = new XLWorkbook(schedaPath);
        var ws1 = workbook.Worksheet(1);
       return ws1.RangeUsed().AsTable().AsNativeDataTable(); }
    }


}
