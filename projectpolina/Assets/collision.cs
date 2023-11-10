using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collision : MonoBehaviour
{
    public TextMeshProUGUI count;
    private int schot=6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Pole")
        {
            if (schot > 0)
            {
                count.text = "Осталось попаданий:" + (--schot);
            }
            else
            {
                count.text = "Хватит драться";
            }
        }
    }
}
