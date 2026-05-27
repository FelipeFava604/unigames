using UnityEngine;

public class swordattack : MonoBehaviour
{
    [Header("Configurações do Ataque")]
    // Arraste o seu "swordPrefab" da pasta Project para cá
    public GameObject swordPrefab; 
    
    // O objeto vazio filho do jogador
    public Transform pontoDeAtaque; 
    
    // Tempo em segundos que a espada fica na tela (1 segundo, como pediu)
    public float tempoDeVida = 1f; 
    
    // Distância do centro do personagem até onde a espada nasce
    public float distanciaDoAtaque = 1f; 

    // Guarda a última direção apontada. Começa olhando para a direita (X:1, Y:0)
    private Vector2 ultimaDirecao = Vector2.right; 

    void Update()
    {
        // 1. CAPTURAR A DIREÇÃO DO MOVIMENTO
        // Lê as setas do teclado ou as teclas WASD
        float eixoX = Input.GetAxisRaw("Horizontal"); // Esquerda (-1) / Direita (1)
        float eixoY = Input.GetAxisRaw("Vertical");   // Baixo (-1) / Cima (1)

        // Se o jogador está se movendo (pressionou alguma tecla de direção)
        if (eixoX != 0 || eixoY != 0)
        {
            // Atualiza a memória da última direção
            // O .normalized serve para a diagonal não ter uma distância maior que a reta
            ultimaDirecao = new Vector2(eixoX, eixoY).normalized; 
        }

        // 2. EXECUTAR O ATAQUE
        // Verifica se a tecla Z foi pressionada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RealizarAtaque();
        }
    }

    void RealizarAtaque()
    {
        // CORREÇÃO AQUI: 
        // Usamos a Posição Global (transform.position) em vez do .localPosition.
        // Assim, a posição da espada é calculada no mundo, ignorando se o corpo do player virou ou não.
        pontoDeAtaque.position = transform.position + (Vector3)(ultimaDirecao * distanciaDoAtaque);

        // Calcula o ângulo em graus para girar a arte da espada
        float angulo = Mathf.Atan2(ultimaDirecao.y, ultimaDirecao.x) * Mathf.Rad2Deg;
        
        // Converte o ângulo para o formato de Rotação da Unity
        Quaternion rotacaoEspada = Quaternion.Euler(0, 0, angulo);

        // Instancia a espada na nova posição global calculada
        GameObject espadaCriada = Instantiate(swordPrefab, pontoDeAtaque.position, rotacaoEspada);

        // Destrói depois do tempo
        Destroy(espadaCriada, tempoDeVida);
    }
}