using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Launcher : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Projectiles;
    [SerializeField] Transform Transform_ShootPos;
    [SerializeField] float _projectileSpeed;

    private XRGrabInteractable _grapInteractable;

    private void OnEnable()
    {
        _grapInteractable = this.GetComponent<XRGrabInteractable>();
        _grapInteractable.activated.AddListener(Fire);
    }

    private void OnDisable()
    {
        if (_grapInteractable != null)
        {
            _grapInteractable.activated.RemoveListener(Fire);
        }
    }

    public void Fire(ActivateEventArgs args)
    {
        GameObject newobj = Instantiate(Prefab_Projectiles, Transform_ShootPos.position, Transform_ShootPos.rotation);
        if (newobj.TryGetComponent(out Rigidbody rigidbody))
        { 
            ApplyForce(rigidbody);
        }
    }

    private void ApplyForce(Rigidbody rigidbody)
    {
        Vector3 force = Transform_ShootPos.forward * _projectileSpeed;
        rigidbody.AddForce(force);
    }
}
