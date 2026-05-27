using UnityEngine;
using TMPro; // Importante para o TextMeshPro
using UnityEngine.UI;

public class HUDVida : MonoBehaviour
{
    public Image[] coracoes; // Array de imagens que você já tem
    public TextMeshProUGUI textoVida; // ARRASTE O NOVO TEXTO PARA CÁ

    // Esta é a função que o seu ControleVida já chama
    public void AtualizarCoracoes(int vidaAtual)
    {
        // Atualiza o Numeral (Ex: "Vida: 3")
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vidaAtual;
        }

        // Continua atualizando os corações (se eles estiverem lá)
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (i < vidaAtual)
            {
                coracoes[i].enabled = true;
            }
            else
            {
                coracoes[i].enabled = false;
            }
        }
    }
}