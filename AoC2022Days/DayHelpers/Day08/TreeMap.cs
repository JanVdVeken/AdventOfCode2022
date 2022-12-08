namespace AoC2022Days.DayHelpers.Day08;

public class TreeMap
{
    public List<Tree> Trees;
    private int maxRow;
    private int maxCol;
    public TreeMap(List<string> inputs)
    {
        Trees = new List<Tree>();
        for (int currentRow = 0; currentRow < inputs.Count(); currentRow++)
        {
            var input = inputs[currentRow].ToCharArray();
            for (int currentCol = 0; currentCol < inputs.Count(); currentCol++)
            {
                Trees.Add(new Tree(currentRow, currentCol, int.Parse(input[currentCol].ToString()), false));
            }
        }
        maxRow = Trees.Max(t => t.Row);
        maxCol = Trees.Max(t => t.Col);
    }
    public Tree GetTree(int column, int row) => Trees.SingleOrDefault(tree => tree.Row == row && tree.Col == column);

    public int VisibleTreesFromOutside()
    {
        CalculateVisibility();
        return Trees.Count(t => t.IsVisible);
    }

    private void CalculateVisibility()
    {
        Trees.ForEach(tree => tree.SetVisibility(IsVisibleFromAnySide(tree)));
    }

    private bool IsVisibleFromAnySide(Tree tree)
    {
        return IsVisibleFromTheSide(tree, Sides.Top)
            || IsVisibleFromTheSide(tree, Sides.Bottom)
            || IsVisibleFromTheSide(tree, Sides.Left)
            || IsVisibleFromTheSide(tree, Sides.Right);
    }

    private bool IsVisibleFromTheSide(Tree tree, Sides side)
    {
        var currentTrees = new List<Tree>();
        switch (side)
        {
            case Sides.Top:
                currentTrees = Trees.Where(t => t.Col == tree.Col && t.Row < tree.Row).ToList();
                    break;
            case Sides.Bottom:
                currentTrees = Trees.Where(t => t.Col == tree.Col && t.Row > tree.Row).ToList();
                break;
            case Sides.Left:
                currentTrees = Trees.Where(t => t.Row == tree.Row && t.Col < tree.Col).ToList(); 
                break;
            case Sides.Right:
                currentTrees = Trees.Where(t => t.Row == tree.Row && t.Col > tree.Col).ToList(); 
                break;
        }
        return currentTrees.All(t => t.Height < tree.Height);
    }

    public int CalculateHighestScenicScore()
    {
        return Trees.Where(t => t.Row != 0 && t.Row != maxRow && t.Col != 0 && t.Col != maxCol)
                    .Select(tree => CalculateSceniceScore(tree))
                    .Max();
    }

    private int CalculateSceniceScore(Tree tree)
    {
        var rightCount = 0;
        var leftCount = 0;
        var topCount = 0;
        var bottomCount = 0;
        var horizontalAndVerticalNeighbours = Trees.Where(t => t.Row == tree.Row || t.Col == tree.Col);
        for (int i = tree.Row+1;i <= maxRow;i++)
        {
            var currentTree = horizontalAndVerticalNeighbours.SingleOrDefault(t => t.Col == tree.Col && t.Row == i);

            if (currentTree is null) break;
            bottomCount++;
            if (currentTree.Height >= tree.Height)
            {
                break;
            }
        }
        if (bottomCount == 0) return 0;

        for (int i = tree.Row-1; i >= 0; i--)
        {
            var currentTree = horizontalAndVerticalNeighbours.SingleOrDefault(t => t.Col == tree.Col && t.Row == i);
            if (currentTree is null) break;
            topCount++;
            if (currentTree.Height >= tree.Height)
            {
                break;
            }
        }
        if (topCount == 0) return 0;

        for (int i = tree.Col+1; i <= maxCol; i++)
        {
            var currentTree = horizontalAndVerticalNeighbours.SingleOrDefault(t => t.Row == tree.Row && t.Col == i);
            if (currentTree is null) break;
            rightCount++;
            if (currentTree.Height >= tree.Height)
            {
                break;
            }
        }
        if (rightCount == 0) return 0;

        for (int i = tree.Col-1; i >=0; i--)
        {
            var currentTree = horizontalAndVerticalNeighbours.SingleOrDefault(t => t.Row == tree.Row && t.Col == i);
            if (currentTree is null) break;
            leftCount++;
            if (currentTree.Height >= tree.Height)
            {
                break;
            }
        }
        if (leftCount == 0) return 0;

        return rightCount* leftCount * topCount* bottomCount;
    }
}