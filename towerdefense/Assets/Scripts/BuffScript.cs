
using UnityEngine;
public class BuffScript : MonoBehaviour
{
    public float buffTowerRange = 50f;

    public float damageBuffPercent = 1.1f;
    public float rangeBuffPercent = 1.1f;



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, buffTowerRange);
    }

    private void Start()
    {
        
    }
    void BuffTowers()
    {

        //target.GetComponent<DamageSystem>().damageEnemy((int)bulletDamage, slowEnemies, slowTime);

        Collider[] exColliders = Physics.OverlapSphere(transform.position, buffTowerRange);
        for (int i = 0; i < exColliders.Length; i++)
        {
            
            if (exColliders[i].name.Contains("Minigun") && !exColliders[i].name.Contains("MinigunUpgradeMenu"))
            {
                Debug.Log(exColliders[i]);
                Debug.Log(this.name);
                Debug.Log(Vector3.Distance(exColliders[i].transform.position, transform.position));
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
                exColliders[i].gameObject.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;

            }
            if (exColliders[i].name.Contains("Tank") && !exColliders[i].name.Contains("TankUpgradeMenu"))
            {
                Debug.Log(exColliders[i]);
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
                exColliders[i].gameObject.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;
            }
            if (exColliders[i].name.Contains("MissileLauncher") && !exColliders[i].name.Contains("MissileLauncherMenu"))
            {
                Debug.Log(exColliders[i]);
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
                exColliders[i].gameObject.GetComponent<attackEnemy>().attackRange *= rangeBuffPercent;
            }
            if (exColliders[i].name.Contains("ZapTower") && !exColliders[i].name.Contains("ZapTowerUpgradeMenu"))
            {
                Debug.Log(exColliders[i]);
                exColliders[i].gameObject.GetComponent<attackEnemy>().damage *= damageBuffPercent;
            }
        }


    }

    // Update is called once per frame
    void Awake()
    {
        BuffTowers();
    }

}
