using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject core;
    public GameObject startGameButton;
    public GameObject projectile;
    public float projectileSpeed;
    public float shootRate;
    

    private float lastShootTime;
    private Camera cam;
    private PlacementIndicator placementIndicator;


    public static Shoot instance;

    private void Awake()
    {   
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        core.SetActive(false);
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 )
        {
            if(Time.time - lastShootTime >= shootRate)
            {
                Shooting();
            }
        }
    }

    void Shooting()
    {
        lastShootTime = Time.time;
        GameObject proj = Instantiate(projectile, cam.transform.position, Quaternion.identity);
        proj.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed * Time.deltaTime;
        Destroy(proj, 3.0f);
    }

    public void OnPlaceCoreClicked()
    {
        core.SetActive(true);
        core.transform.position = placementIndicator.transform.position;
        placementIndicator.gameObject.SetActive(false);
        startGameButton.SetActive(false);
        EnemySpawn.instance.canSpawn = true;
    }
}
