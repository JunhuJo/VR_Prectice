using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class Attacher : MonoBehaviour
{
    private IXRSelectInteractable _selcectInteractable;

    protected void OnEnable()
    {
        _selcectInteractable = this.GetComponent<IXRSelectInteractable>();
        if (_selcectInteractable as object == null)
        {
            Debug.LogError("Attacher Need SelectInterractable");
            return;
        }
        _selcectInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    

    protected void OnDisable()
    {
        if (_selcectInteractable as object != null)
        { 
            _selcectInteractable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    public void OnSelectEntered(SelectEnterEventArgs args) //
    {
        if (args.interactableObject is XRRayInteractor)
            return;

        var attachTransform = args.interactorObject.GetAttachTransform(_selcectInteractable);
        var origininAttachPos = args.interactorObject.GetAttachTransform(_selcectInteractable);
    }
}
