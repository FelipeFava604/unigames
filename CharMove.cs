using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    // Variáveis que vão aparecer no Inspector do Unity para você ajustar
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    // Referência para o corpo físico do personagem
    private Rigidbody2D rb;
    private bool noChao = true; // Para evitar que ele pule infinitamente no ar

    void Start()
    {
        // Pega o componente Rigidbody2D que você acabou de colocar no personagem
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. MOVIMENTO HORIZONTAL
        // O "Horizontal" reconhece as setas Esquerda/Direita ou as teclas A/D automaticamente
        float direcao = Input.GetAxisRaw("Horizontal"); 
        
        // Mantém a velocidade de queda (y) intacta, mas altera a velocidade lateral (x)
        rb.linearVelocity = new Vector2(direcao * velocidade, rb.linearVelocity.y);

        // 2. PULO
        // Verifica se apertou a setinha pra cima (ou espaço) E se está pisando no chão
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && noChao)
        {
            // Aplica a força do pulo no eixo Y
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            noChao = false; // Ele saiu do chão, então não pode pular de novo ainda
        }
    }

    // 3. DETECÇÃO DE CHÃO
    // Essa função do Unity é chamada automaticamente quando o Collider dele bate em outro Collider
    void OnCollisionEnter2D(Collision2D colisao)
    {
        // Se ele bateu em algo (o chão), ele pode pular de novo
        noChao = true;
    }
}