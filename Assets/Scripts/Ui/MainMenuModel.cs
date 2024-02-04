using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Ui
{
    public class MainMenuModel : MonoBehaviour
    {
        [SerializeField] private List<LevelModel> captureOneLevelModel;
        
        [SerializeField] private List<LevelModel> captureTowLevelModel;

        public List<LevelModel> GetData(Capture capture)
        {
            switch (capture)
            {
                case Capture.One:
                    return captureOneLevelModel;
                
                case Capture.Two:
                    return captureTowLevelModel;
            }

            return null;
        }
        
    }

    public enum Capture
    {
        One,
        Two
    }
}
