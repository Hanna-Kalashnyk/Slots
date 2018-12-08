using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour {

    [SerializeField]
    private Color defaultColor;
    [SerializeField]
    private Color disabledColor;
    [SerializeField]
    private List<GameObject> row1;
    [SerializeField]
    private List<GameObject> row2;
    [SerializeField]
    private List<GameObject> row3;
    [SerializeField]
    private List<GameObject> row4;
    [SerializeField]
    private List<GameObject> row5;
    
    [SerializeField]
    public GameObject TotalBet;    
    [SerializeField]
    public GameObject TotalBonus;


    private int Bet;
    private int CurrentRow;

    // Use this for initialization
    void Start ()
    {
        SetBet(PlayerPrefs.GetInt("CURRENT_BET"));
        CurrentRow = 1;
        GenerateValues();
	}
	
    public void SetBet(int betAmount)
    {
        Bet = betAmount * 5;
        TotalBet.GetComponent<Text>().text = Bet.ToString();
    }

    public void UpdateScore(int value)
    {
        TotalBonus.GetComponent<BonusScore>().score += value;
        TotalBonus.GetComponent<Text>().text = TotalBonus.GetComponent<BonusScore>().score.ToString();
    }

    //each row starts out de-activated.  As each row is completed, the next row will be activated.
    public void ActivateNextRow()
    {
        CurrentRow++;
        if(CurrentRow == 2)
        {
            for (int i = 0; i < row2.Count; i++)
            {
                row2[i].GetComponent<Button>().interactable = true;
            }
        }
        if (CurrentRow == 3)
        {
            for (int i = 0; i < row3.Count; i++)
            {
                row3[i].GetComponent<Button>().interactable = true;
            }
        }
        if (CurrentRow == 4)
        {
            for (int i = 0; i < row4.Count; i++)
            {
                row4[i].GetComponent<Button>().interactable = true;
            }
        }
        if (CurrentRow == 5)
        {
            for (int i = 0; i < row5.Count; i++)
            {
                row5[i].GetComponent<Button>().interactable = true;
            }
        }
        //if the player has completed the last row, the minigame will end and return to the slots
        if (CurrentRow == 6)
        {
            //print("game over");
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + TotalBonus.GetComponent<BonusScore>().score;
            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
            SceneManager.LoadScene("SlotGame2");
        }
    }

    //reveals the rest of the row after player selects a cell
    public void RevealRow(int row, GameObject selectedCell)
    {
        if(row == 1)
        {
            for (int i = 0; i < row1.Count; i++)
            {
                row1[i].GetComponent<GridCell>().SetSprite();
                if (row1[i].gameObject == selectedCell)
                {
                    //this block of code repeated changes the disabled color of the button to white 
                    ColorBlock cb = selectedCell.GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    selectedCell.GetComponent<Button>().colors = cb;
                }    
            }            
        }
        if(row == 2)
        {
            for (int i = 0; i < row2.Count; i++)
            {
                row2[i].GetComponent<GridCell>().SetSprite();
                if (row2[i].gameObject == selectedCell)
                {
                    ColorBlock cb = selectedCell.GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    selectedCell.GetComponent<Button>().colors = cb;
                }
            }
        }
        if(row == 3)
        {
            for (int i = 0; i < row3.Count; i++)
            {
                row3[i].GetComponent<GridCell>().SetSprite();
                if (row3[i].gameObject == selectedCell)
                {
                    ColorBlock cb = selectedCell.GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    selectedCell.GetComponent<Button>().colors = cb;
                }
            }
        }
        if(row == 4)
        {
            for (int i = 0; i < row4.Count; i++)
            {
                row4[i].GetComponent<GridCell>().SetSprite();
                if (row4[i].gameObject == selectedCell)
                {
                    ColorBlock cb = selectedCell.GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    selectedCell.GetComponent<Button>().colors = cb;
                }
            }
        }
        if (row == 5)
        {
            for(int i = 0; i < row5.Count; i++)
            {
                row5[i].GetComponent<GridCell>().SetSprite();
                if (row5[i].gameObject == selectedCell)
                {
                    ColorBlock cb = selectedCell.GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    selectedCell.GetComponent<Button>().colors = cb;
                }
            }
        }
        selectedCell.GetComponent<Image>().color = defaultColor;
    }

    //if cell is unicorn, reveals and highlights rest of the row while adding the sum to the bonus score
    public void RevealUnicorn(int row)
    {
        if (row == 1)
        {
            for (int i = 0; i < row1.Count; i++)
            {
                row1[i].GetComponent<GridCell>().SetSprite();
                ColorBlock cb = row1[i].GetComponent<Button>().colors;
                cb.disabledColor = defaultColor;
                row1[i].GetComponent<Button>().colors = cb;
                UpdateScore(row1[i].GetComponent<GridCell>().value);
            }
        }
        if (row == 2)
        {
            for (int i = 0; i < row2.Count; i++)
            {
                row2[i].GetComponent<GridCell>().SetSprite();
                ColorBlock cb = row2[i].GetComponent<Button>().colors;
                cb.disabledColor = defaultColor;
                row2[i].GetComponent<Button>().colors = cb;
                UpdateScore(row2[i].GetComponent<GridCell>().value);
            }
        }
        if (row == 3)
        {
            for (int i = 0; i < row3.Count; i++)
            {
                row3[i].GetComponent<GridCell>().SetSprite();
                if (!row3[i].GetComponent<GridCell>().isDemon)
                {
                    ColorBlock cb = row3[i].GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    row3[i].GetComponent<Button>().colors = cb;
                }
                UpdateScore(row3[i].GetComponent<GridCell>().value);
            }
        }
        if (row == 4)
        {
            for (int i = 0; i < row4.Count; i++)
            {
                row4[i].GetComponent<GridCell>().SetSprite();
                if (!row4[i].GetComponent<GridCell>().isDemon)
                {
                    ColorBlock cb = row4[i].GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    row4[i].GetComponent<Button>().colors = cb;
                }
                UpdateScore(row4[i].GetComponent<GridCell>().value);
            }
        }
        if (row == 5)
        {
            for (int i = 0; i < row5.Count; i++)
            {
                row5[i].GetComponent<GridCell>().SetSprite();
                if (!row5[i].GetComponent<GridCell>().isDemon)
                {
                    ColorBlock cb = row5[i].GetComponent<Button>().colors;
                    cb.disabledColor = defaultColor;
                    row5[i].GetComponent<Button>().colors = cb;
                }
                UpdateScore(row5[i].GetComponent<GridCell>().value);
            }
        }
    }

    //fills the grid will random values, unicorns, and demons after row 3
    public void GenerateValues()
    {
        for(int i = 0; i < row1.Count; i++)
        {
            int rand = Random.Range(1, 6);
            row1[i].GetComponent<GridCell>().value = Bet * rand;
            row1[i].GetComponent<GridCell>().row = 1;
        }        
        for (int i = 0; i < row2.Count; i++)
        {
            int rand = Random.Range(1, 6);
            row2[i].GetComponent<GridCell>().value = Bet * rand;
            row2[i].GetComponent<GridCell>().row = 2;
        }
        for (int i = 0; i < row3.Count; i++)
        {
            int rand = Random.Range(1, 6);
            row3[i].GetComponent<GridCell>().value = Bet * rand;
            row3[i].GetComponent<GridCell>().row = 3;
        }
        for (int i = 0; i < row4.Count; i++)
        {
            int rand = Random.Range(1, 6);
            row4[i].GetComponent<GridCell>().value = Bet * rand;
            row4[i].GetComponent<GridCell>().row = 4;
        }
        for (int i = 0; i < row5.Count; i++)
        {
            int rand = Random.Range(1, 6);
            row5[i].GetComponent<GridCell>().value = Bet * rand;
            row5[i].GetComponent<GridCell>().row = 5;
        }

        /* after cells are initialized with values based on bet amount
           -insert unicorns
           -insert demons starting from row 3
        */           
        int rand1 = RandomCell();
        row1[rand1].GetComponent<GridCell>().isUnicorn = true;
        row1[rand1].GetComponent<GridCell>().value = 0;        

        int rand2 = RandomCell();
        row2[rand2].GetComponent<GridCell>().isUnicorn = true;
        row2[rand2].GetComponent<GridCell>().value = 0;

        int rand3 = RandomCell();
        row3[rand3].GetComponent<GridCell>().isUnicorn = true;
        row3[rand3].GetComponent<GridCell>().value = 0;
        int other3 = RandomOtherCell(rand3);
        row3[other3].GetComponent<GridCell>().isDemon = true;
        row3[other3].GetComponent<GridCell>().value = 0;

        int rand4 = RandomCell();
        row4[rand4].GetComponent<GridCell>().isUnicorn = true;
        row4[rand4].GetComponent<GridCell>().value = 0;
        int other4 = RandomOtherCell(rand4);
        row4[other4].GetComponent<GridCell>().isDemon = true;
        row4[other4].GetComponent<GridCell>().value = 0;

        int rand5 = RandomCell();
        row5[rand5].GetComponent<GridCell>().isUnicorn = true;
        row5[rand5].GetComponent<GridCell>().value = 0;
        int other5 = RandomOtherCell(rand5);
        row5[other5].GetComponent<GridCell>().isDemon = true;
        row5[other5].GetComponent<GridCell>().value = 0;
    }

    //returns a random value between 0 and 5
    int RandomCell()
    {
        return Random.Range(0, 6);
    }   

    //returns random value between 0 and 5 that differs from given value
    int RandomOtherCell(int unicornIndex)
    {
        int rand = Random.Range(0, 6);
        if(rand != unicornIndex)
        {
            return rand;
        }
        else
        {
            return RandomOtherCell(unicornIndex);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
