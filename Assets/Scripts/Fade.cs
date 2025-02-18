using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fades : MonoBehaviour
{
    private SpriteRenderer _rend;
    public float corrutineTime = 0.1f;
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(Fadeout()); //CallBack
        StartCoroutine(Fadein());
    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator Fadeout()
    {
        for (float alpha = 1; alpha > 0; alpha -= speed * Time.deltaTime)
        {
            Color newColor = _rend.color;
            newColor.a = alpha;
            _rend.color = newColor;


            yield return new WaitForSeconds(corrutineTime);
        }
        StartCoroutine(Fadein());
    }
    IEnumerator Fadein()
    {
        for (float alpha = 0; alpha < 1; alpha += speed * Time.deltaTime)
        {
            Color newColor = _rend.color;
            newColor.a = alpha;
            _rend.color = newColor;


            yield return new WaitForSeconds(corrutineTime);
        }
        StartCoroutine(Fadeout());
    }

}

    

