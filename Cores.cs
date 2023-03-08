namespace jogodaforca
{
    static public class Cores
    {
        static public string Preto(String STRING){
            return $"\x1b[30m{STRING}\x1b[0m";
        }
        static public string Vermelho(String STRING){
            return $"\x1b[31m{STRING}\x1b[0m";
        }
        static public string Verde(String STRING){
            return $"\x1b[32m{STRING}\x1b[0m";
        }
        static public string Amarelo(String STRING){
            return $"\x1b[33m{STRING}\x1b[0m";
        }
        static public string Azul(String STRING){
            return $"\x1b[34m{STRING}\x1b[0m";
        }
        static public string Roxo(String STRING){
            return $"\x1b[35m{STRING}\x1b[0m";
        }
        static public string AzulClaro(String STRING){
            return $"\x1b[36m{STRING}\x1b[0m";
        }
        static public string Branco(String STRING){
            return $"\x1b[37m{STRING}\x1b[0m";
        }   
    }
}