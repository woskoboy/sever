using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using OfficeOpenXml;
using System.ComponentModel;
using System.Drawing;
using OfficeOpenXml.Style;
using System.IO;

namespace Lances.Pages {
    static class ExcelExport {

        public static string Start(){
            return ExcelExport.CreateExcel(ExcelExport.CreateCollection());
        }

        public static string CreateExcel<T>(IEnumerable<T> collection){
            
            string path = string.Format(@"{0}/docs/{1}.xlsx",
                HttpRuntime.AppDomainAppPath,
                DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss"));

            int row = 1;

            using (ExcelPackage pack = new ExcelPackage()) {
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Sheet1");

                int col = 0;
                foreach (PropertyDescriptor header in TypeDescriptor.GetProperties(collection.First())) {
                    ws.Cells[row,++col].Value = header.Name;
                }
                ws.Cells[1,1,1,col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[1,1,1,col].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                foreach (T obj in collection) {
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
                    ++row; int i = 0;
                    foreach (PropertyDescriptor prop in properties) {
                        ws.Cells[row,++i].Value = prop.GetValue(obj);
                    }
                }
                ws.Cells[1,1,row,col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                FileInfo f = new FileInfo(path);
                pack.SaveAs(f);
                return path;
                //dic.Add(prop.Name,string.Format("{0}",prop.GetValue(obj)));
            }
        }

        public static List<DataObject> CreateCollection(){
            DataObject obj1 = new DataObject { Name = "John",Age = "32",City = "Moscow",Job = "Developer" };
            DataObject obj2 = new DataObject { Name = "Nick",Age = "30",City = "USA",Job = "Designer" };
            List<DataObject> collection = new List<DataObject>();
            collection.Add(obj1);
            collection.Add(obj2);
            return collection;
        }
    }

    class DataObject {
        public string Name { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
    }
}