using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerPrefab;
    public GameObject myplat;

    public SatgeManager satgeManager;

    // Start is called before the first frame update
    public void Start()
    {
        satgeManager = GetComponent<SatgeManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myplat = (GameObject)Instantiate(PlayerPrefab, new Vector2(Random.Range(-2.0f, 2.0f), Player.transform.position.y + (10 + Random.Range(0.5f, 1f))), Quaternion.identity);

        Destroy(collision.gameObject);

    }

}