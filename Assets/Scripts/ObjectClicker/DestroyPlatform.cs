using System;
using GameState;
using UnityEngine;
using Utils.MultipleTags;

namespace ObjectClicker
{
    public class DestroyPlatform : MonoBehaviour
    {
        private readonly Manager _manager = Manager.GetInstance;
        private Camera _camera;
        private bool _isCameraNull;


        private void Start()
        {
            _camera = Camera.main;
            _isCameraNull = _camera == null;
        }

        private void Update()
        {
            if (_manager.StartGame) return;
            if (Input.GetMouseButtonDown(1))
            {
                if (_isCameraNull) throw new Exception("Camera.main is null");
                Vector2 rayPos = _camera.ScreenToWorldPoint(Input.mousePosition);

                var hits = new RaycastHit2D[10];
                var size = Physics2D.RaycastNonAlloc(rayPos, Vector2.zero, hits);
                // var hits = Physics2D.RaycastAll(rayPos, Vector2.zero);
                if (size > 0)
                    // foreach (var hit in hits)
                    for (var i = 0; i < size; i++)
                    {
                        var hit = hits[i];

                        // The collider GameObject
                        var clickedObject = hit.transform.gameObject;

                        var destroyed = DestroyClickedObject(clickedObject);
                        if (destroyed) break;
                    }
            }
        }

        private bool DestroyClickedObject(GameObject clickedObject)
        {
            var mt = clickedObject.GetComponent<MultiTags>();
            if (mt is null) return false;

            if (!mt.HasTag(EMultiTags.Platform)) return false;
            Destroy(clickedObject);
            return true;
        }
    }
}