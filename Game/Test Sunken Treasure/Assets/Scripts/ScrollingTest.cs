using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTest : MonoBehaviour
{
    //public GameObject land;
    private Renderer landRender;

    // Start is called before the first frame update
    void Start()
    {
        landRender = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollSpeed = 1;
        float offset =  (Time.time * scrollSpeed) / 1000.0f;
        landRender.material.SetTextureOffset("_BaseMap", new Vector2(offset, offset));
    }
}
