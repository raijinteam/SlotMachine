using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolData : MonoBehaviour
{
    public int mySymbolIndex;   // this symbol of find wihich prosduct in game

    public SpriteRenderer spriteRenderer;
    public int Basevalue;   // this is base value of all product;
    public bool shouldDestroy = false;
    public bool shouldSynergy = false;
}
