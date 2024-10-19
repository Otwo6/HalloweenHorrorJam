using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public CardType card;
    public CardMiniGameMasterScript masterScript;
    public Renderer ren;
    [SerializeField] private Material witchMat;
    [SerializeField] private Material toothMat;
    [SerializeField] private Material nailMat;
    [SerializeField] private Material jackMat;

    public void Flip()
    {
        print("flip");

        if(masterScript.playerCard1 == null)
        {
            SwitchMat();
            masterScript.playerCard1 = gameObject;
            print("1");
        }
        else if(masterScript.playerCard1 == this)
        {
            print("2");
        }
        else if(masterScript.playerCard2 == null)
        {
            SwitchMat();
            masterScript.playerCard2 = gameObject;
            masterScript.CardsPicked();
            print("3");
        }
    }

    private void SwitchMat()
    {
        switch(card)
        {
            case CardType.Witch:
                ren.material = witchMat;
                break;
            case CardType.Tooth:
                ren.material = toothMat;
                break;
            case CardType.Nail:
                ren.material = nailMat;
                break;
            case CardType.Jack:
                ren.material = jackMat;
                break;
        }
    }
}
