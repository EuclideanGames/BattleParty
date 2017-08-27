using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class IsoObject : MonoBehaviour
{
    public Transform Target;
    public int TargetOffset;

    private const int IsoRangePerY = 100;
    private SpriteRenderer _sRenderer;

    private void Awake()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Target == null)
            Target = transform;
        _sRenderer.sortingOrder = -(int)(Target.position.y * IsoRangePerY) + TargetOffset;
    }
}
