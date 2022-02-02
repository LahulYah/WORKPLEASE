
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBoarder = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;


    private float minX = 0f;
    private float maxX = 65f;
    private float minZ = 0f;
    private float maxZ = 75f;
    private bool canMove = true;


   
    void Update()
    {   
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;

        }

        // Permet de freeze la camera   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;

        }
        if (!canMove)
        {
            return;

        }
        // Deplacer vers l'avance (Oui back parceque je suis con et j'ai inverser dans unity)
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBoarder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        // Deplacer vers l'arriere (donc forward)
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBoarder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        // Deplacer vers gauche (Donc right)
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBoarder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        // Deplacer vers droite (Donc left)
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBoarder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1500 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;
    }
}
