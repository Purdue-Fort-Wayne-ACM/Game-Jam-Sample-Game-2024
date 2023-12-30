using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour {

    #region Public Data
    [Header("User Attributes")]
    [SerializeField, Range(0, 10), Min(0)]
    float Speed = 1;
    [SerializeField, Range(0, 50), Min(0)]
    float Aggression = 25;

    [Header("Melee Attributes")]
    [SerializeField, Range(1, 10), Min(1)]
    float Health = 3;
    [Range(0, 10)]
    public float AttackStrength = 1;
    [SerializeField, Min(0)]
    public Vector2 ThrowbackIntensity = new Vector2(10, 15);
    [SerializeField]
    bool Enraged = false;

    [Header("Battle AI")]
    [SerializeField]
    Player PlayerLocation;
    #endregion

    #region Private Data
    Transform PlayerPosition;
    Rigidbody2D Rb;
    #endregion

    #region Methods
    /// <summary>
    /// This will calculate if the player is to the left or right of the enemy
    /// </summary>
    /// <returns>TRUE if the player is to the left, FALSE if the player is to the right</returns>
    bool PlayerToLeft() { return Vector3.Dot(Vector3.Cross(transform.position, PlayerPosition.position), Vector3.forward) < 0; }
    #endregion

    #region Unity Events
    // Start is called before the first frame update
    void Start() {
        PlayerPosition = PlayerLocation.transform;
        Rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update() {

        if (Engine.IsModal) return;

        Enraged = Vector2.Distance(transform.position, PlayerPosition.position) < Aggression;

        if (Enraged) {
            // TODO
            if (transform.rotation.z == 0)
                transform.Rotate(0, 0, PlayerToLeft() ? 15 : -15);
        } else {
            if (transform.rotation.z != 0) 
                transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (Engine.IsModal) return;
        
        // TODO
    }

    #endregion
}
