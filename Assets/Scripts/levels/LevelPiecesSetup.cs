using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class LevelPiecesSetup : ScriptableObject
{
    public ArtManager.ArtType artType;
    
    [Header("Pieces")]
    public List<PiecesBase> startlevelPieces;
    public List<PiecesBase> levelPieces;
    public List<PiecesBase> endlevelPieces;
    public int startpiecesNumber = 1;
    public int piecesNumber = 5;
    public int endpiecesNumber = 1;
}
