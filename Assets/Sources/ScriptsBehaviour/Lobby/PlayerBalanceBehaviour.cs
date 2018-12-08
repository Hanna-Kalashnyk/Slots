using UnityEngine;
using UnityEngine.UI;


public class PlayerBalanceBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _balance;

  
    void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.PLAYER_BALANCE))
        {
            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, 100000);
        }
        _balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE).ToString();
    }
}