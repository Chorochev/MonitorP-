using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Данные о процессоре
    /// </summary>
    public class CPUInfo : BaseInfo
    {
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
                string newValue = value;
                if(_deviceID != newValue)
                {
                    _deviceID = newValue;
                    NotifyChanged("DeviceID");
                }
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
                int newValue = value;
                if (_numberOfCores != newValue)
                {
                    _numberOfCores = newValue;
                    NotifyChanged("NumberOfCores");
                }
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
                int newValue = value;
                if (_numberOfLogicalProcessors != newValue)
                {
                    _numberOfLogicalProcessors = newValue;
                    NotifyChanged("NumberOfLogicalProcessors");
                }
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
                string newValue = value;
                if (_name != newValue)
                {
                    _name = newValue;
                    NotifyChanged("Name");
                }
            }
        }
        #endregion

        #region GetProcessorInfo
        /// <summary>
        /// Получение информации о процессоре
        /// </summary>
        public void GetProcessorInfo(string deviceID = null)
        {
            ExecuteQuery();
            if (string.IsNullOrWhiteSpace(deviceID))
            {
                NumberOfCores = GetValueFirst<int>("NumberOfCores");
                NumberOfLogicalProcessors = GetValueFirst<int>("NumberOfLogicalProcessors");
                Name = GetValueFirst<string>("Name");
                DeviceID = GetValueFirst<string>("DeviceID");
            }
        }
        #endregion

        #region конструктор класса
        public CPUInfo() : base("root\\CIMV2", "SELECT * FROM Win32_Processor")
        {
            this._numberOfCores = 0;
            this._numberOfLogicalProcessors = 0;
            this._name = string.Empty;
            this._deviceID = string.Empty;
        }
        #endregion        
    }
}
