using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha.Funcoes;

public class EsconderERevelar 
{
    public string EsconderPalavraEscolhida(string palavra)
    {
        return new string('_', palavra.Length);
    }
    public string RevelarLetra(string palavraEscondida, string palavraSorteada, char letra)
    {
        char[] palavraArray = palavraEscondida.ToCharArray();
        for (int i = 0; i < palavraSorteada.Length; i++)
        {
            if (palavraSorteada[i] == letra)
            {
                palavraArray[i] = letra;
            }
        }
        return new string(palavraArray);
    }
}
