using UnityEngine;

public class ControleVida : MonoBehaviour
{
    [Header("Configurações de Vida")]
    // Quantidade inicial de corações (ou vida do monstro)
    public int vidaMaxima = 3; 
    
    // A vida atual fica escondida para evitar bugs
    private int vidaAtual;

    [Header("Interface (Deixe vazio nos monstros)")]
    // Referência para o script que desenha os corações na tela
    public HUDVida hudVida; 

    void Start()
    {
        // Todo mundo começa com a vida cheia
        vidaAtual = vidaMaxima;
        
        // Atualiza a tela logo que o jogo começa, APENAS se for o Player
        if (hudVida != null && gameObject.CompareTag("Player")) 
        {
            hudVida.AtualizarCoracoes(vidaAtual);
        }
    }

    // Função para tomar dano (espinho, ataque de espada, etc)
    public void ReceberDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        
        // TRAVA DUPLA: Atualiza os corações na tela APENAS se for o Player
        if (hudVida != null && gameObject.CompareTag("Player"))
        {
            hudVida.AtualizarCoracoes(vidaAtual);
        }

        // Aviso no console para ajudar a gente a testar
        Debug.Log(gameObject.name + " tomou " + quantidadeDano + " de dano! Vida restante: " + vidaAtual);

        // Checa se a vida zerou
        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    // Função bônus para recuperar vida (poção, coração no chão)
    public void Curar(int quantidadeCura)
    {
        vidaAtual += quantidadeCura;
        
        // Garante que a cura não ultrapasse o limite máximo
        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        // Atualiza os corações na tela após curar, APENAS se for o Player
        if (hudVida != null && gameObject.CompareTag("Player"))
        {
            hudVida.AtualizarCoracoes(vidaAtual);
        }
    }

    // Função executada quando a vida chega a zero
    void Morrer()
    {
        Debug.Log(gameObject.name + " foi de base!");
        
        // Remove o objeto da cena (o monstro some do mapa)
        Destroy(gameObject);
    }
}