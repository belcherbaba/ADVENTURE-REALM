using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private AudioSource finishsound;
    private bool levelCompleted = false;
    // Start is called before the first frame update
    private void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Player" && !levelCompleted)
        {
            finishsound.Play();
            levelCompleted = true;
            Invoke("Completelevel",2f);
            
        }
    }
    private void Completelevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
