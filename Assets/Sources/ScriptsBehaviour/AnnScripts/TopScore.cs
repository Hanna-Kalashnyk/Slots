using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScore : MonoBehaviour {
    private int n = 1;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Time.timeSinceLevelLoad > 12.0) {
            n = (int)Time.timeSinceLevelLoad / 30;

            if (Time.timeSinceLevelLoad <= n * 30 + 4)
            {
                transform.position += Vector3.right * 2f * Time.deltaTime;
                transform.localScale += new Vector3(0.003F, 0.003F, 0.003F);
            }
            else
              if (Time.timeSinceLevelLoad <= n * 30 + 8)
            {
                transform.position += Vector3.left * 2f * Time.deltaTime;
                transform.localScale -= new Vector3(0.003F, 0.003F, 0.003F);

            }
        } }
}
