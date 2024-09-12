using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class nakeController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _steerSpeed = 100;
    [SerializeField] private float _bodySpeed = 5;
    [SerializeField] private int _gap = 10;

    private int sizeCounter;

    [SerializeField] private AudioSource _eatSound;

    [SerializeField] private TextEditor _textEditor;

    [SerializeField] private AppleSpawner _appleSpawner;
    
    public int NumberOfBodies = 16;

    [SerializeField] private List<GameObject> _bodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistoryHead = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < NumberOfBodies; i++)
        {
            GrowSnake();
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;

            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerDirection * _steerSpeed * Time.deltaTime);

            PositionHistoryHead.Insert(0, transform.position);

            int index = 0;
            foreach (var body in BodyParts)
            {
                Vector3 point = PositionHistoryHead[Mathf.Clamp(index * _gap, 0, PositionHistoryHead.Count - 1)];

                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * _bodySpeed * Time.deltaTime;

                body.transform.LookAt(point);

                index++;
            }
        }
    }
    private void GrowSnake()
    {
        int _randomBody = Random.Range(0, _bodyPrefab.Count);
        GameObject LastBody = gameObject;
        GameObject body = Instantiate(_bodyPrefab[_randomBody], LastBody.transform.position, LastBody.transform.rotation);
        BodyParts.Add(body);

        Instantiate(_eatSound);

        sizeCounter++;

        _textEditor.UpdateTextScore(sizeCounter);

        if (sizeCounter > Progress.Instance.BestScore)
        {
            Progress.Instance.BestScore = sizeCounter;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Apple>())
        {
             GrowSnake();
             Destroy(other.gameObject);
             _appleSpawner.SpawnApple();
            if (_bodySpeed < 15)
            {
                _moveSpeed++;
                _bodySpeed++;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            GameManager.Instance.GameOver();
        }
    }

}
