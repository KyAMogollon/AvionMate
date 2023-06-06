using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTierra : MonoBehaviour
{
    [SerializeField] private Vector3 angulos;
    [SerializeField] private Quaternion qx = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    private float moveX = 1;
    public float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX=moveX+Time.deltaTime*speedRotation;
        angulos.x= moveX *- 1;
    }
    void FixedUpdate()
    {
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);
        transform.rotation = qx;
    }
}
