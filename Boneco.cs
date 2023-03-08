using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogodaforca
{
    public class Boneco
    {
        public char head = 'O';
        public char handL = '/';
        public char handR = '\\';
        public char body = '|';
        public char legL = '/';
        public char legR = '\\';
        public void ShowToy(int errors)
        {
            string[] parts = {$" {head}",$"{handL}",$"{body}",$"{handR}",$"{legL}",$" {legR}"};
            for(int i=0; i< errors; i++)
            {
                
                if(i == 0)
                {
                    Console.SetCursorPosition(9,3);
                    Console.Write(Cores.Vermelho(parts[i]));
                }
                if(i==1)
                {
                    Console.SetCursorPosition(9,4);
                    Console.Write(Cores.Vermelho(parts[i]));
                }
                if(i==2)
                {
                    Console.SetCursorPosition(10,4);
                    Console.Write(Cores.Vermelho(parts[i]));
                }
                if(i==3)
                {
                    Console.SetCursorPosition(11,4);
                    Console.Write(Cores.Vermelho(parts[i]));
                }
                if(i==4)
                {
                    Console.SetCursorPosition(9,5);
                    Console.Write(Cores.Vermelho(parts[i]));
                }
                if(i==5)
                {
                    Console.SetCursorPosition(10,5);
                    Console.Write(Cores.Vermelho(parts[i]));
                }
            }
        }
    }
}