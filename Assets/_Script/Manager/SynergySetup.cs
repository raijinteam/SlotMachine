using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergySetup : MonoBehaviour
{
   
    public List<System.Action> SetListOfAction(List<System.Action> list_Actions,List<SymbolData> list_Gamobject) {

        if (PowerupManager.instance.ShortingPassive().Count != 0) {

           
            for (int i = 0; i < PowerupManager.instance.ShortingPassive().Count; i++) {

                if (PowerupManager.instance.ShortingPassive()[i].TryGetComponent<Exploit>(out Exploit exploit)) {
                    list_Actions.Add(exploit.Instance_SetSynergy);
                    GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
                }
                else if (PowerupManager.instance.ShortingPassive()[i].TryGetComponent<EthChain>(out EthChain ethChain)) {
                    list_Actions.Add(ethChain.Instance_SetSynergy);
                    GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

                }
                else if (PowerupManager.instance.ShortingPassive()[i].TryGetComponent<ProofofStake>(out ProofofStake proofofStake)) {
                    list_Actions.Add(proofofStake.Instance_SetSynergy);
                    GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
                }
                else if (PowerupManager.instance.ShortingPassive()[i].TryGetComponent<DiamondHands>(out DiamondHands diamondHands)) {
                    list_Actions.Add(diamondHands.Instance_SetSynergy);
                    GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
                }
            }
        }

       
        // Passive Synergy
        //1 Exploit 
        // 2 proofofStack
        // 3 EthChain
        // 4 Diamond hands 

        // PowerUp Synergy
        for (int i = 0; i < list_Gamobject.Count; i++) {

            //bitcoin = 1 , nosynergy
            //CardenoCoin = 2 ,Nosynegy
            //EthCoin = 3 ,Nosynergy
            //StableCoin =4 , Nosynergy
            //Accridita Invester = 5, nosynergy 
            //Asic = 6, nosynergy
            //Auditor = 7, nosynergy
            if (list_Gamobject[i].mySymbolIndex == 8) {

                list_Actions.Add(list_Gamobject[i].GetComponent<Bagholder>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            if (list_Gamobject[i].mySymbolIndex == 9) {

                list_Actions.Add(list_Gamobject[i].GetComponent<BEAR>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }

            else if (list_Gamobject[i].mySymbolIndex == 10) {
                list_Actions.Add(list_Gamobject[i].GetComponent<BlackSwan>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
            }

            else if (list_Gamobject[i].mySymbolIndex == 11) {

                list_Actions.Add(list_Gamobject[i].GetComponent<Bull>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            else if (list_Gamobject[i].mySymbolIndex == 12) {
                list_Actions.Add(list_Gamobject[i].GetComponent<CandlestickGreen>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
            }
            else if(list_Gamobject[i].mySymbolIndex == 13) {
                list_Actions.Add(list_Gamobject[i].GetComponent<CandlestickRed>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
            }

            //Cloud Minning = 14 , nosynergy 
            // Crain = 15 , nosynergy
            //Cross Chain = 16, nosynergy
            else if (list_Gamobject[i].mySymbolIndex == 17) {

                list_Actions.Add(list_Gamobject[i].GetComponent<DeadCat>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());
            }
            else if (list_Gamobject[i].mySymbolIndex == 18) {
                list_Actions.Add(list_Gamobject[i].GetComponent<DeathCross>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            //escrew = 19 , Nosynergy

            else if (list_Gamobject[i].mySymbolIndex == 20) {

               
                list_Actions.Add(list_Gamobject[i].GetComponent<FomoBuyer>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            // fur  = 21 ,nosynergy
            //hodler = 22 , nosynergy
            else if (list_Gamobject[i].mySymbolIndex == 23) {


                list_Actions.Add(list_Gamobject[i].GetComponent<KYCPaper>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            // Load = 24 , Nosynergy
            // Mychal Saylor = 25 , nosynegy
            else if (list_Gamobject[i].mySymbolIndex == 26) {


                list_Actions.Add(list_Gamobject[i].GetComponent<NFT>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }

            else if (list_Gamobject[i].mySymbolIndex == 27) {

                list_Actions.Add(list_Gamobject[i].GetComponent<SatoshiNakamoto>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            else if (list_Gamobject[i].mySymbolIndex == 28) {

                list_Actions.Add(list_Gamobject[i].GetComponent<TelegramScammer>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }
            else if (list_Gamobject[i].mySymbolIndex == 29) {

                list_Actions.Add(list_Gamobject[i].GetComponent<Vitalick>().Instance_SetSynergy);
                GridManager.instance.SynergySymbolData.Add(list_Gamobject[i].GetComponent<SymbolData>());

            }

            // Whale = 30 , noSynergy
            // X = 31 , Nosynergy


        }

        return list_Actions;
    }

    
}
