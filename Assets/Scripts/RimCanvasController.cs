using System;
using UnityEngine;

public class RimCanvasController : MonoBehaviour
{
    public Action OnNextRim;
    public Action OnPreviousRim;
    [SerializeField] private GameObject buttonPanel;

    public void ActivateButtonPanel(bool value)
    {
        buttonPanel.SetActive(value);
    }
    public void NextRim()
    {
        OnNextRim?.Invoke();
    }
    
    public void PreviousRim()
    {
        OnPreviousRim?.Invoke();
    }
}
