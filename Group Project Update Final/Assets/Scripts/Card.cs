using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    //When none of the cards should be flipped, it holds the whole card flipping process
    public static bool DO_NOT = false; 

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    //called when the game starts
    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    //Initialize all our values
    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }
	
    public void flipCard()
    {
        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;

        if (_state == 0 && !DO_NOT) //it shows its face
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !DO_NOT) //it shows its back
            GetComponent<Image>().sprite = _cardFace;
    }

    //set and get the card value
    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    //set and get the state
    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    //Starts a coroutine called pause=it gives a little buffer for when cards are flipped over and you check to see if thy are a match how long you should wait before you flip them back over
    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    //pause is an IEnumerator=has a special statement called a yield that returns a waitForSeconds(1)
    //pause is the buffer
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0) //if it's not a match, we set the image to the cardBack
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }
}
