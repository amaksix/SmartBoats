using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PirateLogic : AgentLogic
{
    #region Static Variables
    private static float _boxPoints = 1f;
    private static float _boatPoints = 5.0f;
    private static float _enemyPoints = 7.0f;
    #endregion
    public float ScaleMultiplier;
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
        AgentData data = this.GetData();
        ScaleMultiplier = data.size / 100;
        gameObject.transform.localScale = gameObject.transform.localScale * ScaleMultiplier;
    }

    public override float RecalculateEnemyFactors(float distanceIndex, float enemyDistanceFactor, GameObject collidedObj)
    {
        if (GetData().size > collidedObj.GetComponent<PirateLogic>().GetData().size)
        {
            return distanceIndex * enemyDistanceFactor + GetData().enemyWeight;
        }
        else
        {
            return distanceIndex * enemyDistanceFactor - GetData().enemyWeight;
        }
        return distanceIndex * enemyDistanceFactor + GetData().enemyWeight;
    }
 
    private void OnCollisionEnter(Collision other)
    {
        AgentData data = this.GetData();
        if (other.gameObject.tag.Equals("Boat"))
        {
            points += _boatPoints;
            Debug.Log("Killed boat");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (other.gameObject.GetComponent<PirateLogic>().GetData().size < data.size)
            {
                points += _enemyPoints;
                other.gameObject.GetComponent<PirateLogic>().points -= _enemyPoints/2;
                Destroy(other.gameObject);
            }


        }
    }

}