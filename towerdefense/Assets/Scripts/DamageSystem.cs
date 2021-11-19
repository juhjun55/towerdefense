using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem damageInstance;
    float timer = 0f;
   
    bool timeToDie;
    int i = 1;
    private GameObject[] deathpoints = new GameObject[9];
    GameEngine gameEngine;
    Enemy1Params enemy1params;
    Enemy2Params enemy2params;
    Enemy3Params enemy3params;
    Waypoints wpInstance;
    private float normalEnemySpeed;


    private void Awake()
    {
        gameEngine = gameObject.GetComponent<GameEngine>();
    }


    void Start()
    {

        enemy1params = gameObject.GetComponent<Enemy1Params>();
        enemy2params = gameObject.GetComponent<Enemy2Params>();
        enemy3params = gameObject.GetComponent<Enemy3Params>();
        wpInstance = gameObject.GetComponent<Waypoints>();
        
        deathpoints[0] = GameObject.Find("Finish 1");
        deathpoints[1] = GameObject.Find("Finish 2");
        deathpoints[2] = GameObject.Find("Finish 3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(deathpoints[0].transform.position, transform.position) < 1)
        {        
            Destroy(gameObject);
            GameEngine.gameInstance.DamagePlayer(1);

        }
        if (Vector3.Distance(deathpoints[1].transform.position, transform.position) < 1)
        {        
            Destroy(gameObject);
            GameEngine.gameInstance.DamagePlayer(1);
        }

        if (Vector3.Distance(deathpoints[2].transform.position, transform.position) < 1)
        {
            Destroy(gameObject);
            GameEngine.gameInstance.DamagePlayer(1);
        }
    }

    void FixedUpdate()
    {
        
        if (timeToDie)
        {
            Waypoints.wPInstanceRunning.speedMultiplier = 0;
            Destroy(gameObject);
            if (timer < 0.01)
            {
                timer += Time.deltaTime;
            }
            else
            {
                this.gameObject.transform.localScale += new Vector3(i, 0, i);

                timer = 0;

                i++;

                if (i >= 6)
                {
                    
                    timeToDie = false;
                    
                }
            }
        }

    }


    public IEnumerator slowTimer(float slowTime,float slowAmount,Waypoints wpInstance)
    {
            

            Debug.Log("slowTimer");
            Debug.Log(wpInstance.speedMultiplier + "noppeus enne");
            wpInstance.speedMultiplier += slowAmount;
            Debug.Log(wpInstance.speedMultiplier + "noppeus jälkee");
            yield return new WaitForSeconds(slowTime);
            wpInstance.speedMultiplier = 1f;
            
    }
   
    public void damageEnemy(int attackDamage, float slowAmount, float slowTime)
    {
        
        //Enemy1Params.enemy1HitInstance = this.gameObject;
        if(this.gameObject.name.Contains("Enemy 1"))
        {          
            enemy1params.Enemy1NewInstance();

            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;   
            Enemy1Params.enemy1HitInstance.health -= attackDamage;            
            
            if (Enemy1Params.enemy1HitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                timeToDie = true;
            }
            if(slowAmount < 0 && wpInstance.speedMultiplier == apu)
            {
                
                StartCoroutine(slowTimer(slowTime,slowAmount,wpInstance));
               
            }
        }
        else if (this.gameObject.name.Contains("Enemy 2"))
        {
            enemy2params.Enemy2NewInstance();
            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;

            Enemy2Params.enemy2HitInstance.health -= attackDamage;
            if (Enemy2Params.enemy2HitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                timeToDie = true;
            }
             if(slowAmount < 0 && wpInstance.speedMultiplier == apu)
            {
                
                StartCoroutine(slowTimer(slowTime,slowAmount,wpInstance));
               
            }
        }
        else if (this.gameObject.name.Contains("Enemy 3"))
        {
            enemy3params.Enemy3NewInstance();

            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;
          
            Enemy3Params.enemy3HitInstance.health -= attackDamage;
            
            if (Enemy3Params.enemy3HitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                timeToDie = true;
            }
            if(slowAmount < 0 && wpInstance.speedMultiplier == apu)
            {
                
                StartCoroutine(slowTimer(slowTime,slowAmount,wpInstance));
               
            }
        }



    }

   

}
