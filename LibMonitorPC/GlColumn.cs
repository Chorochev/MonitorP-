using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Наименования колонок 
    /// </summary>
    public static class GlColumn
    {
        /// <summary>
        /// DeviceID - Идентификатор процессора.
        /// </summary>
        public static readonly string CPU_DeviceID = "DeviceID";
        /// <summary>
        /// NumberOfCores - Количество ядер
        /// </summary>
        public static readonly string CPU_NumberOfCores = "NumberOfCores";
        /// <summary>
        /// NumberOfLogicalProcessors - Количество логических процессоров
        /// </summary>
        public static readonly string CPU_NumberOfLogicalProcessors = "NumberOfLogicalProcessors";
        /// <summary>
        /// Name - Наименование процессора
        /// </summary>
        public static readonly string CPU_Name = "Name";          
           
    }
}
