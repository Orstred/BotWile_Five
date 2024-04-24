using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Guidisisco
{
   public class ControlSchemeButton : MonoBehaviour
   {
        [SerializeField] private string ActionName;
        [SerializeField] private Text ActionDescription;

        private ControlsManager manager;

        private void Start()
        {
            manager = GameManager.instance.controlsManager;

            foreach (InputAction inputAction in manager.Current_Active_Controls.controls)
            {
                if(inputAction.name == ActionName)
                {
                    KeyCode temp =  inputAction.keys[0];

                    ActionDescription.text = temp.ToString();
                }
            }
        }
        public void ChangeKeyboardKey()
        {
            manager.ChangeKeyboardInput(ActionName);
            foreach (InputAction inputAction in manager.Current_Active_Controls.controls)
            {
                if (inputAction.name == ActionName)
                {
                    KeyCode temp = inputAction.keys[0];

                    ActionDescription.text = temp.ToString();
                }
            }
        }
        public void ChangeJoystickKey()
        {
            manager.ChangeJoystickInput(ActionName);
            foreach (InputAction inputAction in manager.Current_Active_Controls.controls)
            {
                if (inputAction.name == ActionName)
                {
                    KeyCode temp = inputAction.keys[0];

                    ActionDescription.text = temp.ToString();
                }
            }
        }
    }
}