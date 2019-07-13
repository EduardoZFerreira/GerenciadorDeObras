using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.Entities
{
    public class State
    {
        public bool HasError { get; private set; }
        public bool HasWarning { get; private set; }
        public string ErrorMessage { get; private set; }
        public string WarningMessage { get; private set; }

        public State SetError(string message)
        {
            HasError = true;
            ErrorMessage = message;
            return this;
        }

        public State SetWarning(string message)
        {
            HasWarning = true;
            WarningMessage = message;
            return this;
        }


    }
}
