using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjects : MonoBehaviour
{

    private Rigidbody targetBodies;
    private GameManager gameManagerScript;
    public ParticleSystem explosionParticle;

    public float objSpeedLimit = 15f;
    public float objRotationLimit = 10f;
    public float xLimitLeft = -4f;
    public float xLimitRight = 5f;
    public float yLimitUp = 9f;
    public float yLimitDown = 1f;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetBodies = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        MoveObject();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MoveObject()
    {

        targetBodies.AddForce(Vector3.up * Random.Range(10, objSpeedLimit), ForceMode.Impulse);
        targetBodies.AddTorque(RandomVectorGeneration(), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 5), 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            if(gameManagerScript.isGameActive)    
                gameManagerScript.UpdateLives();
        }
    }

    private void OnMouseDown()
    {
        if (gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManagerScript.UpdateScore(pointValue);
        }
    }

    private Vector3 RandomVectorGeneration()
    {
        Vector3 vec = new Vector3(Random.Range(-objRotationLimit, objRotationLimit),
        Random.Range(-objRotationLimit, objRotationLimit),
        Random.Range(-objRotationLimit, objRotationLimit));
        return vec;
    }
}
