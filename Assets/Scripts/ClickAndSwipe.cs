using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager _gameManager;
    private Camera _camera;
    private Vector3 _mousePos;
    private TrailRenderer _trail;
    private BoxCollider _collider;
    private bool _swiping = false;

    // Note: The Start method was renamed to Awake.
    void Awake()
    {
        _camera = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _collider = GetComponent<BoxCollider>();
        _trail.enabled = false;
        _collider.enabled = false;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _swiping = false;
                UpdateComponents();
            }
            if (_swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        _mousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = _mousePos;
    }

    void UpdateComponents()
    {
        _trail.enabled = _swiping;
        _collider.enabled = _swiping;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            // Destroy the target
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
