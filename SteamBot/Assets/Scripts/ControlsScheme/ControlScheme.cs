using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Guidisisco
{
    [System.Serializable]
    public struct InputAction
    {
        public string name;
        public List<KeyCode> keys;
    }

    [CreateAssetMenu(menuName = "ControlScheme")]
    public class ControlScheme : ScriptableObject
    {
        public List<InputAction> controls;

        /// <summary>
        /// Check if any of the specified keys for an action are currently pressed.
        /// </summary>
        /// <param name="actionName">The name of the action to check.</param>
        /// <returns>True on the first frame after the keys are pressed, false otherwise.</returns>
        public bool IsActionKeyDown(string actionName)
        {
            InputAction inputAction = controls.Find(element => element.name == actionName);
            if (inputAction.keys != null)
            {
                foreach (KeyCode key in inputAction.keys)
                {
                    if (Input.GetKeyDown(key))
                    {
                        return true; // Return true if any of the keys are pressed.
                    }
                }
            }
            return false; // Return false if none of the keys are pressed or if the action is not found.
        }


        /// <summary>
        /// Check if any of the specified keys for an action are currently pressed.
        /// </summary>
        /// <param name="actionName">The name of the action to check.</param>
        /// <returns>True if any of the keys are pressed, false otherwise.</returns>
        public bool IsActionHeld(string actionName)
        {
            InputAction inputAction = controls.Find(element => element.name == actionName);
            if (inputAction.keys != null)
            {
                foreach (KeyCode key in inputAction.keys)
                {
                    if (Input.GetKey(key))
                    {
                        return true; // Return true if any of the keys are pressed.
                    }
                }
            }
            return false; // Return false if none of the keys are pressed or if the action is not found.
        }


        /// <summary>
        /// Check if any of the specified keys for an action are released.
        /// </summary>
        /// <param name="actionName">The name of the action to check.</param>
        /// <returns>True the frame after the keys are released, false otherwise.</returns>
        public bool IsActionKeyUp(string actionName)
        {
            InputAction inputAction = controls.Find(element => element.name == actionName);
            if (inputAction.keys != null)
            {
                foreach (KeyCode key in inputAction.keys)
                {
                    if (Input.GetKeyUp(key))
                    {
                        return true; // Return true if any of the keys are released.
                    }
                }
            }
            return false; // Return false if none of the keys are released or if the action is not found.
        }

        /// <summary>
        /// Rebind keys for an action.
        /// </summary>
        /// <param name="actionName">The name of the action to rebind.</param>
        /// <param name="newKeys">The new list of key codes to bind to the action.</param>
        /// <param name="elementIndex">The index of the element in the list of key codes to change (default is 0).</param>
        public void RebindKeys(string actionName, List<KeyCode> newKeys, int elementIndex = 0)
        {
            InputAction inputAction = controls.Find(element => element.name == actionName);

            if (inputAction.keys != null && elementIndex >= 0 && elementIndex < inputAction.keys.Count)
            {
                inputAction.keys[elementIndex] = newKeys[0];
            }
        }

        /// <summary>
        /// Starts hotcapture of input keys, the next input replacing the ---actionname--- input this does not save.
        /// </summary>
        /// <param name="actionName">The name of the action to rebind.</param>
        public void StartRebind(string actionName,bool ignoreJoystickInput = false, bool ignoreKeyboardInput = false)
        {
            GameObject go = new GameObject();

            ControlsHotInput temp = go.AddComponent<ControlsHotInput>();

            temp.SetUp(this, actionName, ignoreJoystickInput, ignoreKeyboardInput);
        }

        public void SetTo(ControlScheme control)
        {
            controls.Clear();

            controls = control.controls;
        }

        public void Save(string filename = "", string filePath = @"C:\Users\Guilherme\Desktop\")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ControlScheme));

            using (StreamWriter streamWriter = new StreamWriter(filePath + filename))
            {
                serializer.Serialize(streamWriter, this);
            }
        }
        public void Load(string filename = "", string filePath = @"C:\Users\Guilherme\Desktop\")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ControlScheme));

            string fullPath = filePath + filename;

            if (!File.Exists(fullPath))
            {
                return;
            }

            using (StreamReader streamReader = new StreamReader(fullPath))
            {
                controls = (serializer.Deserialize(streamReader) as ControlScheme).controls;
            }
        }
    }
}