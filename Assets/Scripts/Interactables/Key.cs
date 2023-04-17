using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static Action OnKeyPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
            PlayerInteractionHandler.OnPlayerInteracted += InteractedWithKey;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
            PlayerInteractionHandler.OnPlayerInteracted -= InteractedWithKey;
    }

    private void InteractedWithKey()
    {
        OnKeyPickedUp?.Invoke();
        PlayerInteractionHandler.OnPlayerInteracted -= InteractedWithKey;
        SoundManager.OnPlaySoundEffects?.Invoke(SoundType.KeyPickUp, false);
        gameObject.SetActive(false);
    }
}