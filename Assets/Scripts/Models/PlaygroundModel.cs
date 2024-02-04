using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "PlaygroundModel",menuName = "Model/PlaygroundModel")]
    public class PlaygroundModel : ScriptableObject
    {
        public GameObject piecePrefab;

        public Material confirmMaterial;
    }
}
