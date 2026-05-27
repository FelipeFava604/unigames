using UnityEngine;

public class InimigoEstatico : MonoBehaviour
{
    public GameObject foicePrefab;
    public float intervaloAtaque = 2f;
    private Transform jogador;

    void Start()
    {
        // Busca o jogador pela Tag
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        // Começa a atirar repetidamente
        InvokeRepeating("Atacar", 1f, intervaloAtaque);
    }

    void Atacar()
    {
        if (jogador != null)
        {
            Instantiate(foicePrefab, transform.position, Quaternion.identity);
        }
    }
}