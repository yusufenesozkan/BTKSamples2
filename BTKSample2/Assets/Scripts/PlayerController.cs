using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    CurrentDirection cr;
    public bool isPayerDead = false;
    GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!isPayerDead)
        {
            RayCastDedector();
            if (Input.GetKeyDown("space"))
            {
                print("space basıldı");
                ChangeDirection();
                PlayerStop();
            }
        }
        else
        {
            return;
        }
        
       
        //MovePlayer();
        
    }
            

    private enum CurrentDirection
    {
        right, left
    }

    private void ChangeDirection()
    {
        if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
        else if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce(transform.right.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
            rb.AddForce(transform.forward.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void PlayerStop()
    {
        rb.linearVelocity = Vector3.zero; // Hatalı linearVelocity yerine velocity kullanıldı
    }
    private void RayCastDedector()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit)) 
        {
            MovePlayer();
        }
        else
        {
            PlayerStop();
            isPayerDead = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.NextLevel();
        }
    }
}