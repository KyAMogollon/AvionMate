using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private Vector3 angulos;
    [SerializeField] private Quaternion qx = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    private float moveX;
    public float speedRotation;
    public float speed;
    public int daño = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z+speed*-1);
        moveX = moveX + Time.deltaTime * speedRotation;
        angulos.x = moveX*-1;

    }
    private void FixedUpdate()
    {
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);
        transform.rotation = qx;
    }
}
