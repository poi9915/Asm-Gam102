using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> maps;
    public List<GameObject> mapsGC;
    private Vector2 _nextPos;
    private Vector2 _endPos;
    private float _rd;
    private Transform _player;
    private int _groundLength;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _endPos = new Vector2(30f, 0);

        for (int i = 0; i < 5; i++)
        {
            _nextPos = new Vector2(_endPos.x , 0);
            int index = Random.Range(0, maps.Count);
            GameObject mapGc = Instantiate(maps[index], _nextPos, Quaternion.identity, transform);
            mapsGC.Add(mapGc);
            switch (index)
            {
                case 0:
                    _groundLength = 2;
                    break;
                case 1:
                    _groundLength = 5;
                    break;
                case 2:
                    _groundLength = 14;
                    break;
                case 3:
                    _groundLength = 17;
                    break;
                case 4:
                    _groundLength = 21;
                    break;
                case 5:
                    _groundLength = 26;
                    break;
                case 6:
                    _groundLength = 35;
                    break;
            }

            _endPos = new Vector2(_nextPos.x + _groundLength, 0);
        }
    }

    private void Update()
    {
        if (Vector2.Distance(_player.position, _endPos) < 100f)
        {
            for (int i = 0; i < 5; i++)
            {
                _rd = Random.Range(2f, 5f);
                _nextPos = new Vector2(_endPos.x + _rd, 0);
                int index = Random.Range(0, maps.Count);
                GameObject mapGc = Instantiate(maps[index], _nextPos, Quaternion.identity, transform);
                mapsGC.Add(mapGc);
                switch (index)
                {
                    case 0:
                        _groundLength = 2;
                        break;
                    case 1:
                        _groundLength = 5;
                        break;
                    case 2:
                        _groundLength = 14;
                        break;
                    case 3:
                        _groundLength = 17;
                        break;
                    case 4:
                        _groundLength = 21;
                        break;
                    case 5:
                        _groundLength = 26;
                        break;
                    case 6:
                        _groundLength = 35;
                        break;
                }

                _endPos = new Vector2(_nextPos.x + _groundLength, 0);
            }
        }

        GameObject defMap = mapsGC.FirstOrDefault();
        if (defMap is not null && Vector2.Distance(_player.position, defMap.transform.position) > 100)
        {
            mapsGC.Remove(defMap);
            Destroy(defMap);
        }
    }
}