using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private UiHomeScreen uiHomeScreen;
    [SerializeField] private UILevelScreen uiLevelScreen;
    [SerializeField] private UiGameScreen UiGamePlayScreen;
    [SerializeField] private UIPowerup uiPowerup;
    [SerializeField] private UIPassive uiPassive;
    [SerializeField] private UiPayRentScreen uiPayRentSceen;
    [SerializeField] private UiGameOverScreen uiGameOverScreen;
    [SerializeField] private UiCoinPanel uiCoinPanel;
    [SerializeField] private UiSettingPanel uiSettingPanel;
    public Canvas canvas;
   

    public UiSettingPanel GetUiSettingScreen { get; private set; }

    public UiHomeScreen GetUiHomeScreen { get; private set; }

    public UILevelScreen GetLevelScreen { get; private set; }
    public UiGameScreen GetUiGamePlayScreen { get; private set; }
    public UIPowerup GetUiPowerupScreen { get; private set; }
    public UIPassive GetUIPassiveScreen { get; private set; }
    public UiGameOverScreen GetGameoverScreen { get; private set; }
   
    public UiPayRentScreen GetUiPayRentScreen { get; private set; }
   
    public UiCoinPanel GetUiCoinPanel { get; set; }

    private void Awake() {

        instance = this;
    }

    private void Start() {
        GetUiGamePlayScreen = UiGamePlayScreen;
        GetUiPowerupScreen = uiPowerup;
        GetUiHomeScreen = uiHomeScreen;
        GetLevelScreen = uiLevelScreen;
        GetGameoverScreen = uiGameOverScreen;
        GetUIPassiveScreen = uiPassive;
        GetUiPayRentScreen = uiPayRentSceen;
        GetUiCoinPanel = uiCoinPanel;
        GetUiSettingScreen = uiSettingPanel;
        GameManager.instance.StartGame();
    }


}
