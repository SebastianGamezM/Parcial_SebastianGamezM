using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private float velocidadHorizontal;
    public Transform limite;
    private GameManager gameManager;
    private bool puntoConseguido;
    private LayerMask playerLayer;
    private float distanciaRaycast = 20;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        playerLayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - velocidadHorizontal * Time.deltaTime);

        if(transform.position.z <= limite.position.z )
        {
            Destroy(gameObject);
        }

        if(Physics.Raycast(transform.position + Vector3.up * 5, Vector3.down, distanciaRaycast, playerLayer) && !puntoConseguido)
        {
            gameManager.SumarPuntos();
            puntoConseguido = true;
        }

        if(!gameManager.juegoActivo)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + Vector3.up * 5, Vector3.down * distanciaRaycast);
    }
}
    