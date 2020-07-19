using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    /// <summary>
    /// 设计模式demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 原型模式 https://www.cnblogs.com/weihanli/p/prototype-pattern.html
            var resume = new SimpleResume();
            resume.SetPersonalInfo("小明", "xiaoming@abc.xyz");
            resume.SetWorkExperience("xxx公司", "1990~2000");
            resume.Display();

            var resume1 = (SimpleResume)resume.Clone();
            resume1.SetWorkExperience("xxx企业", "1998~1999");
            resume1.Display();

            var resume2 = (SimpleResume)resume.Clone();
            resume2.SetPersonalInfo("xiaohong", "xiaohong@abc.xyz");
            resume2.Display();




            var complexResume = new ComplexResume();
            complexResume.SetPersonalInfo("xiaoming", "xiaoming@abc.xyz");
            complexResume.SetWorkExperience("xiaomingTecch", "2001~2005");
            complexResume.Show();

            var complexResume1 = (ComplexResume)complexResume.Clone();
            complexResume1.SetPersonalInfo("xiaohong", "xiaohong@abc.xyz");
            complexResume1.Show();

            #endregion
        }
    }
}
