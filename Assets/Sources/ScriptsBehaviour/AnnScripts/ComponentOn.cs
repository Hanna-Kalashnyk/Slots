using UnityEngine;
namespace Elona.Slot
{

    public class ComponentOn : MonoBehaviour
    {
        public GameObject ui;
        private ElosUI anotherScript;

        private void Awake()
        {
            anotherScript = GetComponent<ElosUI>();
                    }
        // Start is called before the first frame update
        void Start()
        {
            anotherScript.enabled = true;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
