using UnityEngine;

namespace Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject _projectTile;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _chargedProjectTile;
        [SerializeField] private float _chargedSpeed;
        [SerializeField] private float _chargedTime;

        private bool _isCharging;

        private void Update()
        {
            if (Input.GetKey(KeyCode.F) && _chargedTime < 2)
            {
                _isCharging = true;
                if (_isCharging == true)
                {
                    _chargedTime += Time.deltaTime * _chargedSpeed;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(_projectTile, _firePoint.position, _firePoint.rotation);
                _chargedTime = 0;
            }
            else if (Input.GetKeyUp(KeyCode.F) && _chargedTime >= 2)
            {
                ReleaseCharge();
            }
        }

        private void ReleaseCharge()
        {
            Instantiate(_chargedProjectTile, _firePoint.position, _firePoint.rotation);
            _isCharging = false;
            _chargedTime = 0;
        }
    }
}