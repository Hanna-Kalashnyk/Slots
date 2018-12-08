using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridCell : MonoBehaviour {

    [SerializeField]
    public int value;   

    public bool isUnicorn;
    public bool isDemon;
    public int row;

    private Sprite chip;
    
    public void SetSprite()
    {
        if (isUnicorn)
        {
            chip = Resources.Load("unicorn", typeof(Sprite)) as Sprite;
        }
        else if(isDemon)
        {
            chip = Resources.Load("demon", typeof(Sprite)) as Sprite;
        }
        else
        {
            chip = Resources.Load(value.ToString(), typeof(Sprite)) as Sprite;
        }                   
        GetComponent<Image>().sprite = chip;
        GetComponent<Button>().interactable = false;
    }

    public void RevealCell()
    {
        SetSprite();
        if(isUnicorn)
        {
            GetComponentInParent<GridManager>().RevealUnicorn(row);
            GetComponentInParent<GridManager>().ActivateNextRow();
        }
        else if(isDemon)
        {
            //print("game over");
            GetComponentInParent<GridManager>().RevealRow(row, gameObject);
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + GetComponentInParent<GridManager>().TotalBonus.GetComponent<BonusScore>().score;
            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
            SceneManager.LoadScene("SlotGame2");
        }
        else
        {
            GetComponentInParent<GridManager>().UpdateScore(value);
            GetComponentInParent<GridManager>().RevealRow(row, gameObject);
            GetComponentInParent<GridManager>().ActivateNextRow();
        }            
    }
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
