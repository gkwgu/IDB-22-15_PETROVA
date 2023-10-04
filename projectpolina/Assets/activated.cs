using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activated : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start_obj1()
    {
        flag = object1.activeSelf;
        object1.SetActive(!flag);
    }
    public void start_obj2()
    {
        flag = object2.activeSelf;
        object2.SetActive(!flag);
    }
}
