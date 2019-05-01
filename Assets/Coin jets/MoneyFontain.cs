using UnityEngine;



public class MoneyFontain : MonoBehaviour
{
    ParticleSystem ps;
    int n = 0;
    int counter = 0;
    int counterOnPayBatton = 0;
    private AudioSource AudioS;

    public void Start()
    {
        ps = (ParticleSystem)GetComponent(typeof(ParticleSystem));
        ps.Stop();
        AudioS = GetComponent<AudioSource>();
        AudioS.Stop();
    }
    public void MoneyFontainCounter() {
        counterOnPayBatton = counterOnPayBatton + 1; }

    public void MoneyFontainStart() { ps.Play(); AudioS.Play(); }

    void Update()
    {
        if (Elona.Slot.ElosUI.currentSpingNumber > 0 && n != Elona.Slot.ElosUI.currentSpingNumber)
        {
            ps.Stop();
            n = Elona.Slot.ElosUI.currentSpingNumber;
            if (n % 2 == 0)
            { ps.Play();
                AudioS.Play();
            }

        }
        if (counter!= counterOnPayBatton) { ps.Play(); AudioS.Play();
            counter = counterOnPayBatton;
        }
    }
}
