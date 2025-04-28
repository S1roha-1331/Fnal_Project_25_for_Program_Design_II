using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float pathUpdateInterval = 1f; // 幾秒更新一次路徑
    public Transform player;

    public GameObject floorPrefab;
    public int[,] maze = new int[,] {
        {0, 0, 0, 0},
        {1, 1, 0, 1},
        {0, 0, 0, 0},
        {0, 1, 1, 0}
    };

    private List<Vector2Int> path = new List<Vector2Int>();
    private int pathIndex = 0;

    void Start()
    {
        GenerateMazeVisual();
        InvokeRepeating(nameof(UpdatePath), 0f, pathUpdateInterval);
    }

    void Update()
    {
        FollowPath();
    }

    void UpdatePath()
    {
        Vector2Int start = WorldToGrid(transform.position);
        Vector2Int end = WorldToGrid(player.position);
        path = BFSPath(maze, start, end);
        pathIndex = 0;
    }

    void FollowPath()
    {
        if (path == null || pathIndex >= path.Count) return;

        Vector3 target = GridToWorld(path[pathIndex]);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            pathIndex++;
        }
    }

    List<Vector2Int> BFSPath(int[,] maze, Vector2Int start, Vector2Int end)
    {
        int n = maze.GetLength(0);
        int m = maze.GetLength(1);
        bool[,] visited = new bool[n, m];
        Vector2Int[,] prev = new Vector2Int[n, m];

        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        Queue<Vector2Int> q = new Queue<Vector2Int>();
        q.Enqueue(start);
        visited[start.x, start.y] = true;
        prev[start.x, start.y] = new Vector2Int(-1, -1);

        while (q.Count > 0)
        {
            Vector2Int curr = q.Dequeue();
            if (curr == end) break;

            for (int i = 0; i < 8; i++)
            {
                int nx = curr.x + dx[i];
                int ny = curr.y + dy[i];

                if (nx >= 0 && ny >= 0 && nx < n && ny < m &&
                    maze[nx, ny] == 0 && !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    prev[nx, ny] = curr;
                    q.Enqueue(new Vector2Int(nx, ny));
                }
            }
        }

        if (!visited[end.x, end.y]) return null;

        List<Vector2Int> path = new List<Vector2Int>();
        for (Vector2Int at = end; at.x != -1; at = prev[at.x, at.y])
        {
            path.Add(at);
        }
        path.Reverse();
        return path;
    }

    Vector2Int WorldToGrid(Vector3 pos)
    {
        int x = Mathf.RoundToInt(-pos.y); // y 是負的，因為上面是第 0 列
        int y = Mathf.RoundToInt(pos.x);
        return new Vector2Int(x, y);
    }

    Vector3 GridToWorld(Vector2Int cell)
    {
        return new Vector3(cell.y, -cell.x, 0);
    }

    void GenerateMazeVisual()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Quad);
                tile.transform.position = new Vector3(j, -i, 0);
                tile.transform.localScale = Vector3.one * 0.95f;

                var renderer = tile.GetComponent<Renderer>();
                if (maze[i, j] == 1)
                    renderer.material.color = Color.black;
                else
                    renderer.material.color = Color.white;
            }
        }
    }
}
