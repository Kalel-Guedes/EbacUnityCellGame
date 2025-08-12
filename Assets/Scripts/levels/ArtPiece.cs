using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject currentObject;

    public void ChangePiece(GameObject piece)
    {
        if (currentObject != null) Destroy(currentObject);

        currentObject = Instantiate(piece, transform);
        currentObject.transform.localPosition = Vector3.zero;
    }
}
