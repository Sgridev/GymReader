using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymReader.Controller
{
    public class GymController : IGymReader
    {
        private readonly XmlController xmlController;
        private readonly EntityController entityController;
        public GymController()
        {
            xmlController = new XmlController();
            entityController = new EntityController();
        }
        public List<DataTable> ReadScheda(string schedaPath)
        {
            DataTable dt = xmlController.FromExcelToDt(schedaPath);
            List<DataTable> dtList = entityController.DivideDt(dt);
            return dtList;
        }
    }
}
