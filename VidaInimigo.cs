using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public int vida = 1;

    public void ReceberDano(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        // Procura o gerenciador de pontos na cena e adiciona 10 pontos
        GerenciadorPontos gp = FindObjectOfType<GerenciadorPontos>();
        if (gp != null)
        {
            gp.AdicionarPontos(10); // Você pode mudar o valor aqui
        }

        Destroy(gameObject);
    }
}