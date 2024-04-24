using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guidisisco
{
   public class GameManager : MonoBehaviour
   {
        #region Singleton
        public static GameManager instance;
        private void Awake()
        {
            if (instance != null) Destroy(this);

            instance = this;
        }
        #endregion

        public ControlsManager controlsManager;
    }
}