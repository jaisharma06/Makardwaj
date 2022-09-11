using Makardwaj.Common;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Characters/BaseEnemy", order = 3)]
public class BaseEnemyData : BaseData
{
    public LayerMask enemyObstacleLayerMask;
    public float visionDistance = 1f;
}
