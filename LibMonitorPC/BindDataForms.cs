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
        /// Информация о процессорах
        /// </summary>
        public List<CPUInfo> ListCPU { get; set; }

        public void LoadData()
        {
            //var result = new QueryHelper().SetScope(GlScope.RootCIMV2).SetQuery(GlQuery.GetProcessorsInfo).ExecuteQuery().GetValues(GlColumn.CPU_DeviceID);
            //foreach (var item in result)
            //{
            //    ListCPU.Add(new CPUInfo((string)item[GlColumn.CPU_DeviceID]));
            //    ListCPU.Add(new CPUInfo((string)item[GlColumn.CPU_DeviceID]));
            //}

            foreach (var item in ListCPU)
            {
                item.GetProcessorInfo();
            }
        }

        #region конструктор класса
        public BindingDataForm()
        {
            Logs = LogManagerSingleton.GetInstance();
            ListCPU = new List<CPUInfo>();
            var result = new QueryHelper().SetScope(GlScope.RootCIMV2).SetQuery(GlQuery.GetProcessorsInfo).ExecuteQuery().GetValues(GlColumn.CPU_DeviceID);
            foreach (var item in result)
            {
                ListCPU.Add(new CPUInfo((string)item[GlColumn.CPU_DeviceID]));
                ListCPU.Add(new CPUInfo((string)item[GlColumn.CPU_DeviceID]));
            }
        }
        #endregion     

    }
}
