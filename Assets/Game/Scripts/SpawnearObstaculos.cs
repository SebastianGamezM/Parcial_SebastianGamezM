using System.Collections;
using UnityEngine;

public class SpawnearObstaculos : MonoBehaviour
{
    [SerializeField] private Transform[] spawns = new Transform[3];
    [SerializeField] private GameObject obstaculos;
    [SerializeField] private Transform limite;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(AparecerObstaculo());
    }
    public IEnumerator AparecerObstaculo()
    {
        int numeroRandom;

        while (gameManager.juegoActivo)
        {         
            numeroRandom = Random.Range(0, spawns.Length);          
            GameObject obstaculo = Instantiate(obstaculos, spawns[numeroRandom].position, Quaternion.identity);
            obstaculo.GetComponent<Obstaculos>().limite = limite;
            yield return new WaitForSeconds(1.5f);
        }
    }

}
