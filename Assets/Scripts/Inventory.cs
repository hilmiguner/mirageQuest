using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int crystalNumber = 0;
    public HudScript hudsc;
    public NearestCrystal nc;
    public PhoenixMovement pm;
    public ElfTalkScript ets;
    public bool hasWand = false;
    public bool doneThePart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hudsc.changeCrystalCounter(crystalNumber);
        if(crystalNumber == 6 && !doneThePart) {
            doneThePart = true;
            nc.isFoundAllCrystals = true;
            ets.isBeforeCrystalTalkDone = true;
            pm.target.position = new Vector3(-2.71f, 120f, 41.83f);
            hudsc.doneCurrentQuest();
            hudsc.changeQuestLabel1();
        }
    }
}
