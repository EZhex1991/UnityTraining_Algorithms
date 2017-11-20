/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AStar : MonoBehaviour
{
    public class Point
    {
        public static bool allowObliqueMove;

        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public IEnumerable<Point> GetChildren()
        {
            yield return new Point(x - 1, y);
            yield return new Point(x + 1, y);
            yield return new Point(x, y + 1);
            yield return new Point(x, y - 1);
            if (allowObliqueMove)
            {
                yield return new Point(x - 1, y - 1);
                yield return new Point(x - 1, y + 1);
                yield return new Point(x + 1, y - 1);
                yield return new Point(x + 1, y + 1);
            }
        }

        public static float operator -(Point p1, Point p2)
        {
            return allowObliqueMove
                ? (new Vector2(p1.x, p1.y) - new Vector2(p2.x, p2.y)).magnitude
                : Mathf.Abs(p1.x - p2.x) + Mathf.Abs(p1.y - p2.y);
        }
        public static bool operator ==(Point p1, Point p2)
        {
            if (System.Object.ReferenceEquals(p1, p2))
            {
                return true;
            }
            else if ((object)p1 == null || (object)p2 == null)
            {
                return false;
            }
            return p1.x == p2.x && p1.y == p2.y;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point p = obj as Point;
                return this == p;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return x * 1000 + y;
        }
    }
    public class Status
    {
        public Point parent;
        public float distance;
        public Status(Point parent, float distance)
        {
            this.parent = parent;
            this.distance = distance;
        }
    }

    public Vector2 start;
    public Vector2 end;
    public bool allowObliqueMove;

    public GameObject prefab;
    private Toggle[,] toggles = new Toggle[50, 50];
    private Image[,] images = new Image[50, 50];

    Point startPoint;
    Point endPoint;
    List<Point> openList = new List<Point>();
    List<Point> closedList = new List<Point>();
    Dictionary<Point, Status> record = new Dictionary<Point, Status>();

    void Start()
    {
        Point.allowObliqueMove = allowObliqueMove;
        startPoint = new Point((int)start.x, (int)start.y);
        endPoint = new Point((int)end.x, (int)end.y);
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                GameObject element = Instantiate(prefab);
                element.transform.SetParent(transform, false);
                toggles[x, y] = element.GetComponent<Toggle>();
                toggles[x, y].isOn = Random.Range(0, 3) == 0;
                toggles[x, y].onValueChanged.AddListener(delegate { Search(); });
                images[x, y] = element.GetComponent<Image>();
            }
        }
        toggles[startPoint.x, startPoint.y].isOn = false;
        toggles[endPoint.x, endPoint.y].isOn = false;
        Search();
    }

    float GetDistance(Point point)
    {
        return point - endPoint;
    }
    void Insert(float distance, Point p)
    {
        int index = 0;
        while (index < openList.Count && record[openList[index]].distance < distance)
        {
            index++;
        }
        openList.Insert(index, p);
    }
    int Sort(Point p1, Point p2)
    {
        if (GetDistance(p1) > GetDistance(p2))
        {
            return 1;
        }
        else if (GetDistance(p1) < GetDistance(p2))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    bool IsValid(Point point)
    {
        if (point.x >= 50 || point.y >= 50 || point.x < 0 || point.y < 0)
            return false;
        return !toggles[point.x, point.y].isOn;
    }

    void Reset()
    {
        openList.Clear();
        closedList.Clear();
        record.Clear();
        openList.Add(startPoint);
        record.Add(startPoint, new Status(null, 0));
    }
    void Search()
    {
        Point.allowObliqueMove = allowObliqueMove;
        Reset();
        while (openList.Count > 0)
        {
            Point parent = openList[0];
            if (parent == endPoint)
            {
                break;
            }
            openList.Remove(parent);
            closedList.Add(parent);
            foreach (Point child in parent.GetChildren())
            {
                if (!IsValid(child))
                    continue;
                float distance = record[parent].distance + (child - parent);
                if (record.ContainsKey(child))
                {
                    if (distance < record[child].distance)
                    {
                        record[child] = new Status(parent, distance);
                    }
                }
                else
                {
                    openList.Add(child);
                    record[child] = new Status(parent, distance);
                }
            }
            openList.Sort(Sort);
        }
        Refresh();
    }

    void Refresh()
    {
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                Point point = new Point(x, y);
                if (closedList.Contains(point))
                {
                    images[x, y].color = Color.red;
                }
                else if (openList.Contains(point))
                {
                    images[x, y].color = Color.yellow;
                }
                else
                {
                    images[x, y].color = Color.white;
                }
            }
        }
        Point path = endPoint;
        Status status;
        while (path != null && record.TryGetValue(path, out status))
        {
            images[path.x, path.y].color = Color.green;
            path = status.parent;
        }
        images[startPoint.x, startPoint.y].color = Color.blue;
        images[endPoint.x, endPoint.y].color = Color.blue;
    }
}