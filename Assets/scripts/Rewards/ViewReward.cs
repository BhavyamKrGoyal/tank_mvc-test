
using UnityEngine;
using UnityEngine.UI;
namespace Rewards
{
    public class ViewReward : MonoBehaviour
    {
        public Button button;
        bool canSelect = false;
        public Text name;
        public Image indicator;
        public GameObject panal;
        ControllerReward controller;

        public void SetViewReference(ControllerReward controller)
        {

            button.onClick.AddListener(ButtonClick);
            this.controller = controller;
            indicator.gameObject.SetActive(false);
        }
        void ButtonClick()
        { ServiceRewards.Instance.Selected(controller); }

        public void SetText(string name)
        {
            this.name.text = name;
        }

        public void Select()
        {
            if (canSelect)
            {
                foreach (MeshRenderer renderer in controller.unlockable.playerPrefab.GetComponentsInChildren<MeshRenderer>())
                {
                    renderer.sharedMaterial.SetColor("_Color", controller.unlockable.color);
                }
                GameApplication.Instance.SetPlayerPrefab(controller.unlockable.playerPrefab);
                indicator.gameObject.SetActive(true);
            }
        }
        public void DeSelect()
        {
            
                indicator.gameObject.SetActive(false);
            
        }
        public void SetSelectable()
        {
            panal.SetActive(false);
            canSelect = true;
        }
    private void OnDestroy() {
            controller.RemoveListener();
        }
    }
}
