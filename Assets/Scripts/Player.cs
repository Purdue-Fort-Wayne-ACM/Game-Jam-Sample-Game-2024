using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

    #region Public Data
    [Header("User Attributes")]
    [SerializeField, Range(0, 10), Min(0)]
    float Speed = 1;
    [SerializeField, Range(0, 100), Min(0)]
    float JumpIntensity = 10;

    [Header("Melee Attributes")]
    [SerializeField, Range(1, 10), Min(1)]
    float Health = 1;
    [Range(0, 10), Min(0)]
    public float AttackStrength = 1;
    #endregion

    #region Private Data
    Rigidbody2D Rb;
    bool IsJumping = false;
    #endregion

    #region Unity Events
    // Start is called before the first frame update
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // TODO
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (Engine.IsModal) return;

        // TODO
    }
    #endregion
}
