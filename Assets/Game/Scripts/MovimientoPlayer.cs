using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int fuerzaSalto;
    private bool isGrounded;
    private bool agachado;
    [SerializeField]private float alcanzeRaycast;
    private Vector3 escalaOriginal;
    [SerializeField] private LayerMask groundLayer;
    private GameManager gameManager;    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        escalaOriginal = transform.lossyScale;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if(gameManager.juegoActivo)
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, alcanzeRaycast, groundLayer);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
            else if (Input.GetKey(KeyCode.LeftControl) && isGrounded && !agachado)
            {
                Agacharse();
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && agachado)
            {
                Agacharse();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * fuerzaSalto);
        if (agachado)
        {
            agachado = false;
            transform.localScale = escalaOriginal;
        }
    }

    private void Agacharse()
    {
        agachado = !agachado;

        if (agachado)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        }
        else
        {
            transform.localScale = escalaOriginal;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstaculo"))
        {
            gameManager.Derrota();
            Debug.Log("Perdiste");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * alcanzeRaycast);
    }

}
