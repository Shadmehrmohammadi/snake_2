using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class snake : MonoBehaviour
{
    
    //int point = 0;
    bool eat = false;
    //bool isDead = false;
    public GameObject tailPrefab;
    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    void Start()
    {
        InvokeRepeating("Move",0.5f,0.5f);
    }

    
    void Update()
    {
        
        if(Input.GetKey(KeyCode.D))
        {
            dir = Vector2.right;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            dir = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            dir = Vector2.down;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            dir = Vector2.up;
        }
        
        else
        {
            if(Input.GetKey(KeyCode.R))
            {
                tail.Clear();
                transform.position = new Vector3(0, 0, 0);
                //isDead = false;
            }
        }
    }
    void  Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if(eat)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab,v,Quaternion.identity);
            tail.Insert(0,g.transform);
            eat = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0,tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name.StartsWith("Food"))
        {
            eat = true;
            //point ++;
            Destroy(coll.gameObject);
        }
        //else
        //{
            //isDead = true;
        //}
    }
 
}
 