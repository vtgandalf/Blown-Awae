using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // SOUNDS

    [SerializeField] private AudioPlayer AudioPlayer;

    // END SOUNDS
    private Player player;
    public ScoreManager scoreManager;
    
    public float speed;

    public BombSettings bombSettings;
    public VirtualInput input;

    private Rigidbody rb;
    private PhysicMaterial physicMaterial;
    private float distToGround;

    private int touchingSlipperyTiles = 0;
    private bool moving = false;

    private float cooldownTimerBigBomb;
    private float cooldownTimerThrowingBomb;
    private float throwCharge = 0f;

    public float ThrowCharge(){ return throwCharge/bombSettings.maxCharge; }

    public void SetVirtualInput(VirtualInput vi)
    {
        if (input)
        {
            input.OnBigBombDown.RemoveAllListeners();
            input.OnThrowingBombUp.RemoveAllListeners();
            input.OnStartDown.RemoveAllListeners();
            input.OnThrowingBombDown.RemoveAllListeners();
        }

        input = vi;
        input.OnBigBombDown.AddListener(OnBigBombDown);
        input.OnThrowingBombUp.AddListener(OnThrowingBombUp);
        input.OnStartDown.AddListener(OnStartDown);
        input.OnThrowingBombDown.AddListener(OnThrowingBombDown);
    }

    void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        CapsuleCollider capCol = GetComponent<CapsuleCollider>();
        physicMaterial = capCol.material;
        distToGround = capCol.bounds.extents.y;
        cooldownTimerBigBomb = bombSettings.cooldownBigBomb;
        cooldownTimerThrowingBomb = bombSettings.cooldownThrowingBomb;
    }

    void FixedUpdate()
    {
        input.CheckForInput();

        Move();

        if (input.ThrowingBombHold && throwCharge < bombSettings.maxCharge && cooldownTimerThrowingBomb >= bombSettings.cooldownThrowingBomb)
        {
            throwCharge += Time.fixedDeltaTime * bombSettings.chargeRate;
            throwCharge = Mathf.Min(throwCharge, bombSettings.maxCharge);
        }

        cooldownTimerThrowingBomb += Time.fixedDeltaTime;
        cooldownTimerBigBomb += Time.fixedDeltaTime;
    }

    private void ApplyBombEffect(Bomb bomb)
    {
        if (player.bombEffect != null)
        {
            bomb.bombEffect = player.bombEffect;
            player.bombEffect = null;
        }
    }

    private void OnBigBombDown()
    {
        if (cooldownTimerBigBomb < bombSettings.cooldownBigBomb)
            return;

        Bomb bomb = Instantiate(player.bigBomb, transform.position + transform.forward, transform.rotation);
        ApplyBombEffect(bomb);

        cooldownTimerBigBomb = 0f;

        bomb.Owner = player;

        // audio
        //AudioPlayer.PlaySound(0);
    }
    
    private void OnThrowingBombDown()
    {
        // audio
    }
    private void OnThrowingBombUp()
    {
        if (cooldownTimerThrowingBomb < bombSettings.cooldownThrowingBomb)
            return;

        ThrowingBomb bomb = Instantiate(player.throwingBomb, transform.position + transform.forward, transform.rotation) as ThrowingBomb;
        ApplyBombEffect(bomb);
        bomb.Throw(bombSettings.throwForce + throwCharge, bombSettings.throwUpForce, bombSettings.maxBounces);

        throwCharge = 0f;
        cooldownTimerThrowingBomb = 0f;

        bomb.Owner = player;

        // audio
        AudioPlayer.PlaySound(1);
    }

    private void OnStartDown()
    {
        if(scoreManager.RounHasEnded)
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

    private void Move()
    {
        float horizontal = input.GetHorizontal();
        float vertical = input.GetVertical();

        Vector3 direction = new Vector3(horizontal, 0f, vertical);;

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            // Calculates the next position the player is going to be next frame
            Vector3 nextPos = rb.position + (direction.normalized * speed * Time.fixedDeltaTime);

            if (CanMove(nextPos))
            {
                rb.MovePosition(nextPos);
                moving = true;
            }
            else moving = false;
        }
        else moving = false;
    }

    private bool CanMove(Vector3 nextPos)
    {
        return IsGrounded(transform.position) && IsGrounded(nextPos) && touchingSlipperyTiles <= 0;
    }

    private bool IsGrounded(Vector3 startPos)
    {
        // Checks if there is ground under the player based on the given position
        if (Physics.Raycast(startPos, Vector3.down, out RaycastHit hit, distToGround + 1f))
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Tile tile = collision.gameObject.GetComponent<Tile>();
        if (tile && tile.slippery)
        {
            touchingSlipperyTiles++;
            physicMaterial.staticFriction = 0f;
            physicMaterial.dynamicFriction = 0f;
            if (moving && rb.velocity.magnitude < speed)
            {
                rb.velocity = transform.forward * speed;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Tile tile = collision.gameObject.GetComponent<Tile>();
        if (tile && tile.slippery)
        {
            Invoke("RemoveSlipperyTile", 0.1f);
        }
    }

    private void RemoveSlipperyTile()
    {
        touchingSlipperyTiles = Mathf.Max(touchingSlipperyTiles - 1, 0);
        if (touchingSlipperyTiles == 0)
        {
            physicMaterial.staticFriction = 1f;
            physicMaterial.dynamicFriction = 1f;
        }
    }

    public void PlayThrowingExplosion()
    {
        AudioPlayer.PlaySound(2);
    }
    public void PlayBigExplosion()
    {
        AudioPlayer.PlaySound(3);
    }

}
