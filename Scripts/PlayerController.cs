using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp1"){
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText ();
        }
        else if(other.gameObject.tag == "PickUp2"){
            other.gameObject.SetActive(false);
            count += 3;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count:" + count.ToString();

        if (count >= 9)
        {
            countText.gameObject.SetActive(false);
            winText.gameObject.SetActive(true);
            count = 0;
        }
    }
}
