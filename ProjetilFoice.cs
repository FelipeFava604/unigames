using UnityEngine;

public class ProjetilFoice : MonoBehaviour
{
    public float velocidade = 5f;
    public float velocidadeRotacao = 500f;
    public float tempoDeVida = 4f;
    public int danoDaFoice = 1; // Quanto de vida o player perde
    
    private Vector3 direcaoAlvo;

    void Start()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");
        if (jogador != null)
        {
            direcaoAlvo = (jogador.transform.position - transform.position).normalized;
        }
        
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // Move em linha reta e gira
        transform.position += direcaoAlvo * velocidade * Time.deltaTime;
        transform.Rotate(Vector3.forward * velocidadeRotacao * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Verifica se o que a foice tocou é o Player
        if (other.CompareTag("Player"))
        {
            // 2. Tenta pegar o script ControleVida que já está no player
            ControleVida vidaDoPlayer = other.GetComponent<ControleVida>();

            if (vidaDoPlayer != null)
            {
                // 3. Chama a função de receber dano que você já criou
                vidaDoPlayer.ReceberDano(danoDaFoice);
                
                // 4. Destrói a foice para ela não dar dano várias vezes no mesmo segundo
                Destroy(gameObject);
            }
        }
    }
}