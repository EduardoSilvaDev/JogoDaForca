using Newtonsoft.Json;

namespace jogodaforca
{
    public class Game
    {
        public Boneco boneco = new Boneco();
        public int errors;
        public List<char> letras = new List<char>();
        public char[] PalavraUsuario;
        public List<string> LetrasErradas = new List<string>();
        public string palavra;
        public string categoria;

        public Game()
        {
            // palavra = PalavraAleatoria().ToUpper();
            (categoria,palavra)=EscolhendoPalavra();
            PalavraUsuario = new char[palavra.Length];
            for(int i=0;i<palavra.Length;i++)
            {
                if(palavra.ToArray()[i] == ' ')
                    PalavraUsuario[i]+=' ';
                else 
                    PalavraUsuario[i]+='_';
            }

            errors = 0;
            while(true)
            {
                string palavraAuxiliar = new String(PalavraUsuario);
                Layout();
                EspacosLetras();
                //dicas
                // Console.SetCursorPosition(40,1);Console.Write(categoria.ToUpper());
                // Console.SetCursorPosition(40,1);Console.Write(palavra.ToUpper());
                if(errors==6)
                {
                    GameOver(false);
                    break;
                }
                if(palavraAuxiliar == palavra){
                    GameOver(true);
                    break;
                }
                tentativa();
            }
        }
        public void Layout()
        {
            try{Console.Clear();}catch(Exception){}
            ShowForca();
            boneco.ShowToy(errors);
        }
        public void ShowForca()
        {
            try
            {
                Console.Write
                (   
                    Cores.Amarelo(
                        "\n  |========"+
                        "\n  ||      |"+
                        "\n  ||"+
                        "\n  ||"+
                        "\n  ||"+
                        "\n  ||"+
                        "\n__||__________"
                    )
                );
            }catch(Exception){}
        }

        public void EspacosLetras()
        {
            try
            {
                Console.SetCursorPosition(20,1);
                Console.Write(Cores.Verde("Adivinhe a palavra"));
                Console.SetCursorPosition(20,2);
                Console.Write(Cores.Verde(Cores.Preto($"Dica: {categoria}")));
            }catch(Exception){}
            
            try
            {
                Console.SetCursorPosition(20,4);
                Letras();
            }catch(Exception){}
            
            try
            {
                Console.SetCursorPosition(20,6);
                Console.Write(Cores.Verde("Letras Erradas: ") + Cores.Vermelho(string.Join(", ",LetrasErradas)));
            }catch(Exception){}
        }
        public void Letras()
        {
            foreach(char c in PalavraUsuario.ToArray())
            {
                if(c == '_')Console.Write(Cores.Preto($" {c} "));
                else Console.Write($" {c.ToString().ToUpper()} ");
            }
        }
        public void tentativa()
        {
            string? letra="";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            while(string.IsNullOrEmpty(letra)||letra.Length>1){
                try{Console.SetCursorPosition(20,5);}catch(Exception){}
                Console.Write("> ");
                letra = Console.ReadLine()?.ToUpper()??"";
                if(!alphabet.Contains(letra.ToUpper())||letra.Length!=1)
                {
                    for(int i=0;i<letra.Length;i++)
                    {
                        try{Console.SetCursorPosition(22+i,5);}catch(Exception){}
                        Console.Write(" ");
                    }
                    letra="";
                    Console.SetCursorPosition(20,7);
                    Console.Write(Cores.Vermelho("Somente LETRAS!"));
                }
                // if(!alphabet.Contains(letra))letra="";
            }

            
            if(!palavra.Contains(letra)&&!LetrasErradas.Contains(letra))
            {
                errors++;
                LetrasErradas.Add(letra);
                return;
            }
            else
            {
                for(int i=0; i< palavra.Length; i++)
                {
                    if(Convert.ToChar(letra) == palavra[i])
                    {
                        PalavraUsuario[i] = Convert.ToChar(letra);
                    }
                }
                
            }
        }
        public void GameOver(bool Win_Lose)
        {
            try{Console.SetCursorPosition(60,2);}catch(Exception){}
            Console.Write((Win_Lose)?Cores.Azul("VOCE ACERTOU!!"):Cores.Vermelho("VOCE PERDEU!"));
            Console.ReadLine();
        }
        public (string,string) EscolhendoPalavra()
        {
            // Ler o arquivo JSON
            string jsonText = File.ReadAllText("Palavras.json");

            // Converter o JSON em um objeto C#
            dynamic? data = JsonConvert.DeserializeObject(jsonText);

            // Obter as chaves do objeto JSON
            List<string> keys = new List<string>();
            if(data != null)
                foreach (var key in data)
                {
                    keys.Add(key.Name);
                }

            // Selecionar aleatoriamente uma das chaves
            Random rnd = new Random();
            int keyIndex = rnd.Next(keys.Count);
            string selectedKey = keys[keyIndex];

            // Selecionar aleatoriamente uma palavra da array correspondente à chave selecionada
            int wordIndex=0;
            string selectedWord="";
            if(data != null)
            {
                wordIndex = rnd.Next(data[selectedKey].Count);
                selectedWord = data[selectedKey][wordIndex];
            }

            // Imprimir as strings selecionadas
            Console.WriteLine("Array selecionada: " + selectedKey);
            Console.WriteLine("Palavra selecionada: " + selectedWord);

            // palavra = Convert.ToString(selectedWord);
            // categoria = Convert.ToString(selectedKey);
            return (selectedKey.ToUpper(),selectedWord.ToUpper());
        }
    }
}