using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public float waitforseconds;
    private int currentPointIndex = 0;
    bool Once = false;
    public Animator animator;
    float Lastpos;
    public MovementController movementController;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.5f;
    public GameObject[] spawnableItems;


    private void Start()
    {
       Lastpos = transform.position.x;
       var rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Lastpos < transform.position.x)
        {
            LeftTurn();
        }
        else
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        Lastpos = transform.position.x;

        if (transform.position != waypoints[currentPointIndex].position)
        {
            //Debug.Log(currentPointIndex);
            animator.SetBool("Walking", true);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndex].position, speed * Time.deltaTime);
            
        }
        else
        {
            animator.SetBool("Walking", false);
            
            if (Once == false)
            {
                
                Once = true;
              StartCoroutine(Wait());
            }

        }

    }

   private void LeftTurn()
    {

       transform.localScale = new Vector3(-3, 3, 3);

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitforseconds);
        if (currentPointIndex + 1 < waypoints.Length)
        {
          
            currentPointIndex++;
        }
        else
        {
           
            currentPointIndex = 0;
        }
        Once = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementController.DeathSequence();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            PowerUpFromEnemys();
            DisableEnemy();
        }
    }
    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
    public void PowerUpFromEnemys()
    {
        Debug.Log("FunctionCAlled");
        
        
            Debug.Log("Spawing");
            int randomIndex = Random.Range(0, spawnableItems.Length);
            Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);
        
    }

}
