using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Базовый класс информационных частей
    /// </summary>
    public class BaseInfo : INotifyPropertyChanged
    {
        private string scope;
        private string queryString;
        private ManagementObject ManagementObjectFirst;
        private ManagementObjectSearcher resultQuery;
        private LogManagerSingleton logs;

        #region protected ExecuteQuery, GetValueFirst
        /// <summary>
        /// Выполнение запроса
        /// </summary>
        protected void ExecuteQuery()
        {
            try
            {
                resultQuery = null;
                resultQuery = new ManagementObjectSearcher(scope, queryString);
                QueryResultFirst();
            }
            catch (Exception e)
            {
                logs.AddLog(string.Format("Error: {0}", e.ToString()));
            }
        }
        /// <summary>
        /// Получение результата из первой строки
        /// </summary>
        /// <typeparam name="T">тип значения</typeparam>
        /// <param name="name">наименование значения</param>
        /// <returns></returns>
        protected T GetValueFirst<T>(string name)
        {           
            if (ManagementObjectFirst != null)
                return GetValue<T>(ManagementObjectFirst, name);
            else
                return default(T);
        }
        /// <summary>
        /// Получение значение из определенного результата запроса
        /// </summary>
        /// <typeparam name="T">тип значения</typeparam>
        /// <param name="resultId">наименование идентификатора по которому определяется конкретный результат</param>
        /// <param name="resultValue">значение идентификатора по которому определяется конкретный результат</param>
        /// <param name="name">наименование значения</param>
        /// <returns></returns>
        protected T GetValue<T>(string resultId, string resultValue, string name)
        {
            if (resultQuery != null)
            {
                foreach (ManagementObject queryObj in resultQuery.Get())
                {
                    if((string)queryObj[resultId] == resultValue)
                    {
                        return GetValue<T>(queryObj, name);
                    }
                }
            }
            return default(T);
        }

        /// <summary>
        /// Количество результатов запроса
        /// </summary>
        /// <returns></returns>
        protected int QueryResulCount()
        {
            if (resultQuery != null)
            {
                return resultQuery.Get().Count;
            }
            return 0;
        }
        #endregion

        #region private QueryResultFirst, GetValue
        /// <summary>
        /// Получение результата запроса (Первое значение)
        /// </summary>
        /// <typeparam name="T">тип результата</typeparam>
        /// <param name="name">имя</param>
        /// <returns></returns>
        private void QueryResultFirst()
        {
            if (resultQuery != null)
            {
                foreach (ManagementObject queryObj in resultQuery.Get())
                {
                    ManagementObjectFirst = queryObj;
                    return;
                }
            }
        }

        /// <summary>
        /// Получение значения
        /// </summary>
        /// <typeparam name="T">тип значения</typeparam>
        /// <param name="data">объект с данными</param>
        /// <param name="name">наименование значения</param>
        /// <returns></returns>
        private T GetValue<T>(ManagementObject data, string name)
        {
            if (data != null)
            {
                if (data[name] != null)
                {
                    return (T)Convert.ChangeType(data[name], typeof(T));
                }
            }
            return default(T);
        }
        #endregion

        #region Конструктор
        public BaseInfo(string scope, string queryString)
        {
            this.scope = scope;
            this.queryString = queryString;
            logs = LogManagerSingleton.GetInstance();
        }
        #endregion

        #region реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}
