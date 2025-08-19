using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    

   /* public GameObject graphicItem;

     public ParticleSystem particles;
     public AudioSource audio;*/




    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    /*private void HideObject()
    {
        
    }*/

    protected virtual void Collect()
    {
       
        
        /*if(graphicItem != null) graphicItem.SetActive(false);*/
        Debug.Log("Collect");
        OnCollect();
        /*Invoke("HideObject", 3f);*/
        gameObject.SetActive(false);
    }


    protected virtual void OnCollect()
    {
        /*if (particles != null) particles.Play();
        if (audio != null) audio.Play();*/
    }
    
}
