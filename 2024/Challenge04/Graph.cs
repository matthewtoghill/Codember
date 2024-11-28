namespace Challenge04;

public class Graph
{
    private Dictionary<int, List<int>> adjacencyList = [];

    public void AddEdge(int left, int right)
    {
        if (!adjacencyList.ContainsKey(left)) adjacencyList[left] = [];
        if (!adjacencyList.ContainsKey(right)) adjacencyList[right] = [];

        adjacencyList[left].Add(right);
        adjacencyList[right].Add(left);
    }

    public List<List<int>> FindConnectedComponents()
    {
        var visited = new HashSet<int>();
        var components = new List<List<int>>();

        foreach (var vertex in adjacencyList.Keys)
        {
            if (!visited.Contains(vertex))
            {
                var component = new List<int>();
                DFS(vertex, visited, component);
                components.Add(component);
            }
        }

        return components;
    }

    private void DFS(int vertex, HashSet<int> visited, List<int> component)
    {
        visited.Add(vertex);
        component.Add(vertex);

        foreach (var neighbor in adjacencyList[vertex])
        {
            if (!visited.Contains(neighbor))
                DFS(neighbor, visited, component);
        }
    }
}