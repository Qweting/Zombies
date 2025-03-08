using UnityEngine;
public class Powerups : MonoBehaviour
{
    //panel properties
    private readonly float _speed = 1f;
    private readonly float _damage = 30f;
    private  Vector3 _targetPosition;


    public GameObject panel;

    void Update()
    { 
        //move panels towards the player
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y, _targetPosition.z);
        gameObject.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);
        Instantiate(panel, new Vector3(0, 0, 0), Quaternion.identity);
        
        //TODO:set false, damage player, set perk.  
        if (transform.position.z <= 2)
            Destroy(gameObject);
        
    }

    public float Health { get; set; }


    public float FireRateMultiplier { get; set; }

    public float DamageMultiplier { get; set; }

    public int PlayerMultiplier { get; set; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (Health >= 0)
                Health -= 2;
            else
                Destroy(gameObject);
        }
    }

}

