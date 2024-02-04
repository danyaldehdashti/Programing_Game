using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playground
{
    public class PlaygroundView : MonoBehaviour
    {
        public List<GameObject> _pieceList;
        
        private const float _wayPointGizmozRaduis = 0.3f;

        public void StartGame()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                _pieceList.Add(transform.GetChild(i).gameObject);
            }
            
            PlaygroundController.Instance.SetDataToPieces(_pieceList);
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWayPoint(i), _wayPointGizmozRaduis);
            }
        }

        private Vector3 GetWayPoint(int i)
        {
            return gameObject.transform.GetChild(i).position;
        }

        private int GetNextIndex(int i)
        {
            if (i + 1 == gameObject.transform.childCount)
            {
                return 0;
            }

            return i + 1;
        }
        
    }
}