using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float jumpForce = 5f;
    
    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float cameraHeight = 3f;
    [SerializeField] private float cameraSmoothSpeed = 10f;
    
    [Header("Camera Rotation Settings")]
    [SerializeField] private float mouseRotationSpeed = 3f;
    [SerializeField] private float minVerticalAngle = -20f;  // Batas bawah
    [SerializeField] private float maxVerticalAngle = 80f;   // Batas atas
    [SerializeField] private float cameraResetSpeed = 10f;   // Kecepatan reset kamera
    
    [Header("Camera Zoom Settings")]
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float minZoomDistance = 3f;
    [SerializeField] private float maxZoomDistance = 15f;
    [SerializeField] private float zoomSmoothSpeed = 10f;
    
    private Rigidbody rb;
    private bool isGrounded;
    private float currentZoomDistance = 7f;
    private bool isBoosting = false;
    
    // Rotation variables
    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Setup camera
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
        
        // Lock cursor di tengah layar (opsional, comment jika tidak ingin)
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void Update()
    {

        
        // Handle camera zoom dengan scroll wheel
        HandleCameraZoom();
        
        // Handle camera rotation dengan mouse
        HandleCameraRotation();
        
        // Deteksi boost (Shift)
        isBoosting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        
        // Toggle cursor lock dengan tombol Escape (opsional)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        // Lock cursor lagi dengan klik kiri (opsional)
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void FixedUpdate()
    {
        // Ambil input dari keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Dapatkan arah kamera untuk movement relatif terhadap kamera
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        
        // Hilangkan komponen Y agar tidak bergerak naik/turun
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Hitung arah movement
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal);

        // Apply force ke bola dengan boost jika Shift ditekan
        if (movement.magnitude > 0.1f)
        {
            float currentMoveForce = isBoosting ? moveForce * boostMultiplier : moveForce;
            float currentMaxSpeed = isBoosting ? maxSpeed * boostMultiplier : maxSpeed;
            
            rb.AddForce(movement * currentMoveForce, ForceMode.Force);
            
            // Batasi kecepatan maksimal
            if (rb.linearVelocity.magnitude > currentMaxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * currentMaxSpeed;
            }
        }

        // Update posisi kamera
        UpdateCamera();
    }

    void HandleCameraRotation()
    {
        // Dapatkan input mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        // Update angles
        currentHorizontalAngle += mouseX * mouseRotationSpeed;
        currentVerticalAngle -= mouseY * mouseRotationSpeed;
        
        // Clamp vertical angle agar tidak terlalu atas atau bawah
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);
    }

    void HandleCameraZoom()
    {
        // Dapatkan input scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        if (scrollInput != 0f)
        {
            // Update zoom distance
            currentZoomDistance -= scrollInput * zoomSpeed;
            
            // Clamp agar tidak melebihi batas min/max
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        }
    }

    void UpdateCamera()
    {
        if (cameraTransform != null)
        {
            // Hitung rotasi kamera berdasarkan angles
            Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
            
            // Hitung posisi kamera berdasarkan rotasi dan zoom
            Vector3 direction = rotation * Vector3.back; // Vector3.back = (0, 0, -1)
            Vector3 targetPosition = transform.position + (direction * currentZoomDistance) + (Vector3.up * cameraHeight);
            
            // Smooth camera movement
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, cameraSmoothSpeed * Time.deltaTime);
            
            // Kamera selalu melihat ke bola
            cameraTransform.LookAt(transform.position + Vector3.up * cameraHeight);
        }
    }

    
}