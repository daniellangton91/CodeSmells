using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells
{
    internal class ConsoleIO : IUI
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public void PutString(string input)
        {
            Console.WriteLine(input);
        }
    }
}
