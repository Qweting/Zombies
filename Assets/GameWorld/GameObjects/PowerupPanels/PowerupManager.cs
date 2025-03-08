using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Transform[] anchors;
    public GameObject leftPanel; 
    public GameObject rightPanel; 
    
    public WeaponController weapon;
    private int _perkType;
    private bool _setFireRate = false;
    private bool _setDamage = false;
    private bool _setPlayerMultiplier = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindWithTag("Weapon").GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
         * Check if helath is 0 otherwise it doesn't work. 
         */
        

        // if (leftPanel.gameObject.transform.position.z <= 5)
        // {
        //     Destroy(GameObject.FindWithTag("Player")); //change the player, remove camera from player otherwise it desotry the camera
        // }

    }

    public void SpawnPowerup()
    {
        Instantiate(leftPanel, anchors[0].position, Quaternion.identity);
        Instantiate(rightPanel, anchors[1].position, Quaternion.identity);
    }

    private void AssignPerk(Powerups panel)
    {
        if (_setFireRate)
        {
            weapon.FireRate = panel.FireRateMultiplier;
            Debug.LogError($"{weapon.FireRate} firerate");
        }
    }

    private void SetPanelPerks()
    {
        // AssignRandomPerk(leftPanel);
        // AssignRandomPerk(rightPanel);     
    }

    //we assign random perks to the panels
    private void AssignRandomPerk(Powerups panel)
    {
         _perkType = Random.Range(0, 100); 
        // panel.Health = Random.Range(10, 100);
        panel.Health = Random.Range(10, 11);

        switch (_perkType)
        {
            case <= 25: //25% chance
                panel.FireRateMultiplier = 0;
                panel.DamageMultiplier = 0;
                panel.PlayerMultiplier = Random.Range(1, 4); //player multiplier
                _setPlayerMultiplier = true;
                break;
            case > 25  and <= 50:
                panel.FireRateMultiplier = Random.Range(0.5f, 6f); //fire rate multiplier
                panel.DamageMultiplier = 0;
                panel.PlayerMultiplier = 0;
                _setFireRate = true;
                break;
            case > 50:
                panel.FireRateMultiplier = 0;
                panel.DamageMultiplier = Random.Range(0.2f, 2f); //damage multiplier
                panel.PlayerMultiplier = 0;
                _setDamage = true;
                break;
        }
    }

    
    
}
