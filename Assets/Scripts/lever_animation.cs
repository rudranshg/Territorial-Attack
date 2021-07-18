using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_animation : MonoBehaviour
{   
    public Animator anim;
    bool reached_lever = false;
    public bool time_over = false;
   // public GameObject GameOverImage;
    public float timer;
    public Player player;

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "Enemy"){
            reached_lever = true;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        //GameOverImage.SetActive(false);
    }

    void lever_over(){
        timer += Time.deltaTime;
        if(timer>=5f) {time_over = true;}
        //time end
        //true
    }
    // Update is called once per frame
    void Update()
    {
        if(reached_lever){
            anim.Play("lever_rotate");
            lever_over();
            if(time_over){
                player.DestroyObject();
            }
        }
    }
}
