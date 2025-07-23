using UnityEngine;

public class Player1 : MonoBehaviour
{
    

    public Transform target;
    public float lerpSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime );
        
    }
}
