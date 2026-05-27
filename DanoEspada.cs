using UnityEngine;

public class DanoEspada : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o que a espada tocou tem a tag "Inimigo"
        if (collision.CompareTag("Inimigo"))
        {
            // Tenta pegar o componente de vida do inimigo e causar 1 de dano
            VidaInimigo vida = collision.GetComponent<VidaInimigo>();
            if (vida != null)
            {
                vida.ReceberDano(1);
            }
        }
    }
}