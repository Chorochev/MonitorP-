using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Данные о процессоре
    /// </summary>
    public class CPUInfo : INotifyPropertyChanged
    {
        private QueryHelper _queryHelper;

        #region DeviceID        
        private string _deviceID;
        /// <summary>
        /// Идентификатор процессора
        /// </summary>
        public string DeviceID
        {
            get { return _deviceID; }
            private set
            {
                _deviceID = value;
                NotifyChanged("DeviceID");
            }
        }
        #endregion

        #region NumberOfCores
        private int _numberOfCores;
        /// <summary>
        /// Число процессоров
        /// </summary>
        public int NumberOfCores
        {
            get { return _numberOfCores; }
            private set
            {
                _numberOfCores = value;
                NotifyChanged("NumberOfCores");
            }
        }
        #endregion

        #region NumberOfLogicalProcessors
        private int _numberOfLogicalProcessors;
        /// <summary>
        /// Число логических процессоров
        /// </summary>
        public int NumberOfLogicalProcessors
        {
            get { return _numberOfLogicalProcessors; }
            private set
            {
                _numberOfLogicalProcessors = value;
                NotifyChanged("NumberOfLogicalProcessors");
            }
        }
        #endregion

        #region Name
        private string _name;
        /// <summary>
        /// Наименование процессора
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value.Trim();
                NotifyChanged("Name");
            }
        }
        #endregion

        #region GetProcessorInfo
        /// <summary>
        /// Получение информации о процессоре
        /// </summary>
        public void GetProcessorInfo()
        {
            _queryHelper.ExecuteQuery();
            var values = _queryHelper.GetValuesFirst(GlColumn.CPU_NumberOfCores, GlColumn.CPU_NumberOfLogicalProcessors, GlColumn.CPU_Name);
            NumberOfCores = (int)Convert.ChangeType(values[GlColumn.CPU_NumberOfCores], typeof(int));
            NumberOfLogicalProcessors = (int)Convert.ChangeType(values[GlColumn.CPU_NumberOfLogicalProcessors], typeof(int));
            Name = (string)Convert.ChangeType(values[GlColumn.CPU_Name], typeof(string));            
        }
        #endregion

        #region конструктор класса
        public CPUInfo(string deviceID) 
        {
            _queryHelper = new QueryHelper();
            _queryHelper.SetScope(GlScope.RootCIMV2);
            _queryHelper.SetQuery(string.Format(GlQuery.GetProcessorInfo, deviceID));
            _numberOfCores = 0;
            _numberOfLogicalProcessors = 0;
            _name = string.Empty;
            _deviceID = deviceID;
        }
        #endregion

        #region реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}
