using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Данные формы (с привязкой)
    /// </summary>
    public class BindingDataForm
    {
        /// <summary>
        /// Журнал сообщений
        /// </summary>
        public LogManagerSingleton Logs { get; private set; }

        /// <summary>
        /// Информация о процессоре
        /// </summary>
        public CPUInfo CPUInfo { get; set; }

        #region конструктор класса
        public BindingDataForm()
        {
            Logs = LogManagerSingleton.GetInstance();
            CPUInfo = new CPUInfo();
        }
        #endregion     

    }
}
