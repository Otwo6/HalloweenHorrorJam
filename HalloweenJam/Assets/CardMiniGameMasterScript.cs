using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMiniGameMasterScript : MonoBehaviour
{
    [SerializeField] CardScript Card1;
    [SerializeField] CardScript Card2;
    [SerializeField] CardScript Card3;
    [SerializeField] CardScript Card4;
    [SerializeField] CardScript Card5;
    [SerializeField] CardScript Card6;
    [SerializeField] CardScript Card7;
    [SerializeField] CardScript Card8;
    [SerializeField] CardScript Card9;

    int witchCardNum = 0;
    int nailCardNum = 0;
    int toothCardNum = 0;
    int jackCardNum = 0;

    public bool canWitch = true;
    public bool canTooth = true;
    public bool canNail = true;

    public GameObject playerCard1;
    public GameObject playerCard2;
    
    public int lives = 3;

    [SerializeField] private Material cardBackMat;

    private void Start()
    {
        Shuffle();
    }

    public void CardsPicked()
    {
        StartCoroutine(CheckCardsDelayed());
    }

    IEnumerator CheckCardsDelayed()
    {
        yield return new WaitForSeconds(1);
        CheckCards();
    }


    private void CheckCards()
    {
        if(playerCard1 != null && playerCard2 != null)
        {
            if(playerCard1.GetComponent<CardScript>().card == playerCard2.GetComponent<CardScript>().card)
            {
                print("Lets gooo");
                Destroy(playerCard1);
                Destroy(playerCard2);
            }
            else
            {
                playerCard1.GetComponent<CardScript>().ren.material = cardBackMat;
                playerCard2.GetComponent<CardScript>().ren.material = cardBackMat;
                playerCard1 = null;
                playerCard2 = null;
                lives--;
            }
        }
    }

    private void Shuffle()
    {
        witchCardNum = 0;
        nailCardNum = 0;
        toothCardNum = 0;
        jackCardNum = 0;


        Card1.card = randomCard();
        Card2.card = randomCard();
        Card3.card = randomCard();
        Card4.card = randomCard();
        Card5.card = randomCard();
        Card6.card = randomCard();
        Card7.card = randomCard();
        Card8.card = randomCard();
        Card9.card = randomCard();
    }

    private CardType randomCard()
    {
        CardType ret;
        bool validCard = false;

        do
        {
            ret = (CardType)Random.Range(0, 4);
            validCard = true;

            if (ret == CardType.Witch && witchCardNum >= 3 && canWitch)
            {
                validCard = false;
            }
            else if (ret == CardType.Tooth && toothCardNum >= 3 && canTooth)
            {
                validCard = false;
            }
            else if (ret == CardType.Nail && nailCardNum >= 3 && canNail)
            {
                validCard = false;
            }
            else if (ret == CardType.Jack && jackCardNum >= 1)
            {
                validCard = false;
            }

        } while (!validCard);

        // Increment the corresponding card counter
        if (ret == CardType.Witch) witchCardNum++;
        else if (ret == CardType.Tooth) toothCardNum++;
        else if (ret == CardType.Nail) nailCardNum++;
        else if (ret == CardType.Jack) jackCardNum++;

        return ret;
    }
}
