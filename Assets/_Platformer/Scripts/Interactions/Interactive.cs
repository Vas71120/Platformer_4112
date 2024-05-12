using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    public int Priority { get; }
    public void Interact(Interactor interactor);
    public bool CanInteractWith(Interactor interactor);
}
