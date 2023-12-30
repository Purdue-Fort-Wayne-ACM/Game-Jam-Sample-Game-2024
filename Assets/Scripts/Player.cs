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

        if (Engine.IsModal) return;
        
        Rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, Rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !IsJumping) {
            IsJumping = true;
            Rb.velocity = new Vector2(Rb.velocity.x, JumpIntensity);
        }

        IsJumping = Rb.velocity.y != 0;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (Engine.IsModal) return;

        if (collision.gameObject.GetComponent<Enemy>() != null) {
            Health -= collision.GetComponent<Enemy>().AttackStrength;
            Rb.velocity = collision.GetComponent<Enemy>().ThrowbackIntensity;
        }
        if (Health <= 0) {
            //Game Over
            Debug.Log("Game Loss");
            FindObjectOfType<MainMenuUIController>().EndGameScreens[0].SetActive(true);
            Engine.IsModal = true;
        }
    }
    #endregion
}
