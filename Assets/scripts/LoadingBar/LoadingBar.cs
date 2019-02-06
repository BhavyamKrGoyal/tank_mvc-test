using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingBar
{


    public class LoadingBar : MonoBehaviour
    {
        // Start is called before the first frame update
        Slider slider;
        void Start()
        {
           // StateManager.Instance.OnStateChanged+=SetUI;
            slider = gameObject.GetComponent<Slider>();
        }
        float loaded = 0;
        // Update is called once per frame
        void Update()
        {
            if (loaded < .6)
            {
                loaded = loaded + 0.008f;
                slider.value = loaded;

            }
            else if (loaded < .85)
            {
                loaded += 0.002f;
                slider.value = loaded;
            }
            else if (loaded < 1)
            {
                loaded += 0.002f;
            }
            else
            {
                slider.value = loaded;
                StateManager.Instance.ChangeState();
            }
        }
        private void SetUI(States stateName){
            slider.gameObject.SetActive(true);
        }
        
        private void RemoveUI(){
            slider.gameObject.SetActive(false);
        }
    }
}