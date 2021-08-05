using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OnStart_ToggleOnOff : MonoBehaviour
{
    private enum Destination { toTurnOn, toTurnOff};
    [SerializeField] private Destination destination = Destination.toTurnOn;
    [SerializeField] private GameObject objectToManipulate;
    [SerializeField] private bool runScript;

    private void Awake()
    {
        switch(destination)
        {
            case Destination.toTurnOn:
                objectToManipulate.SetActive(true);
                break;

            case Destination.toTurnOff:
                objectToManipulate.SetActive(false);
                break;

            default:
                Debug.Log("<script_ToggleOnOff>: unsupported destination.");
                break;
        }
    }

}
