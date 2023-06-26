using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBG : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer_BG;
    private void Update() {
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        Vector3 a = new Vector3(
            worldScreenWidth / renderer_BG.bounds.size.x,
            worldScreenHeight / renderer_BG.bounds.size.y, 1);

        renderer_BG.transform.localScale = new Vector3(renderer_BG.transform.localScale.x * a.x, renderer_BG.transform.localScale.y * a.y,
            renderer_BG.transform.localScale.z * a.z);
    }

}
