using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    public float speed;
    public string compareTag = "Enemy";
    public GameObject endScreen;

    private bool _canRun;
    void Start()
    {
        /*_canRun = true;*/
        endScreen.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == compareTag)
        {
            _canRun = false;
            endScreen.SetActive(true);
        }
    }

    void Update()
    {
        if (!_canRun) return;

        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastPosition.x);
        }

        pastPosition = Input.mousePosition;



        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
    public void StartRun()
    {
        _canRun = true;
    }
}
