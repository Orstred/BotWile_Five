using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Guidisisco
{
   public class ControlsMenuUI : MonoBehaviour
   {
        [SerializeField] private Image KeyboardControls;
        [SerializeField] private Image JoystickControls;



        public void OpenKeyboardMenu()
        {
            KeyboardControls.enabled = true;
            JoystickControls.enabled = false;
        }
        public void OpenJoystickMenu()
        {
            JoystickControls.enabled = true;
            KeyboardControls.enabled = false;
        }

    }
}