using UnityEngine;
using System.Collections;


public class Car : MonoBehaviour
{
    private Rigidbody rigidbodyCar;
    private float speedRotationCar = 2.0f;
    Vector3 transformCar;


    void Start()
    {
        rigidbodyCar = GetComponent<Rigidbody>();
    }
    void OnTriggerStay(Collider collision)
    {
        StartCoroutine(WaitForReturng());
    }
    void OnTriggerExit(Collider collision)
    {
        rigidbodyCar.transform.position = transformCar;
        rigidbodyCar.velocity = Vector3.zero;
        //StartCoroutine(WaitForReturng());
        Debug.Log($"{rigidbodyCar.transform.position} - {transformCar}") ;
    }
    IEnumerator WaitForReturng()
    {
        yield return new WaitForSeconds(0.5f);
        Drive();
    }
    void ReturCar()
    {
        rigidbodyCar.velocity = rigidbodyCar.velocity - transformCar;
        rigidbodyCar.velocity = Vector3.zero;
       
    }
    void Drive()
    { 
            rigidbodyCar.velocity = transform.forward * InputConroler.Instation.speedcar;
            transformCar = rigidbodyCar.transform.position - rigidbodyCar.velocity;
             Debug.Log($" {transformCar}");
    }
    public void OnRotationCar(float y)
    {
        transform.Rotate(new Vector3(0,y* Arrow.Instation.angleCar,0) * speedRotationCar * Time.deltaTime);
    }
}
