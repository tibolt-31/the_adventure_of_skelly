using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = new PlayerAnimation(GetComponent<Animator>());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Pushable" && anim.anim.GetFloat("speedh") > 0f)
        {
            anim.PlayIsPushing(true);
            var playerRotation = Mathf.Round(PlayerManager.instance.Player.transform.rotation.eulerAngles.y);

            switch (playerRotation)
            {
                case 0f:
                    collision.gameObject.transform.position += new Vector3(0, 0, 0.5f * Time.deltaTime);
                    break;
                case 90f:
                    collision.gameObject.transform.position += new Vector3(0.5f * Time.deltaTime, 0, 0);
                    break;
                case 180f:
                    collision.gameObject.transform.position += new Vector3(0, 0, -0.5f * Time.deltaTime);
                    break;
                case 270f:
                    collision.gameObject.transform.position += new Vector3(-0.5f * Time.deltaTime, 0, 0);
                    break;
            }
        }
        else if (anim.anim.GetFloat("speedh") == 0f)
        {
            anim.PlayIsPushing(false);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Pushable")
        {
            anim.PlayIsPushing(false);
        }
    }
}
