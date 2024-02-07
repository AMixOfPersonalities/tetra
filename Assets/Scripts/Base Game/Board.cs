using UnityEngine;
using UnityEngine.Tilemaps;

using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }

    public ScoreManager scoreManager;

    private int score = 0;
    private int comboCount = 0;

    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);

    public int Level
    {
        get { return Mathf.FloorToInt(score / 1000) + 1; }
    }

    public RectInt Bounds 
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<Piece>();

        for (int i = 0; i < tetrominoes.Length; i++) {
            tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];

        activePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(activePiece, spawnPosition)) {
            Set(activePiece);
        } else {
            GameOver();
        }
    }

    public void GameOver()
    {
        tilemap.ClearAllTiles();
        Scene GameType = SceneManager.GetActiveScene();
        if (GameType.name == "Scene11 - SinglePlayer")
        {
            PlayerPrefs.SetInt("LastScore", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Scene8 - Game Over");
        }
        else if (GameType.name == "Scene10 - Local Multiplayer Screen")
        {
            FindObjectOfType<SavePlayerScores>().Save();
            SceneManager.LoadScene("Scene5 - Local Multiplayer Game Over");
        }
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = Bounds;

        // The position is only valid if every cell is valid
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            // An out of bounds tile is invalid
            if (!bounds.Contains((Vector2Int)tilePosition)) {
                return false;
            }

            // A tile already occupies the position, thus invalid
            if (tilemap.HasTile(tilePosition)) {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = Bounds;
        int row = bounds.yMin;
        int clearedLines = 0;

        // Clear from bottom to top
        while (row < bounds.yMax)
        {
            // Only advance to the next row if the current is not cleared
            // because the tiles above will fall down when a row is cleared
            if (IsLineFull(row)) {
                LineClear(row);
                clearedLines++;
            } else {
                row++;
            }
        }
        CalculateScore(clearedLines);
    }

    private void CalculateScore(int clearedLines)
    {
        if (clearedLines == 0) return;

        bool isTetris = clearedLines == 4;
        bool isBackToBack = clearedLines >= 1 && clearedLines <= 4;
        int BaseScore = 0;

        switch (clearedLines)
        {
            case 1:
                BaseScore = 100;
                break;
            case 2:
                BaseScore = 300;
                break;
            case 3:
                BaseScore = 500;
                break;
            case 4 : 
                BaseScore = 800;
                break;
        }

        int lineClearScore = BaseScore * Level;

        if (isBackToBack)
        {
            lineClearScore = Mathf.FloorToInt(lineClearScore * 1.5f);
        }

        if(comboCount > 0)
        {
            int comboBonus = 50 * comboCount * Level;
            lineClearScore += comboBonus;
        }

        score += lineClearScore;

        comboCount = clearedLines > 0 ? comboCount + 1 : 0;

        // Update the score using ScoreManager
            scoreManager.UpdateScore(score);
    }

    public bool IsLineFull(int row)
    {
        RectInt bounds = Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            // The line is not full if a tile is missing
            if (!tilemap.HasTile(position)) {
                return false;
            }
        }

        return true;
    }

    public void LineClear(int row)
    {
        RectInt bounds = Bounds;

        // Clear all tiles in the row
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }

        // Shift every row above down one
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, above);
            }

            row++;
        }
    }

}
