using UnityEngine;

public class SpawnerInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public Transform[] pontosSpawn; // Arraste vários objetos vazios para cá
    public float tempoEspera = 3f;
    public int limiteMaximo = 3;

    private GameObject ultimoInimigoCriado;
    private float cronometro;

    void Update()
    {
        // Conta quantos inimigos com a tag "Inimigo" existem na cena
        int totalInimigos = GameObject.FindGameObjectsWithTag("Inimigo").Length;

        // Regra: Menos que 3 na tela E o último já morreu
        if (totalInimigos < limiteMaximo && ultimoInimigoCriado == null)
        {
            cronometro += Time.deltaTime;

            if (cronometro >= tempoEspera)
            {
                Spawnar();
                cronometro = 0;
            }
        }
    }

    void Spawnar()
    {
        // Escolhe um ponto de spawn aleatório da sua lista
        int indiceAleatorio = Random.Range(0, pontosSpawn.Length);
        Transform ponto = pontosSpawn[indiceAleatorio];

        ultimoInimigoCriado = Instantiate(inimigoPrefab, ponto.position, Quaternion.identity);
    }
}