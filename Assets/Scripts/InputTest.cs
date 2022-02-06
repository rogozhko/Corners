using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private Manager manager;

    private void Start() {
        manager = Manager.Instance;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     manager.SetGameStateStart();
        // }

        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     manager.SetGameStatePlayerOneMove();
        // }
        //
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     manager.SetGameStatePlayerTwoMove();
        // }
        //
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     manager.SetGameStateResult();
        // }
    }
}
