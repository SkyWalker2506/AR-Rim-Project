using UnityEngine;

public class Rim : MonoBehaviour
{
    [SerializeField] private GameObject rimInside;
    [SerializeField] private GameObject rimOutside;

    public void Activate(bool value)
    {
        rimInside.SetActive(false);
        rimOutside.SetActive(false);
        if (value)
        {
            if (Vector3.Distance(rimInside.transform.position, Camera.current.transform.position) <
                Vector3.Distance(rimOutside.transform.position, Camera.current.transform.position))
            {
                rimInside.SetActive(true);
            }
            else
            {
                rimOutside.SetActive(true);
            }
        }
    }
    
    
}
