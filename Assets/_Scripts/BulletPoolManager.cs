using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
   // public BulletController bulletCon;

    public int max_bullets;

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> bulletQueue;

    // Start is called before the first frame update
    void Start()
    {
        bulletQueue = new Queue<GameObject>();
        // bulletCon.manager = this;
        // TODO: add a series of bullets to the Bullet Pool
        BuildBulletPool();
        //USED FOR TESTING
       // print(BulletPoolSize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Transform bSpawn)
    {
        if (CheckQueue()) {
            GameObject temp = bulletQueue.Dequeue();
            temp.SetActive(true);
            temp.transform.position = bSpawn.position;
            //Instantiate(bullet, bSpawn.position, Quaternion.identity);
            return temp;
        }
        else {
            return bullet;
        }
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bulletQueue.Enqueue(bullet);
        bullet.SetActive(false);
    }

    //Creates the bullet queue
    private void BuildBulletPool()
    {
        for (int i = 0; i < max_bullets; i++)
        {
            GameObject temp = Instantiate(bullet, new Vector3(-10.0f, 0.0f, 0.0f), Quaternion.identity);
            temp.SetActive(false);
            bulletQueue.Enqueue(temp);
        }
    }

    //Returns the size of the queue
    public int BulletPoolSize()
    {
        return bulletQueue.Count;
    }

    //Checks if the queue is greater than 0
    public bool CheckQueue()
    {
        if (BulletPoolSize() > 0) {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
