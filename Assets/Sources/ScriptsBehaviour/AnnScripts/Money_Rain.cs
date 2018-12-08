using UnityEngine;



public class Money_Rain : MonoBehaviour
{
    ParticleSystem ps;
    int n = 0;

    public void Start()
    { ps = (ParticleSystem)GetComponent(typeof(ParticleSystem));
        ps.Stop();
    }

    void Update()
    {     
        if (Elona.Slot.ElosUI.currentSpingNumber > 2 && n != Elona.Slot.ElosUI.currentSpingNumber)
        {
            ps.Stop();
            n = Elona.Slot.ElosUI.currentSpingNumber;
            if (n % 5 == 0)
            { ps.Play(); }
            
        }
    }
}
