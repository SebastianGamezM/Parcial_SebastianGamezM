using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private SpawnearObstaculos scriptSpawn;
    public bool juegoActivo;
    public int puntos;
    public GameObject canvasPlay;
    private AudioSource[] audioSources;
    public TextMeshProUGUI textMeshPuntos;

    [Header("Sonidos")]
    public AudioClip sonidoPunto;
    public AudioClip derrota;
    public AudioClip cancion;

    private void Start()
    {
        scriptSpawn = GetComponent<SpawnearObstaculos>();
        audioSources = GetComponents<AudioSource>();
        textMeshPuntos.text = "puntos = 0";
    }

    public void IniciarJuego()
    {
        Debug.Log("inciando el juego");
        StopAllCoroutines();
        juegoActivo = true;
        canvasPlay.SetActive(false);
        StartCoroutine(scriptSpawn.AparecerObstaculo());
        audioSources[0].clip = cancion;
        audioSources[0].Play();
        audioSources[0].loop = true;
    }

    public void SumarPuntos()
    {
       puntos++;
       textMeshPuntos.text = ("puntos = " + puntos);
        audioSources[1].clip = sonidoPunto;
        audioSources[1].Play();
    }

    public void Derrota()
    {
        juegoActivo = false;

        audioSources[0].clip = derrota;
        audioSources[0].Play();
        audioSources[0].loop = false;
        canvasPlay.SetActive(true);

        puntos = 0;
        textMeshPuntos.text = ("puntos = " + puntos);
    }
}
