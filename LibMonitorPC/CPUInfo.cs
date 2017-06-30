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
        #region NumberOfCores
        private int _numberOfCores;
        /// <summary>
        /// Число процессоров
        /// </summary>
        public int NumberOfCores
        {
            get { return _numberOfCores; }
            set
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
            set
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
            set
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
        /// Получение количества процессоров
        /// </summary>
        public void GetProcessorInfo()
        {
            ExecuteQuery();
            NumberOfCores = GetValueFirst<int>("NumberOfCores");
            NumberOfLogicalProcessors = GetValueFirst<int>("NumberOfLogicalProcessors");
            Name = GetValueFirst<string>("Name");
        }
        #endregion

        #region конструктор класса
        public CPUInfo() : base("root\\CIMV2", "SELECT * FROM Win32_Processor")
        {
            this._numberOfCores = 0;
            this._numberOfLogicalProcessors = 0;
            this._name = string.Empty;
        }
        #endregion        
    }
}
