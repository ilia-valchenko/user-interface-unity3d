using UnityEngine;

public class Target : MonoBehaviour
{
    private const float MinSpeed = 8.0f;
    private const float MaxSpeed = 14.0f;
    private const float TorqueRange = 10.0f;
    private const float XRange = 4.0f;
    private const float YSpawnPosition = 0.0f;

    private GameManager _gameManager;

    public int scoreValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(this.GetRandomForceVector(), ForceMode.Impulse);
        rigidBody.AddTorque(this.GetRandomTorque(), this.GetRandomTorque(), this.GetRandomTorque(), ForceMode.Impulse);
        transform.position = this.GetRandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Vector3 GetRandomForceVector()
    {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    }

    private float GetRandomTorque()
    {
        return Random.Range(-TorqueRange, TorqueRange);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-XRange, XRange), -YSpawnPosition, 0);
    }

    //private void OnMouseDown()
    //{
    //    if (_gameManager.isGameActive)
    //    {
    //        Destroy(gameObject);
    //        _gameManager.UpdateScore(this.scoreValue);
    //        Instantiate(this.explosionParticle, transform.position, transform.rotation);
    //    }
    //}

    //private void OnMouseUp()
    //{
    //}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("bad") && _gameManager.isGameActive)
        {
            _gameManager.UpdateLives(-1);
        }
    }

    public void DestroyTarget()
    {
        if (_gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.UpdateScore(this.scoreValue);
        }
    }
}
