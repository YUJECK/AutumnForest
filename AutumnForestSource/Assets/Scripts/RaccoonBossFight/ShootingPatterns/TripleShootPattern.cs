using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    [CreateAssetMenu]
    public class TripleShootPattern : ShootingPattern
    {
        //variables 
        [SerializeField] private GameObject chestnut;
        [SerializeField] private float shootingRate = 0.5f;
        [SerializeField] private float shootingSpread = 25f;

        public override IEnumerator Pattern(Shooting shooting)
        {
            shooting.StopPointRotation(true);

            for (int i = 0; i < 3; i++)
            {
                shooting.ShootWithInstantiate(chestnut, 10, Random.Range(0, shootingSpread), 0f, ForceMode2D.Impulse);
                yield return new WaitForSeconds(shootingRate);
            }

            shooting.StopPointRotation(false);
            
            OnPatternEnd.Invoke();
        }
    }
}