using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float waitforseconds;
    private int currentPointIndex = 0;
    bool Once = false;
    public Animator animator;
    public MovementController movementController;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.5f;
    public GameObject[] spawnableItems;


    private void Start()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
       
        if (transform.position != waypoints[currentPointIndex].position)
        {
            animator.SetBool("Appear", false);
           //Animation will call Transform.
           
        }
        else
        {
           

            if (Once == false)
            {

                Once = true;
                StartCoroutine(Wait());
            }

        }

    }

    private void TransformPostion()
    {
        transform.position = waypoints[currentPointIndex].position;
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
    public void AppearAnim()
    {
        TransformPostion();
        animator.SetBool("Appear", true);
    }

}
