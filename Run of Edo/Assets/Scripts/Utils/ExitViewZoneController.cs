﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitViewZoneController : MonoBehaviour
{
    PlatformManager platformManager;
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        platformManager = Base.FindManager<PlatformManager>("PlatformManager");
    }

    // OnTriggerExit2D is called when the Collider2D other has stopped touching the trigger (2D physics only)
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroyable dest = collision.GetComponent<Destroyable>();
        if (dest != null)
        {
            dest.ExitDestroy();

        }
        else
        {
           // Destroy(collision.gameObject);
        }
    }

}
