using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemigos;
    [SerializeField] private List<Transform> puntosDeSpawn;

    [SerializeField] TMP_Text tmp_text;
    [SerializeField] UnityEvent onPlayerDie;
    public int score=0;
    public float contador=0;
    float tiempoEntreEnemigos = 1.05f;
    [SerializeField] PlaneController player;
    [SerializeField] TMP_Text tmp;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemigo", tiempoEntreEnemigos, tiempoEntreEnemigos);
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador+1*Time.deltaTime;
        score = (int)contador;
        tmp_text.text = "Score: " + score;
        if (player.Life <= 0)
        {
            tmp.text = "Life: " + 0;
            onPlayerDie.Invoke();
        }
    }
    public void SpawnEnemigo()
    {
        int randomEnemigo=Random.Range(0, enemigos.Count);
        int randomSpawn=Random.Range(0, puntosDeSpawn.Count);
        Instantiate(enemigos[randomEnemigo], puntosDeSpawn[randomSpawn].position,Quaternion.identity);
    }
}
