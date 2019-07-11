using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLAdo
{
    public class Command
    {
        private Dictionary<string, object> _parameters;
        private string _commandText;
        private bool _IsStoredProcedure;

        public Dictionary <string, object> parameters {get; set;}
        public string commandText {get ; set ;}
        public bool IsStoredProcedure { get; set; }

        public Command(string commandText, bool isStoredProcedure)
        {
            if(string.IsNullOrWhiteSpace(commandText))
            {
                throw new Exception("La requête est invalide");
            }
            _commandText = commandText;
            _IsStoredProcedure = isStoredProcedure;
            _parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string nom, object value)
        {
            _parameters.Add(nom, (value==null)? DBNull.Value:value);
        }
               
    }
}
