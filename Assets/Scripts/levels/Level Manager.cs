using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using Core.Singleton;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;
    public List<GameObject> levels;
    public List<LevelPiecesSetup> levelPiecesSetup;

    /*[Header("Pieces")]
    public List<PiecesBase> startlevelPieces;
    public List<PiecesBase> levelPieces;
    public List<PiecesBase> endlevelPieces;
    public int startpiecesNumber = 1;
    public int piecesNumber = 5;
    public int endpiecesNumber = 1;*/
    [SerializeField] public int _index;
    private GameObject _currentLevel;
    [SerializeField] private List<PiecesBase> _SpawnnedPieces = new List<PiecesBase>();

    private LevelPiecesSetup _currSetup;
    

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevel();
    }

    /*private void SpawnNextLevel()
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
    }*/

    private void ResetIndex()
    {
        _index = 0;
    }

    private void CreateLevel()
    {
        if (_currSetup != null)
        {
            _index++;
            if (_index >= levelPiecesSetup.Count)
            {
                ResetIndex();
            }
        }
        _currSetup = levelPiecesSetup[_index];

        _SpawnnedPieces = new List<PiecesBase>();
        for (int i = 0; i < _currSetup.startpiecesNumber; i++)
        {
            SpawnPieces(_currSetup.startlevelPieces);
        }

        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            SpawnPieces(_currSetup.levelPieces);
        }
        for (int i = 0; i < _currSetup.endpiecesNumber; i++)
        {
            SpawnPieces(_currSetup.endlevelPieces);
        }

        ColorManager.Instance.ChangeColorByType(_currSetup.artType);
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

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }

        _SpawnnedPieces.Add(spawnedPiece);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextLevel();
        }*/
    }
}
