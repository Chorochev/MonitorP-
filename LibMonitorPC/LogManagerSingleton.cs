using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Менеджер логов
    /// </summary>
    public sealed class LogManagerSingleton : INotifyPropertyChanged
    {
        #region private _instanceLogManager, _journal, _visibleCountString
        private static LogManagerSingleton _instanceLogManager;
        /// <summary>
        /// Журнал сообщений
        /// </summary>
        private List<string> _journal;
        /// <summary>
        /// Количество видимых сообщений
        /// </summary>
        private ushort _visibleCountString;
        #endregion

        #region public VisibleCountString
        /// <summary>
        /// Количество видимых сообщений
        /// </summary>
        public ushort VisibleCountString
        {
            get { return _visibleCountString; }
            set { _visibleCountString = value; }
        }
        #endregion

        #region public VisibleCountString, JournalVisible, JournalAll, AddLog
        /// <summary>
        /// Получение менеджера логов
        /// </summary>
        /// <param name="visibleCountString">количество видимых сообщений</param>
        /// <returns></returns>
        public static LogManagerSingleton GetInstance(ushort visibleCountString = 10)
        {
            if (_instanceLogManager == null) _instanceLogManager = new LogManagerSingleton(visibleCountString);
            return _instanceLogManager;
        }       
        /// <summary>
        /// Видимая часть журнала
        /// </summary>
        public List<string> JournalVisible
        {
            get
            {
                int count = _journal.Count;
                int skip = count > VisibleCountString ? (count - VisibleCountString) : 0;
                return _journal.Skip(skip).Take(VisibleCountString).ToList();
            }
        }
        /// <summary>
        /// Весь журнал
        /// </summary>
        public List<string> JournalAll
        {
            get { return _journal; }
        }
        /// <summary>
        /// добавление сообщения в журнал
        /// </summary>
        /// <param name="message"></param>
        public void AddLog(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                _journal.Add(message);
                NotifyChanged("JournalVisible");
            }
        }
        #endregion

        #region Конструктор
        private LogManagerSingleton(ushort visibleCountString = 10)
        {
            _journal = new List<string>();
            VisibleCountString = visibleCountString;
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
