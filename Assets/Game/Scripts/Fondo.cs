using UnityEngine;

public class FondoLoopeable : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    private float ancho;
    private Vector3 posicionInicial;

    public Sprite[] imagenes;
    private SpriteRenderer spriteRenderer;

    private GameManager gameManager;
    void Start()
    {
        posicionInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ancho = spriteRenderer.bounds.size.z; // Obtiene el ancho exacto del sprite
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if(gameManager.juegoActivo)
        {
            // Mueve el fondo hacia la izquierda
            transform.position += Vector3.back * velocidad * Time.deltaTime;

            // Si el fondo se mueve completamente fuera de la pantalla, lo reposiciona instantáneamente a la derecha del otro fondo
            if (transform.position.z <= posicionInicial.z - ancho)
            {
                transform.position = posicionInicial;
                cambiarImagen();
            }
        }
    }

    private void cambiarImagen()
    {
        int numeroRandom = Random.Range(0, imagenes.Length);
        spriteRenderer.sprite = imagenes[numeroRandom];
        ancho = spriteRenderer.bounds.size.z;
    }
}