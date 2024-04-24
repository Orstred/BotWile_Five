using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guidisisco
{
   public class ControlsManager : MonoBehaviour
   {
        [SerializeField] private ControlScheme Default_Keyboard_Controls;
        [SerializeField] private ControlScheme Default_Joystick_Controls;

        [SerializeField] private ControlScheme Current_Joystick_Controls;
        [SerializeField] private ControlScheme Current_Keyboard_Controls;

        public ControlScheme Current_Active_Controls;


        public delegate void ControlsHotInputEvent(ControlScheme controls);
        public ControlsHotInputEvent onChangeControls;

        private void Start()
        {
            Current_Active_Controls = Current_Keyboard_Controls;

            Current_Joystick_Controls.Load("JoystickControls");
            Current_Keyboard_Controls.Load("KeyboardControls");
        }

        private void Update()
        {
            HandleControlsChange();
        }

        public void HandleControlsChange()
        {
            if(Input.anyKey)
            {
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (!Input.GetKeyDown(keyCode))
                    {
                        continue;
                    }

                    if (IsJoystickButton(keyCode))
                    {
                        Current_Active_Controls = Current_Joystick_Controls;
                        return;
                    }
                    Current_Active_Controls = Current_Keyboard_Controls;
                    return;
                }
            }
        }

        public void ChangeKeyboardInput(string Name)
        {
            Current_Keyboard_Controls.StartRebind(Name, ignoreJoystickInput: true);

            Current_Keyboard_Controls.Save("KeyboardControls.data");
        }
        public void ChangeJoystickInput(string Name)
        {
            Current_Joystick_Controls.StartRebind(Name, ignoreKeyboardInput: true);

            Current_Joystick_Controls.Save("JoystickControls.data");
        }

        public void ResetKeyboardControls() => Current_Keyboard_Controls.SetTo(Default_Keyboard_Controls);
        public void ResetJoystickControls() => Current_Joystick_Controls.SetTo(Default_Joystick_Controls);

        public bool isJoystickControls() 
        {
            if (Current_Active_Controls == Current_Joystick_Controls) return true;

            return false;
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