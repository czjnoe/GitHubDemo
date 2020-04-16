using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISControl.Util
{
    public class Enums
    {
        public enum Status
        {
            正在启动 = 0,
            已启动 = 1,
            正在停止 = 2,
            已停止 = 3,
            未知 = 4
        }
    }
}
