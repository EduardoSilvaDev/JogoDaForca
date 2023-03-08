using System;
using jogodaforca;
using jogodaforca.Palavras;
using Newtonsoft.Json;

namespace JogoDaForca
{
    class Program{
        //falta tirar os espacos da palavras maiores
        static void Main(String[] args){
            Console.Clear();
            Game game;
            while(true)
            {
                switch(menu()){
                    case 1:
                        game = new Game();
                    break;
                    case 2:
                        Instrucoes();
                        game = new Game();
                    break;
                    case 0:
                        Environment.Exit(0);
                    break;
                }
                Again();
            }
            
        }
        static public int menu()
        {
            int op = -1;
            while(op<0||op>2)
            {
                Console.Clear();
                Console.WriteLine($"{Cores.Verde("Bem Vindo ao ")}{Cores.Amarelo("Jogo da Forca\n")}");
                Console.WriteLine(Cores.Verde("1 - Comecar"));
                Console.WriteLine(Cores.Verde("2 - Instruções"));
                Console.WriteLine(Cores.Verde("0 - Sair"));
                Console.Write(Cores.Amarelo("> "));
                try{
                    op = Convert.ToInt32(Console.ReadLine());
                }catch(Exception){}
                if(op==1)break;
            }
            return op;
        }
        static void Instrucoes()
        {
            Console.Clear();
            Console.Write(
                Cores.Amarelo("\t\t\tInstruções")+
                Cores.AzulClaro(
                    "\n\tVoce deverá digitar a letra correta para"+
                    "\n\tcompletar a palavra que preenche os espacos"+
                    "\n\tvazios. A cada erro é desenhado uma parte"+
                    "\n\tdo bonequinho. Seu objetivo é tentar digitar"+
                    "\n\ttodas as letras que completam a palavra."+
                    "\n\tEvite cometer muitos erros se não você vai perder o jogo\n\n"
                )+
                Cores.Preto("\tPRESSIONE QUALQUER TECLA PARA JOGAR")
            );
            Console.ReadLine();
        }
        static void Again()
        {
            while(true)
            {
                int op=0;
                Console.Clear();
                try
                {
                    Console.WriteLine(Cores.Verde("Jogar de novo?\n"));
                    Console.WriteLine(Cores.Azul("1 - Sim"));
                    Console.WriteLine(Cores.Vermelho("2 - Não"));
                    Console.Write(Cores.Amarelo("> "));
                    op = Convert.ToInt32(Console.ReadLine());
                }catch(Exception){op=0;}
                if(op == 1)break;
                else 
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
        }
    }
}