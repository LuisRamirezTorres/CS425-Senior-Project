using TMPro;
using UnityEngine;

public class DartboardScore : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject floatingScorePrefab;
    
    [SerializeField]
    private GameObject resetCamera;
    
    [SerializeField]
    private GameObject setCamera;
    
    [SerializeField]
    private TMP_Text scoreText;
    
    [SerializeField]
    private string scoreStr = "Score: ";
    
    [SerializeField]
    private MeshCollider meshCollider;
    
    [SerializeField]
    private Camera mainCamera;
    
    public Vector3 cameraPos;
    public Vector3 dartPrefabPos;

    private int currentScore;
    private Mesh mesh;
    private Bounds bounds;
    private float colliderRadius;
    private Vector3 colliderCenter;
    
    private float angle;
    
    [Header("Audio")]
    [SerializeField]
    private AudioSource audioSource;
    
    [SerializeField]
    private AudioClip sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = scoreStr + currentScore.ToString();

        cameraPos = mainCamera.transform.position;

        meshCollider = GetComponent<MeshCollider>();
        colliderCenter = meshCollider.bounds.center;
        colliderRadius = meshCollider.bounds.extents.y;
        
        Debug.Log("colliderCenter: " + colliderCenter);
        Debug.Log("colliderRadius: " + colliderRadius);

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreStr + (currentScore).ToString();
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision detected: " + collider);
        
        audioSource.clip = sfx;
        audioSource.Play();
        
        // Get dart's pos after collision detected
        Vector3 dartPos = collider.gameObject.transform.position;
        dartPrefabPos = dartPos;
        
        // Transform MainCamera to collider's position
        setCamera.SetActive(true);
        // Transform MainCamera to original position
        resetCamera.SetActive(true);
        
        Debug.Log("dartPos: " + dartPos);
        float dartPosY = dartPos.y;
        float dartPosZ = dartPos.z;
        
        // Check if collider hit bullseye
        if (IsBull(dartPos))
        {
            int bullScore = CheckBull(dartPos);
            currentScore += bullScore;
            ShowFloatingScore(dartPos, bullScore);
        }
        else
        {
            // Get the dart's distance from the bullseye
            int distanceScore = CheckDistance(dartPos);
        
            // Get the dart's angle of the dartboard's collider from 0 to 360
            angle = GetDartAngle(dartPosY, dartPosZ);
            Debug.Log("Angle: " + angle);
        
            // Check the angle to return the correct score
            int angleScore = CheckAngle();
        
            // Temp score used to show pop up score when dart collides with the dartboard
            int tempScore = angleScore * distanceScore;
            currentScore += tempScore;
            ShowFloatingScore(dartPos, tempScore);
        }

        collider.gameObject.transform.rotation = Quaternion.Euler(0,-90,0);
        // Disable dart collider so darts can't stack on top of each other
        collider.gameObject.GetComponent<Collider>().enabled = false;

    }

    private int CheckBull(Vector3 dartPos)
    {
        var distanceScore = 0;
        
        // Get the distance between the dart and center of dartboard
        float dartDistanceFromCenter = Vector3.Distance(dartPos, colliderCenter);
        Debug.Log("Dart distance from center: " + dartDistanceFromCenter);
        
        if (dartDistanceFromCenter is <= 0.0963f and > 0f) // Inner Bull
            distanceScore = 50;
        
        Debug.Log("distanceScore: " + distanceScore);
        return distanceScore;
    }

    private bool IsBull(Vector3 dartPos)
    {
        bool isBull = false;
        
        float dartDistanceFromCenter = Vector3.Distance(dartPos, colliderCenter);
        Debug.Log("Dart distance from center: " + dartDistanceFromCenter);

        if (dartDistanceFromCenter is <= 0.0963f and > 0f)
            isBull = true;
        
        return isBull;
    }

    private float GetDartAngle(float dartPosY, float dartPosZ)
    {
        // Use arc tan2 to get the angle of dart on dartboard
        float degrees = Mathf.Atan2(dartPosY - colliderCenter.y, dartPosZ - colliderCenter.z) * 180 / Mathf.PI;
        degrees = (degrees + 360) % 360;
        return degrees;
    }

    private int CheckDistance(Vector3 dartPos)
    {
        var distanceScore = 0;
        
        float dartDistanceFromCenter = Vector3.Distance(dartPos, colliderCenter);
        Debug.Log("Dart distance from center: " + dartDistanceFromCenter);
        
    

        if (dartDistanceFromCenter is <= 0.43f and > 0.37f)
            distanceScore = 3;
        else if (dartDistanceFromCenter is < 0.65f and > 0.60f)
            distanceScore = 2;
        else
            distanceScore = 1;
        
        Debug.Log("distanceScore: " + distanceScore);
        return distanceScore;
    }

    private int CheckAngle()
    {
        // Each slice of the dartboard is sectioned by 18 degrees
        var angleScore = 0;
        
        if (angle is < 360.0f and > 351.0f)
            angleScore = 11;
        if (angle is < 9.0f and > 0.0f)
            angleScore = 11;
        if (angle is < 27.0f and > 9.0f)
            angleScore = 14;
        if (angle is < 45.0f and > 27.0f)
            angleScore = 9;
        if (angle is < 63.0f and > 45.0f)
            angleScore = 12;
        
        if (angle is < 81.0f and > 63.0f)
            angleScore = 5;
        if (angle is < 99.0f and > 81.0f)
            angleScore = 20;
        if (angle is < 117.0f and > 99.0f)
            angleScore = 1;
        if (angle is < 135.0f and > 117.0f)
            angleScore = 18;
        
        if (angle is < 153.0f and > 135.0f)
            angleScore = 4;
        if (angle is < 171.0f and > 153.0f)
            angleScore = 13;
        if (angle is < 189.0f and > 171.0f)
            angleScore = 6;
        if (angle is < 207.0f and > 189.0f)
            angleScore = 10;
        
        if (angle is < 225.0f and > 207.0f)
            angleScore = 15;
        if (angle is < 243.0f and > 225.0f)
            angleScore = 2;
        if (angle is < 261.0f and > 243.0f)
            angleScore = 17;
        if (angle is < 279.0f and > 261.0f)
            angleScore = 3;
        
        if (angle is < 297.0f and > 279.0f)
            angleScore = 19;
        if (angle is < 315.0f and > 297.0f)
            angleScore = 7;
        if (angle is < 333.0f and > 315.0f)
            angleScore = 16;
        if (angle is < 351.0f and > 333.0f)
            angleScore = 8;

        Debug.Log("angleScore: " + angleScore);
        return angleScore;
    }

    void ShowFloatingScore(Vector3 dartPos, int tempScore)
    {
        var floatingText = Instantiate(floatingScorePrefab, dartPos, Camera.main.transform.rotation);
        floatingText.GetComponent<TMP_Text>().text = tempScore.ToString();
    }
}
