using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();   
    }

    //void Update(){
    //    Respawn();
    //}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
            StartCoroutine(DisableApple());
            //Destroy(gameObject, 0.2f);
        }
    }

    //void Respawn()
    //{
    //    if(GameController.instance.totalScore == 150)
    //    {
    //        sr.enabled = true;
    //        circle.enabled = true;
    //        collected.SetActive(false);
    //    }
    //}

    IEnumerator DisableApple()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        sr.enabled = true;
        circle.enabled = true;
        collected.SetActive(false);
    }

}
