using UnityEngine;

public class RimTargetManager : MonoBehaviour
{
    [SerializeField] private DefaultObserverEventHandler modelTargetEventHandler;
    [SerializeField] private RimCanvasController rimCanvasController;
    
    [SerializeField] private Rim[] rims;
    private int rimIndex;
    
    private void OnEnable()
    {
        modelTargetEventHandler.OnTargetFound.AddListener(OnTargetFound);
        modelTargetEventHandler.OnTargetLost.AddListener(OnTargetLost);
        rimCanvasController.OnNextRim += OpenNextRim;
        rimCanvasController.OnPreviousRim += OpenPreviousRim;
    }

    private void OnDisable()
    {
        modelTargetEventHandler.OnTargetFound.RemoveListener(OnTargetFound);
        modelTargetEventHandler.OnTargetLost.RemoveListener(OnTargetLost);
        rimCanvasController.OnNextRim -= OpenNextRim;
        rimCanvasController.OnPreviousRim -= OpenPreviousRim;
    }

    void OnTargetFound()
    {
        ActivateRim(rimIndex);
        rimCanvasController.ActivateButtonPanel(true);
    }

    void OnTargetLost()
    {
        foreach (Rim rim in rims)
        {
            rim.Activate(false);
        }
        rimCanvasController.ActivateButtonPanel(false);
    }

    void OpenNextRim()
    {
        ActivateRim(rimIndex + 1);
    }
    
    void OpenPreviousRim()
    {
        ActivateRim(rimIndex - 1);
    }
    
    void ActivateRim(int index)
    {
        rimIndex = (index+rims.Length) % rims.Length;
        for (int i = 0; i < rims.Length; i++)
        {
            rims[i].Activate(i == rimIndex);
        }
    }
}
