using UnityEngine;

public class MainMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}