using System;
using jogodaforca;
using Newtonsoft.Json;

namespace JogoDaForca
{
    class Program{
        static void Main(String[] args){
            try{Console.Clear();}catch(Exception){}
            
            Game game;
            while(true)
            {
                switch(menu()){
                    case 2:
                        Instrucoes();
                    break;
                    case 0:
                        Console.Clear();
                        Environment.Exit(0);
                    break;
                }
                game = new Game();
            }
        }
        static public int menu()
        {
            int op = -1;
            while(op<0||op>2)
            {
                try{
                    Console.Clear();
                }catch(Exception){}
                
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
    }
}