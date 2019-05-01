using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BalanceAnimation : MonoBehaviour {
    
    private Tweener _moneyTween;
    public static int dublicateBalance;

    public static int n;


    // Use this for initialization
    void Start () {
        dublicateBalance = PayTableBehaviour.dublicateBalance;
        n = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) != PayTableBehaviour.dublicateBalance)
        {
            dublicateBalance = PayTableBehaviour.dublicateBalance;
            print("blaAnim");
            n = n + 1;

            DOTween.To(() => DublicateBalance.dublicateBalance, x => DublicateBalance.dublicateBalance = x, PlayerPrefs.GetInt(Constants.PLAYER_BALANCE), 2.8f);
          //  tween(dublicateBalance);
           PayTableBehaviour.dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);


        }

    }
  //  private void tween(int dublicateBalance)
  //  {
        // if (_moneyTween != null && _moneyTween.IsPlaying()) _moneyTween.Complete();
        // _moneyTween =
   //     DOTween.To(() => DublicateBalance.dublicateBalance, x => DublicateBalance.dublicateBalance = x, PlayerPrefs.GetInt(Constants.PLAYER_BALANCE), 2.8f);
            //.OnComplete(() => { PayTableBehaviour.dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE); _moneyTween = null; });
    //    print("blaTween");
   // }
}
