using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Models;
using UnityEngine;


namespace Playground
{
    public class PlaygroundController : MonoBehaviour
    {
        
        [SerializeField] private PlaygroundModel playgroundModel;
        
        private LevelModel _levelModel;

        public static PlaygroundController Instance;

        private PlaygroundView _playgroundView;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _playgroundView = GetComponent<PlaygroundView>();
        }


        public void StartCreate(LevelModel levelModel)
        {
            _levelModel = levelModel;
            _playgroundView.StartGame();
        }


        public void SetDataToPieces(List<GameObject> pieces)
        {
            List<int> kays = _levelModel.GetAllIndexId();

            for (int i = 0; i < kays.Count; i++)
            {
                PieceModel pieceModel = _levelModel.GetPieceData(kays[i]);
                
                GameObject piece = Instantiate(playgroundModel.piecePrefab, pieces[kays[i]].gameObject.transform);
                piece.gameObject.transform.localScale =
                    new Vector3(1, pieceModel.heightCount, 1);

                if (pieceModel.CheckIsConfirmEvent())
                {
                    piece.GetComponentInChildren<MeshRenderer>().material = playgroundModel.confirmMaterial;
                }
            }
        }
    }
}