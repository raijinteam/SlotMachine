using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrainNoteRight : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    private int baseValue;

    private int vitalickSymboleIndex = 29;
    private int satoshiNakamotoIndex = 27;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;

        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }


    private void OnDisable() {

        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;

    }
    public void Instance_SetDestroyeObj() {


        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {


            if (satoshiNakamotoIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                Debug.Log("SatoshiNakanmoto");
                StartCoroutine(delayDestroy(this.gameObject));
                return;
            }

            if (vitalickSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                Debug.Log("vitalik");
                StartCoroutine(delayDestroy(this.gameObject));
                return;
            }


        }
    }

    private IEnumerator delayDestroy(GameObject vitalick) {
        yield return new WaitForSeconds(0.5f);
        GridManager.instance.RemoveGameObjectInList(vitalick);
    }

   
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }

}
