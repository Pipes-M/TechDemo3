using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public bool isTarg;
    private bool isPressed;
    public GameObject targCirc;
    private GameObject player;
    private PlayerScript pScript;
    public GameObject panel;
    public Slider healhSlider;
    public float health = 250f;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pScript.pressing & !isPressed)
        {
            isTarg = false;
            panel.SetActive(false);
            targCirc.SetActive(false);
            pScript.target = null;
        }
        healhSlider.value = health/250;
        if (pScript.damage)
        {
            health -= 0.1f;
        }
    }

    private void OnMouseDown()
    {
        isTarg = true;
        isPressed = true;
        pScript.target = gameObject;
        panel.SetActive(true);
        targCirc.SetActive(true);
        pScript.target = gameObject;
    }

    private void OnMouseUp()
    {
        isPressed = false;
    }
}
