using UnityEngine;
using DG.Tweening;
using Elona.Slot;

public class CoinJetScript : MonoBehaviour
{
    ParticleSystem s;
    int n = 0;
    private AudioSource AudioS;

    public void Start()
    {
        s = (ParticleSystem)GetComponent(typeof(ParticleSystem));
        s.Stop();
        AudioS = GetComponent<AudioSource>();
        AudioS.Stop();
    }

    void Update()
    {
        if (n != BalanceAnimation.n)
        {
           // s.Stop();
            n = BalanceAnimation.n;
            s.Play();
            AudioS.Play();
          //  ElosUI.audioEarnBig.Play();

        }
    }
}
