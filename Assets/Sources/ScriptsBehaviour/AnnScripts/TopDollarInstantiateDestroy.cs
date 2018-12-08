using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDollarInstantiateDestroy : MonoBehaviour {
    public GameObject  topDollar;
  
    // Use this for initialization
    void Start () {
        StartCoroutine( Inst());
        
    }
    IEnumerator Inst() {
        yield return new WaitForSeconds(4);
       
        GameObject td = Instantiate(topDollar, gameObject.transform.position, Quaternion.identity) as GameObject;
        
        Destroy(td, 10);

        Repeat();
    }
	void Repeat()
    {
        StartCoroutine(Inst());
    }

   
    
}
