using System;
using System.Collections;
using UnityEngine;

namespace Makardwaj.Environment
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private float m_portalOpenTime = 2f;
        [SerializeField] private float m_playerSpawnTime = 1f;
        [SerializeField] private Transform m_playerSpawnMarker;

        public Vector2 PlayerSpawnPosition { get => m_playerSpawnMarker.position; }
        private Collider2D _collider;

        private WaitForSeconds _portalOpenTimer;
        private WaitForSeconds _playerSpawnTimer;
        private Coroutine _coroutinePortalClose;

        private void Awake()
        {
            _playerSpawnTimer = new WaitForSeconds(m_playerSpawnTime);
            _portalOpenTimer = new WaitForSeconds(m_portalOpenTime);
            _collider = GetComponent<Collider2D>();
        }

        public void SpawnPortalAndClose(Vector2 position, Action spawnPlayer)
        {
            gameObject.SetActive(true);
            transform.position = position;
            _collider.enabled = false;
            ClosePortal(spawnPlayer);
        }

        public void SpawnPortal(Vector2 position, bool isEnter = false)
        {
            transform.position = position;
            _collider.enabled = isEnter;
            gameObject.SetActive(true);
        }

        public void ClosePortal(Action spawnPlayer)
        {
            if(_coroutinePortalClose != null)
            {
                StopCoroutine(_coroutinePortalClose);
            }

            _coroutinePortalClose = StartCoroutine(IE_ClosePortal(spawnPlayer));
        }

        private IEnumerator IE_ClosePortal(Action spawnPlayer)
        {
            yield return _playerSpawnTimer;
            spawnPlayer?.Invoke();

            yield return _portalOpenTimer;
            gameObject.SetActive(false);
        }
    }
}