using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LibMonitorPC
{
    /// <summary>
    /// Класс для облегчения запросов к системе
    /// </summary>
    public sealed class QueryHelper
    {
        /// <summary>
        /// область видимости
        /// </summary>
        private string _scope;
        /// <summary>
        /// Запрос
        /// </summary>
        private string _query;
        /// <summary>
        /// Результат запроса
        /// </summary>
        private ManagementObjectSearcher _resultQuery;
        /// <summary>
        /// Логи
        /// </summary>
        private LogManagerSingleton logs;

        /// <summary>
        /// Установка области видимости
        /// </summary>
        /// <param name="scope">область видимости</param>
        /// <returns></returns>
        public QueryHelper SetScope(string scope)
        {
            if (!string.IsNullOrWhiteSpace(scope))
                _scope = scope.Trim();
            return this;
        }
        /// <summary>
        /// Установка запроса
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public QueryHelper SetQuery(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
                _query = query.Trim();
            return this;
        }
        /// <summary>
        /// Выполнение запроса
        /// </summary>
        public QueryHelper ExecuteQuery()
        {
            if (IsGoodQuery())
            {
                try
                {                    
                    _resultQuery = new ManagementObjectSearcher(_scope, _query);                    
                }
                catch (Exception e)
                {
                    logs.AddLog(string.Format("Error: {0}", e.ToString()));
                }
            }
            return this;
        }
        
        /// <summary>
        /// Проверка запроса
        /// </summary>
        /// <returns>true - запрос можно выполнить; false - запрос некорректный;</returns>
        public bool IsGoodQuery()
        {
            return (!string.IsNullOrWhiteSpace(_scope) && !string.IsNullOrWhiteSpace(_query));
        }
        
        /// <summary>
        /// Количество результатов запроса
        /// </summary>
        /// <returns></returns>
        public int QueryResulCount()
        {
            if (_resultQuery != null)
            {
                return _resultQuery.Get().Count;
            }
            return 0;
        }

        /// <summary>
        /// Коллекция результатов
        /// </summary>
        /// <param name="names">имена результатов</param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetValues(params string[] names)
        {
            int countParams = names.Count();
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>> ();
            if (_resultQuery != null)
            {
                // проходим по всем результатам 
                foreach (ManagementObject itemStr in _resultQuery.Get())
                {
                    var currentResult = new Dictionary<string, object>(countParams);
                    foreach (var itemValue in names)
                    {
                        currentResult.Add(itemValue, itemStr[itemValue]);
                    }
                    result.Add(currentResult);                    
                }
            }
            return result;
        }

        /// <summary>
        /// Коллекция результатов
        /// </summary>
        /// <param name="names">имена результатов</param>
        /// <returns></returns>
        public Dictionary<string, object> GetValuesFirst(params string[] names)
        {
            return GetValues(names).First();
        }

        #region Конструктор
        public QueryHelper()
        {
            logs = LogManagerSingleton.GetInstance();
        }
        #endregion


    }
}
