using System.Collections;
using UnityEngine;

//public class Road : MonoBehaviour
//{
//    public static Road Instation;
//    [SerializeField] private Rigidbody _rigidbodyCar;
//    private Vector3 transformCar;
//    private Vector3 startformCar;
//    public bool proverka;
//    public static event OnSwipeInput SwipeEvent;
//    public delegate void OnSwipeInput(bool speed);

//    private void Start()
//    {      
//        Instation = GetComponent<Road>();    
//    }
//    void OnTriggerStay(Collider collision)
//    {
//        transformCar = _rigidbodyCar.transform.position;
//    }
//    void  OnTriggerExit(Collider collision)
//    {
//        SwipeEvent(false);
//        StartCoroutine(WaitForReturng());            
//    }
//    IEnumerator WaitForReturng()
//    {       
//        yield return new WaitForSeconds(0.50f);
//        ReturCar();
//    }
//    void ReturCar()
//    {
//        _rigidbodyCar.transform.position = transformCar;
//        _rigidbodyCar.velocity = Vector3.zero;
//        proverka = false;
//    }


//}
