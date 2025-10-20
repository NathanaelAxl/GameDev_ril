using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float boostMultiplier = 2f;
    
    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float cameraHeight = 3f;
    [SerializeField] private float cameraSmoothSpeed = 10f;
    
    [Header("Camera Rotation Settings")]
    [SerializeField] private float mouseRotationSpeed = 3f;
    [SerializeField] private float minVerticalAngle = -20f;
    [SerializeField] private float maxVerticalAngle = 80f;
    
    [Header("Camera Zoom Settings")]
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float minZoomDistance = 3f;
    [SerializeField] private float maxZoomDistance = 15f;
    
    private Rigidbody rb;
    private bool isGrounded;
    private float currentZoomDistance = 7f;
    private bool isBoosting = false;
    
    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 20f;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FindAndAssignCamera();
    }

    void Update()
    {
        if (SettingsMenu.isGamePaused) return;

        HandleCameraZoom();
        HandleCameraRotation();
        isBoosting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (!SettingsMenu.isGamePaused && Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void FixedUpdate()
    {
        if (cameraTransform == null)
        {
            return;
        }
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal);

        if (movement.magnitude > 0.1f)
        {
            float currentMoveForce = isBoosting ? moveForce * boostMultiplier : moveForce;
            float currentMaxSpeed = isBoosting ? maxSpeed * boostMultiplier : maxSpeed;
            
            rb.AddForce(movement * currentMoveForce, ForceMode.Force);
            
            if (rb.linearVelocity.magnitude > currentMaxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * currentMaxSpeed;
            }
        }

        UpdateCamera();
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindAndAssignCamera();
    }
    
    void FindAndAssignCamera()
    {
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
            Debug.Log("Main Camera ditemukan dan ditetapkan di scene: " + SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.LogError("Tidak ada kamera dengan Tag 'MainCamera' di scene ini!");
        }
    }

    void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        currentHorizontalAngle += mouseX * mouseRotationSpeed;
        currentVerticalAngle -= mouseY * mouseRotationSpeed;
        
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);
    }

    void HandleCameraZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        if (scrollInput != 0f)
        {
            currentZoomDistance -= scrollInput * zoomSpeed;
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        }
    }

    void UpdateCamera()
    {
        if (cameraTransform != null)
        {
            Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
            
            Vector3 direction = rotation * Vector3.back;
            Vector3 targetPosition = transform.position + (direction * currentZoomDistance) + (Vector3.up * cameraHeight);
            
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, cameraSmoothSpeed * Time.deltaTime);
            
            cameraTransform.LookAt(transform.position + Vector3.up * cameraHeight);
        }
    }
}

