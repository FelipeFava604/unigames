using UnityEngine;
using TMPro; // Se estiver usando TextMeshPro. Se for o Text comum, use using UnityEngine.UI;

public class GerenciadorPontos : MonoBehaviour
{
    public TextMeshProUGUI textoPontos; // Mude para public Text se for o legacy
    private int pontuacaoAtual = 0;

    void Start()
    {
        AtualizarInterface();
    }

    public void AdicionarPontos(int quantidade)
    {
        pontuacaoAtual += quantidade;
        AtualizarInterface();
    }

    void AtualizarInterface()
    {
        textoPontos.text = "Pontos: " + pontuacaoAtual;
    }
}