using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using SKP.App.Abstract;
using SKP.Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Concrete
{
    public class XlsxService
    {
        PersonService _personService;
        WorkDayService _workDayService;
        OverviewSerivce _overviewSerivce;
        FileService _fileService = new FileService();
        public XlsxService(PersonService personService, WorkDayService workDayService)
        {
            _personService = personService;
            _overviewSerivce = new OverviewSerivce(personService, workDayService);

        }

        private IXLWorksheet XlsxGeneratorById(int id)
        {
            Person person = _personService.GetItemById(id);
            var workbook = new XLWorkbook();
            workbook.AddWorksheet($"{person.FirstName}_{person.LastName}");
            var ws = workbook.Worksheet($"{person.FirstName}_{person.LastName}");


            IEnumerable<dynamic> workDayList = (IEnumerable<dynamic>)_overviewSerivce
                .WorkDayInfoGetterByPersonId(id);

            int row = 1;

            ws.Cell("A" + row.ToString()).Value = $"{person.FirstName} {person.LastName}";
            row++;

            foreach (var item in workDayList)
            {
                ws.Cell("A" + row.ToString()).Value = item.Day.ToString();
                ws.Cell("B" + row.ToString()).Value = item.Hours.ToString();
                row++;
            }
            return ws;
        }

        public bool OverviewFileGenerator()
        {
            var workbook = new XLWorkbook();

            foreach (var item in _personService.GetAllItems())
            {
                var sheet = XlsxGeneratorById(item.Id);
                workbook.AddWorksheet(sheet);
            }
            workbook.SaveAs("EveryoneOverview.xlsx");

            bool check = _fileService.fileChecker("EveryoneOverview.xlsx");

            return check;
        }
        public bool OverviewFileGenerator(int id)
        {
            var workbook = new XLWorkbook();

            var neWS = XlsxGeneratorById(id);

            workbook.AddWorksheet(neWS);

            workbook.SaveAs($"Person_overview_{id}.xlsx");

            bool check = _fileService.fileChecker($"Person_overview_{id}.xlsx");

            return check;
        }
    }
}
