using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reloj : MonoBehaviour
{
    public GameObject texto;
    public float segundos = 300;
    public bool disminuyendo = true;
    bool on = true;
    public GameObject r;

    void Start()
    {
        texto.SetActive(false);
    }

    void Update()
    {
         if(disminuyendo==false && segundos > 0 && on == true)
        {
            disminuyendo = true;
            segundos -= Time.deltaTime;
            float minutos = Mathf.FloorToInt(segundos / 60);
            float displaysegundos = Mathf.FloorToInt(segundos % 60);
            texto.GetComponent<Text>().text = minutos + ":" + displaysegundos;
            disminuyendo = false;
        } 
        if (segundos == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("c_e"))
        {
            
            disminuyendo = false;
            texto.SetActive(true);
        }
        if (c.gameObject.CompareTag("c_s"))
        {
            disminuyendo = true;
            on = false;
        }
        if (c.gameObject.CompareTag("c_f"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (c.gameObject.CompareTag("ci_i"))
        {
            gameObject.transform.position = r.transform.position;
        }
    }


   
     
     
        
 

    
}
