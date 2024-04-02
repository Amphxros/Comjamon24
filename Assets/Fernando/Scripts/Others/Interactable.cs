using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public abstract void Interact(Player myInteractor);

    public void ToggleInteractionState(bool state);
}
