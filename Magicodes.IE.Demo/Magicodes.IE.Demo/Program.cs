using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.IE.Demo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.IE.Demo
{
    /// <summary>
    /// Magicodes.IE
    /// Github：https://github.com/dotnetcore/Magicodes.IE
    /// 文档:https://docs.xin-lai.com/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            //模板导出excel
            {
                var TemplatePath = Path.Combine(basePath, "Template", "Student.xlsx");
                //创建Excel导出对象 
                IExportFileByTemplate exporter = new ExcelExporter();
                //导出路径 
                var filePath = Path.Combine(basePath, "StudentExport.xlsx"); if (File.Exists(filePath)) File.Delete(filePath);

                 exporter.ExportByTemplate(filePath, new Student
                {
                    ID = "123456",
                    AGE = 25,
                    NAME = "雪雁",
                    Course = new List<Course>()
                    { new Course { ID = "1", CourseName = "0000000001", Grade = 69 }, new Course { ID = "张三", CourseName = "机械工业出版社", Grade = 89 }, new Course { ID = "3", CourseName = "机械工业出版社",  Grade=71}
                    }
                }, TemplatePath);

            }
        }
    }
}
