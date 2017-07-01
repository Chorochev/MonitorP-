using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Запросы
    /// </summary>
    public static class GlQuery
    {
        /// <summary>
        /// SELECT * FROM Win32_Processor
        /// </summary>
        public static readonly string GetProcessorsInfo = "SELECT * FROM Win32_Processor";
        /// <summary>
        /// "SELECT * FROM Win32_Processor WHERE DeviceID = '{0}'"
        /// </summary>
        public static readonly string GetProcessorInfo = "SELECT * FROM Win32_Processor WHERE DeviceID = '{0}'";
    }
}
