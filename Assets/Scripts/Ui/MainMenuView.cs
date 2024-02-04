using UnityEngine;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject gamePlayPrefab;

        [SerializeField] private MenuButton buttonPrefab;
        
        [SerializeField] private GameObject captureOneParent;
        
        [SerializeField] private GameObject captureTwoParent;
        
        [SerializeField] private GameObject elements;

        public void CreatePanel(int captureOneLevels,int captureTwoLevels)
        {
            //ToDo:Fix This
            
            for (int i = 0; i < captureOneLevels; i++)
            {
                MenuButton menuButton = Instantiate(buttonPrefab, captureOneParent.transform);
                menuButton.GetData(i,Capture.One);
            }
            
            for (int i = 0; i < captureTwoLevels; i++)
            {
                MenuButton menuButton = Instantiate(buttonPrefab, captureTwoParent.transform);
                menuButton.GetData(i,Capture.Two);
            }
        }

        public void GoToGameScene()
        {
            Instantiate(gamePlayPrefab);
            elements.SetActive(false);
        }

        public void OpenView()
        {
            elements.SetActive(true);
        }
    }
}