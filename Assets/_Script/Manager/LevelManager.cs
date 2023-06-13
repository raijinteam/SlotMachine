using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private Level[] all_Level;

    [SerializeField] private int spin;
    [SerializeField] private int totalSpin;
    [SerializeField] private float RentValue;
    [SerializeField] private float IncreasedPersentage;
    public Level CurrentLevel { get; private set; }
    public int CurrentLevelNo { get; set; }
    public int CurrentSpin { get; private set; }

    public int  CurrentLevelCollectedCoin { get; set; }
   

    private void Awake() {
        instance = this;
    }

    private void Start() {
       
        CurrentLevelNo = 1;
        CurrentLevel = all_Level[CurrentLevelNo-1];
        CurrentLevelCollectedCoin = 0;


    }

    public void IncresingSpin() {

       
        CurrentSpin++;
        spin = CurrentSpin;


        if (CurrentSpin>=CurrentLevel.SpinValue) {

            CurrentSpin = 0;
            if (GameManager.instance.Score>CurrentLevel.RentValue) {

                UiManager.instance.GetUiPayRentScreen.gameObject.SetActive(true);
                UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(false);
                UiManager.instance.GetUiPowerupScreen.IsLevelChangeTime = true;
            }
            else {
                UiManager.instance.GetGameoverScreen.gameObject.SetActive(true);
                UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(false);
            }


        }
        else {
            setpowerup();
        }

      
    }

    public void IncreasingLevel() {
        CurrentLevelNo++;

        if (CurrentLevelNo < all_Level.Length) {
            CurrentLevel = all_Level[CurrentLevelNo - 1];
        }
        else {
            CurrentLevel = new Level();
            CurrentLevel.SpinValue = totalSpin;
           
            RentValue = RentValue + (RentValue * IncreasedPersentage * 0.01f);
            CurrentLevel.RentValue = ((int)RentValue);
        }
       
    }

    public void UpdateCurrentLevelCoin(int coin ) {

        CurrentLevelCollectedCoin += coin;
        GameManager.instance.UpdateScore(coin);

    }

    private void setpowerup() {

        UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(false);

        if (PowerupManager.instance.airDrop.Count == 0) {
            UiManager.instance.GetUiPowerupScreen.gameObject.SetActive(true);
        }
        else {
            for (int i = 0; i < PowerupManager.instance.airDrop.Count; i++) {

                if (PowerupManager.instance.airDrop[i].gameObject.activeSelf) {
                    PowerupManager.instance.airDrop[i].Spawn();
                    StartCoroutine(DelayOfAcivatePowerupPanel());
                }
            }
        }




    }

    private IEnumerator DelayOfAcivatePowerupPanel() {
        yield return new WaitForSeconds(0.5f);
        UiManager.instance.GetUiPowerupScreen.gameObject.SetActive(true);
    }
}




[System.Serializable]
public class Level {

    public int SpinValue;
    public int RentValue;
    
}



