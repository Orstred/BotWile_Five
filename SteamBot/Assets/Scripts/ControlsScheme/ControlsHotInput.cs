using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guidisisco
{
    public class ControlsHotInput : MonoBehaviour
    {
        #region Singleton
        public static ControlsHotInput instance;
        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
        }
        #endregion

        private string rebindingAction; // Store the action being rebound
        private int rebindingElementIndex; // Store the index of the element being rebound
        private ControlScheme controls;

        private bool ignoreKeyboardInput;
        private bool ignoreJoystickInput;

        void Update()
        {
            if (Input.anyKeyDown)
            {
                if (rebindingAction != null)
                {
                    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(keyCode))
                        {
                            // Exclude joystick buttons
                            if (ignoreJoystickInput && IsJoystickButton(keyCode))
                            {
                                return;
                            }
                            if (ignoreKeyboardInput && !IsJoystickButton(keyCode))
                            {
                                return;
                            }
                            controls.RebindKeys(rebindingAction, new List<KeyCode> { keyCode }, rebindingElementIndex);
                            rebindingAction = null;
                            rebindingElementIndex = 0;
                            break;
                        }
                    }
                }
                Destroy(gameObject);
            }
        }

        public void SetUp(ControlScheme control, string actionName, bool ignoreJoystickInputs = false, bool ignoreKeyboardInputs = false)
        {
            rebindingAction = actionName;
            controls = control;
            this.ignoreJoystickInput = ignoreJoystickInputs;
            this.ignoreKeyboardInput = ignoreKeyboardInputs;
        }

        public bool IsJoystickButton(KeyCode keyCode)
        {
            if (keyCode == KeyCode.JoystickButton0 ||
                keyCode == KeyCode.JoystickButton1 ||
                keyCode == KeyCode.JoystickButton2 ||
                keyCode == KeyCode.JoystickButton3 ||
                keyCode == KeyCode.JoystickButton4 ||
                keyCode == KeyCode.JoystickButton5 ||
                keyCode == KeyCode.JoystickButton6 ||
                keyCode == KeyCode.JoystickButton7 ||
                keyCode == KeyCode.JoystickButton8 ||
                keyCode == KeyCode.JoystickButton9 ||
                keyCode == KeyCode.JoystickButton10 ||
                keyCode == KeyCode.JoystickButton11 ||
                keyCode == KeyCode.JoystickButton12 ||
                keyCode == KeyCode.JoystickButton13 ||
                keyCode == KeyCode.JoystickButton14 ||
                keyCode == KeyCode.JoystickButton15 ||
                keyCode == KeyCode.JoystickButton16 ||
                keyCode == KeyCode.JoystickButton17 ||
                keyCode == KeyCode.JoystickButton18 ||
                keyCode == KeyCode.JoystickButton19)
            {
                return true;
            }

            return false;
        }
    }
}