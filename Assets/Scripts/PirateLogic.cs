using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PirateLogic : AgentLogic
{
    #region Static Variables
    private static float _boxPoints = 1f;
    private static float _boatPoints = 5.0f;
    private static float _enemyPoints = 7.0f;
    private static float minPirateWeight = 50;
    private static float maxPirateWeight = 150;
    #endregion
    public float Weight;
    public float SceleMultiplier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Box"))
        {
            Debug.Log("BoxTaken");
            points += _boxPoints;
            Destroy(other.gameObject);
        }
    }
    public void ApplyScalingAndWeight()
    {
        Weight = Random.Range(minPirateWeight, maxPirateWeight);
        SceleMultiplier = Weight / 100;
        gameObject.transform.localScale = gameObject.transform.localScale * SceleMultiplier;
    }

    public override float RecalculateEnemyFactors(float distanceIndex, float enemyDistanceFactor, GameObject collidedObj)
    {
        if (Weight > collidedObj.GetComponent<PirateLogic>().Weight)
        {
            return distanceIndex * enemyDistanceFactor + GetEnemyWeight();
        }
        else
        {
            return distanceIndex * enemyDistanceFactor - GetEnemyWeight();
        }
        return distanceIndex * enemyDistanceFactor + GetEnemyWeight();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Boat"))
        {
            points += _boatPoints;
            Debug.Log("Killed boat");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (other.gameObject.GetComponent<PirateLogic>().Weight < Weight)
            {
                float firstShip = Random.Range(0, 100); //current ship chances
                float secondShip = Random.Range(0, 100); //enemy ship chances
                firstShip *= SceleMultiplier;
                secondShip *= other.gameObject.GetComponent<PirateLogic>().SceleMultiplier;
                Debug.Log("Killed pirate");
                if (firstShip > secondShip)
                {
                    points += _enemyPoints;
                    other.gameObject.GetComponent<PirateLogic>().points -= _enemyPoints/2;
                    Destroy(other.gameObject);
                }
                else
                {
                    points -= _enemyPoints;
                    other.gameObject.GetComponent<PirateLogic>().points += _enemyPoints;
                    Destroy(gameObject);
                }

            }


        }
    }

}