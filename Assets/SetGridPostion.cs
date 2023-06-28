using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGridPostion : MonoBehaviour
{
    [SerializeField] private Transform[] all_Frame;
    [SerializeField] private Transform[] all_Grid;
    [SerializeField] private float startX;
    [SerializeField] private float starty;
    [SerializeField] private float IncreasedX;
    [SerializeField] private float Increasedy;
    [ContextMenu("SetGrid")]

    public void SetGrid() {

        for (int i = 0; i < all_Frame.Length; i++) {


            all_Frame[i].localPosition = new Vector3(startX, starty, 0);
            all_Grid[i].localPosition = new Vector3(startX, starty, 0);

            starty += Increasedy;
            
            
            if ((i+1)%5==0) {
                startX += IncreasedX;
                starty  = -3;
            }
           
        }
    }
}
