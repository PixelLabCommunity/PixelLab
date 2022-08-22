using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
    [SerializeField] private Image _objectFromDeviate;
    [SerializeField] private Image _arrow;

    public static event OnPercsentArrow PercsentArrow;
    public delegate void OnPercsentArrow(float percent);

    public static Arrow Instation;
    private float speedRotationArrow = 50.0f;
    
    public  Vector3 rotationArrow;
    
    public float percent;
    private float angleStar;
    public float angleCar ;

    private Vector2 vectorX;
    private Vector2 vectorY;
    void Start()
    {
        Instation = GetComponent<Arrow>();
        vectorX = new Vector2(transform.localPosition.x, _arrow.transform.position.y);
        vectorY = new Vector2(_objectFromDeviate.rectTransform.localPosition.y, _objectFromDeviate.rectTransform.localPosition.x);
        angleStar = Vector2.Angle(vectorX,vectorY);       
    }
    public void  RotationArrow(float z)
    {
        _arrow.gameObject.SetActive(true);
        rotationArrow +=  new Vector3(0,0,z) * speedRotationArrow * Time.deltaTime;
        if (rotationArrow.z >= -90 && rotationArrow.z <= 0)
        {
            transform.eulerAngles = rotationArrow;
            AngelDeviation();
        }
        else if (rotationArrow.z >= 0 && rotationArrow.z <= 90)
        {
            transform.eulerAngles = rotationArrow;
            AngelDeviation();
        }
    }
    void AngelDeviation()
    {
        if(vectorX.y == _arrow.transform.position.y)
        {
            percent = 100;
            PercsentArrow(percent);
        }
        else
        {
            Vector2 vectorDeviation = new Vector2(vectorX.x, vectorX.y - _arrow.transform.position.y);
            var angleDeviation = Vector2.Angle(vectorY, vectorDeviation);
            angleCar =angleStar - angleDeviation;
            percent = Mathf.Round(angleCar * 100 / 90);
            PercsentArrow(percent);
        }
    }
}
