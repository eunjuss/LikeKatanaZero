using Unity.VisualScripting;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    // 충돌 처리
    // trigger 충돌이 일어났을 때 통과
    // Collision 충돌이 일어났을 때 통과 X

    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

}
