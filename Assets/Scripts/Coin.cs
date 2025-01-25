using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Material _originalMaterial;
    [SerializeField] private Material _highlightMaterial;
    [SerializeField] private MeshRenderer _mesh;

    public void Highlight()
    {
        _mesh.material = _highlightMaterial;
    }

    public void OriginalMaterial()
    {
        _mesh.material = _originalMaterial;
    }
}
