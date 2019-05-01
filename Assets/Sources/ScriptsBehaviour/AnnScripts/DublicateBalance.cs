using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DublicateBalance : MonoBehaviour
{
    //private Tweener _moneyTween;
    //   [SerializeField]
    // public Text _balance;

    [SerializeField]
    private Text _DublicateBalance;

   public static int dublicateBalance;



    void Start()
    {
        _DublicateBalance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
        print("blaDubStart");
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
     }

    public void Update()
    {
        _DublicateBalance.text = dublicateBalance + "";
    }
       
    
}