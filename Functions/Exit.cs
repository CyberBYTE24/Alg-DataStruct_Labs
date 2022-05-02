using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class Exit : IFunctions
    {
        public int Number
        {
            get
            {
                return 8;
            }
        }
        public string Name
        {
            get
            {
                return "Выход";
            }
        }
        public GlobalCommand Command()
        {
            ExitFunc();
            return GlobalCommand.Exit;
        }
        static private void ExitFunc()
        {
            //throw new Exception();
            
        }
    }
}
