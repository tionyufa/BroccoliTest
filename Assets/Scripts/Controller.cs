using UnityEngine;


public class Controller : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float MaxX, MaxY, MinX, MinY,Sensor,MinSize,MaxSize;
    

    private Vector2 _startPos;
    private bool _isMove = true;
    private void Start()
    {
       _camera.transform.position = new Vector3(20,-1,-10f);
        
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
         if (Input.GetMouseButtonDown(0))
         {
             _startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
         } 
         else if (Input.GetMouseButton(0))
         {
             float posX = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPos.x;
             float posY = _camera.ScreenToWorldPoint(Input.mousePosition).y - _startPos.y;
             var cameraPosition = _camera.transform.position;
             float cameraX = Mathf.Clamp(cameraPosition.x - posX, MinX, MaxX);
             float cameraY = Mathf.Clamp(cameraPosition.y - posY, MinY, MaxY);
             _camera.transform.position = new Vector3(cameraX,cameraY,cameraPosition.z);
         }

         if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 || Input.GetAxisRaw("Mouse ScrollWheel") < 0)
         {
             float _size = _camera.orthographicSize + -Input.GetAxisRaw("Mouse ScrollWheel") * Sensor * Time.fixedDeltaTime;
             _camera.orthographicSize = Mathf.Clamp(_size, MinSize, MaxSize);
         }
    }

    public void setIsMove(bool isMove)
    {
        _isMove = isMove;
    }
}
