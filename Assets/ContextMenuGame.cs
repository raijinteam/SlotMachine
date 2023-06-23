using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuGame : MonoBehaviour
{
    public RectTransform[] all_Header;
    private float flt_anchorMinX = 0.08f;
    private float flt_anchorMinY = 0.8f; 
    private float flt_anchorMaxX = 0.92f;
    private float flt_anchorMaxY = 0.9f;

    [ContextMenu("Set All Header positions")]
    public void SetHeaderPosition() {

        for(int i = 0; i < all_Header.Length; i++) {
            all_Header[i].anchorMin = new Vector2(flt_anchorMinX, flt_anchorMinY);
            all_Header[i].anchorMax = new Vector2(flt_anchorMaxX, flt_anchorMaxY);
        }
    }
}
