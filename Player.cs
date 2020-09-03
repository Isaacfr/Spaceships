using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.8f;
    private float _canFire = -0.5f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private SpawnManager _spawnManager;

    [SerializeField]
    private GameObject _tripleShotPrefab;
    private bool _isTripleShotActive = false;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public string levelToLoad;

    void Start()
    {
        transform.position = new Vector2(0, 0);

        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if(_spawnManager != null)
        {
            Debug.Log("The Spawn Manager is Null");
        }
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector2 (transform.position.x, Mathf.Clamp(transform.position.y, -1.6f, 0.5f));

        if (transform.position.x > 3.2f)
        {
            transform.position = new Vector2(3.2f, transform.position.y);
        }

        else if (transform.position.x < -3.2f)
        {
            transform.position = new Vector2(-3.2f, transform.position.y);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.42f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        
        if (health3.activeInHierarchy)
        {
            health3.SetActive(false);
            _lives -= 1;
        }
        else if (health2.activeInHierarchy)
        {
            health2.SetActive(false);
            _lives -= 1;
        }
        else
        {
            health1.SetActive(false);
            _lives -= 1;
            ApplicationLoadLevel();
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void ApplicationLoadLevel()
    {
        Application.LoadLevel(levelToLoad);
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotDown());
    }

    IEnumerator TripleShotDown()
    {
        while(_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(7.0f);
            _isTripleShotActive = false;
        }
    }
}
