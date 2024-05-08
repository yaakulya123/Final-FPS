using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Movement speed
    public float mouseSensitivity = 100f; // Mouse sensitivity

    [Header("Positions")]
    public Transform playerBody; // Reference to the player's main body
    public Transform gun; // Reference to the gun child object

    private Rigidbody rb;
    private Camera playerCamera;
    public Gun gunScript;

    private float verticalLookRotation = 0f; // Used to store vertical rotation

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>(); // Get the first camera in children
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen

        // Assign playerBody if not already assigned (assuming it's the parent of the camera)
        if (playerBody == null)
            playerBody = transform.parent;
    }

    void Update()
    {
        Movement();
        PlayerHealth();
    }

    void Movement()
    {
        // Player Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = playerBody.right * moveX;
        Vector3 moveVertical = playerBody.forward * moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * moveSpeed;
        rb.MovePosition(rb.position + velocity * Time.deltaTime);

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body around the Y axis (horizontal movement)
        playerBody.Rotate(Vector3.up * mouseX);

        // Calculate vertical rotation separately to avoid gimbal lock
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -40f, 20f); // Limit vertical rotation

        // Apply vertical rotation to the camera
        playerCamera.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);

        // Apply vertical rotation to the gun
        if (gun != null)
            gun.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);

    }

    void PlayerHealth()
    {
        healthText.text = "Health: " + currentHealth.ToString();

        if(currentHealth <= 0)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AmmoBox"))
        {
            gunScript.maxAmmo += 20;
            gunScript.ammoText.text = "Ammo: " + gunScript.currentAmmo + "/" + gunScript.maxAmmo;

            Destroy(other.gameObject);
        }
    }
}
