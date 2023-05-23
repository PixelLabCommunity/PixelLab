using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject _simpleFire;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _chargedFire;

                
        public void FireButton()
        {
            ReleaseSimpleFire();
        }

        public void FireChargedButton()
        {
            ReleaseChargedFire();
        }

        private void ReleaseSimpleFire()
        {
            Instantiate(_simpleFire, _firePoint.position, _firePoint.rotation);
        }

        private void ReleaseChargedFire()
        {
            Instantiate(_chargedFire, _firePoint.position, _firePoint.rotation);
        }

    }
}
