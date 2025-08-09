using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using Core.Singleton;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Pieces")]
    public List<PiecesBase> startlevelPieces;
    public List<PiecesBase> levelPieces;
    public List<PiecesBase> endlevelPieces;
    public int startpiecesNumber = 1;
    public int piecesNumber = 5;
    public int endpiecesNumber = 1;
    [SerializeField] public int _index;
    private GameObject _currentLevel;
    private List<PiecesBase> _SpawnnedPieces;

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevel();
    }

    private void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            if (_index >= levels.Count)
            {
                ResetIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetIndex()
    {
        _index = 0;
    }

    private void CreateLevel()
    {
        _SpawnnedPieces = new List<PiecesBase>();
        for (int i = 0; i < startpiecesNumber; i++)
        {
            SpawnPieces(startlevelPieces);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            SpawnPieces(levelPieces);
        }
        for (int i = 0; i < endpiecesNumber; i++)
        {
            SpawnPieces(endlevelPieces);
        }
    }

    private void SpawnPieces(List<PiecesBase> list)
    {
        var pieces = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(pieces, container);

        if (_SpawnnedPieces.Count > 0)
        {
            var lastPiece = _SpawnnedPieces[_SpawnnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _SpawnnedPieces.Add(spawnedPiece);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextLevel();
        }
    }
}
