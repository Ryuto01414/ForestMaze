using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Switchのワープに関するプログラム
public class SwitchWarp : MonoBehaviour, IInteractive
{
    [SerializeField] Warp switchWarpOut;

    public void Interact()
    {
        switchWarpOut.WarpOut();
    }
}
