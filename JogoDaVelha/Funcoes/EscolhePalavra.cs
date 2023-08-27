using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace JogoDaVelha.Funcoes;

public class EscolhePalavra
{
    public class PalavrasJson
    {
        [JsonPropertyName("palavras")]
        public List<string>? Palavras { get; set; }
    }

    public string[] palavras;

    Random random = new Random();
    EsconderERevelar EsconderRevelar = new EsconderERevelar();

    public EscolhePalavra()
    {
        string jsonContent = File.ReadAllText("palavras.json");

        PalavrasJson DicionarioJson = JsonSerializer.Deserialize<PalavrasJson>(jsonContent);

        palavras = DicionarioJson?.Palavras.ToArray();
    }

    public void Jogo()
    {
        int sorteado = random.Next(0, palavras.Length);
        string palavraSorteada = palavras[sorteado];
        string palavraEscondida = EsconderRevelar.EsconderPalavraEscolhida(palavraSorteada);

        Console.WriteLine(palavraSorteada);

        Console.WriteLine($"A palavra tem {palavraSorteada.Length} letras.");
        Console.WriteLine("O jogo comecou. \nAdivinhe a palavra!");

        do
        {
            char letraChute = Console.ReadKey().KeyChar;

            if (palavraSorteada.Contains(letraChute))
            {
                int letraCorreta = palavraSorteada.IndexOf(letraChute);

                palavraEscondida = EsconderRevelar.RevelarLetra(palavraEscondida, palavraSorteada, letraChute);
                Console.WriteLine($"\nPalavra atualizada: " + palavraEscondida);

            }
            else
            {
                Console.WriteLine("\nA letra nao existe na palavra sorteada.");
            }
        }
        while (palavraEscondida.Contains('_'));

        Thread.Sleep(1000);
        Console.WriteLine("Voce ganhou! Parabens!");
        return;
    }
}

