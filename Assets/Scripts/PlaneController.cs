using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private Vector3 angulos;
    [SerializeField] private Quaternion qx= Quaternion.identity;
    [SerializeField] private Quaternion qy= Quaternion.identity;
    [SerializeField] private Quaternion qz= Quaternion.identity;

    [SerializeField] private Quaternion r= Quaternion.identity;

    [SerializeField] private AsteroidController asteroid;
    [SerializeField] private TMP_Text tmp_text;
    public float horizontal;
    public float vertical;
    private float anguloSen;
    private float anguloCos;
    public int speed;
    public int speedRotation;
    public float ImpulsoZ=1;
    public float ImpulsoX=1;
    private Rigidbody _rb;
    public int Life=3;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        tmp_text.text = "Life: " + Life;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -250, 250), Mathf.Clamp(transform.position.y, -150, 150));

        if (horizontal < 0)
        {
            if (angulos.z<35)
            {
                ImpulsoZ = ImpulsoZ + Time.deltaTime * speedRotation;
                angulos.z = ImpulsoZ;
            }
        }else if (horizontal==0)
        {
            ImpulsoZ = 0;
            angulos.z = ImpulsoZ;
        }
        else if(horizontal > 0)
        {
            if (angulos.z > -35)
            {
                ImpulsoZ = ImpulsoZ + Time.deltaTime * speedRotation;
                angulos.z = ImpulsoZ * -1;
            }
        }
        if(vertical < 0)
        {
            if (angulos.x < 35)
            {
                ImpulsoX= ImpulsoX + Time.deltaTime * speedRotation;
                angulos.x= ImpulsoX;
            }
        }else if(vertical == 0)
        {
            ImpulsoX = 0;
            angulos.x=ImpulsoX;
        }
        else if (vertical > 0)
        {
            if(angulos.x > -35)
            {
                ImpulsoX=ImpulsoX + Time.deltaTime * speedRotation;
                angulos.x = ImpulsoX * -1;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MovePlane();
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * qx * qz;

        transform.rotation = r;
    }
    private void MovePlane()
    {
        _rb.velocity = new Vector3(horizontal * speed, vertical * speed);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Life=Life-asteroid.daño;
        }
    }
}
