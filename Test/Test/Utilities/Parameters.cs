using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;


namespace Test.Utilities
{
    public class Parameters
    {
        private string _content;
        private Dictionary<string, object> _dictonary;

        /// <summary>
        /// Crea una nuova istanza dell'oggetto Parameters.
        /// </summary>
        public Parameters()
        {
            _content = string.Empty;
            _dictonary = new Dictionary<string, object>();
        }

        /// <summary>
        /// Crea una nuova istanza dell'oggetto Parameters, aggiungendo già il Token.
        /// </summary>
        /// <param name="Token">Il Token della sessione attuale.</param>
        public Parameters(string Token)
        {
            _content = "token=" + Token + "&";
        }

        public void AddParameter(string key, object value)
        {
            if (value != null)
            {
                _dictonary.Add(key, value);
                if (!string.IsNullOrEmpty(value.ToString()))
                {                   
                    _content += key + "=" + value + "&";
                }                
            }            
        }

        public StringContent GetContent()
        {
            var jsonContent = JsonConvert.SerializeObject(_dictonary, Formatting.None); 
            Debug.WriteLine("> " + jsonContent);
            StringContent returnedValue = new StringContent(jsonContent, Encoding.UTF8, "application/json");           
            return returnedValue;
        }
    }
}
