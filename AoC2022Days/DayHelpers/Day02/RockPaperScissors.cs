namespace AoC2022Days.DayHelpers.Day02
{
    public class RockPaperScissors
    {
        private readonly char _enemyMove;
        private readonly char _myMove;
        public RockPaperScissors(string input)
        {
            _enemyMove = char.Parse(input.Split(' ').First());
            _myMove = char.Parse(input.Split(' ').Last());
        }

        public int CalculateScore()
        {
            int score = 0;
            switch (_enemyMove)
            {
                case 'A':
                    if(_myMove == 'X') score += 3;
                    if(_myMove == 'Y') score += 6;
                    break;
                case 'B':
                    if (_myMove == 'Y') score += 3;
                    if (_myMove == 'Z') score += 6;
                    break;
                case 'C':
                    if (_myMove == 'Z') score += 3;
                    if (_myMove == 'X') score += 6;
                    break;
            }
            switch (_myMove)
            {
                case 'X':
                    score += 1;
                    break;
                case 'Y':
                    score += 2;
                    break;
                case 'Z':
                    score += 3;
                    break;
            }
            return score;
        }

        public int CalculateScoreWithOwnEnding()
        {
            int score = 0;
            switch (_enemyMove)
            {
                case 'A':
                    if (_myMove == 'X')
                    {
                        score += 3;
                        break;
                    }
                    if (_myMove == 'Y')
                    {
                        score += 1;
                        break;
                    }
                    score += 2;
                    break;
                case 'B':
                    if (_myMove == 'X')
                    {
                        score += 1;
                        break;
                    }
                    if (_myMove == 'Y')
                    {
                        score += 2;
                        break;
                    }
                    score += 3;
                    break;
                case 'C':
                    if (_myMove == 'X')
                    {
                        score += 2;
                        break;
                    }
                    if (_myMove == 'Y')
                    {
                        score += 3;
                        break;
                    }
                    score += 1;
                    break;
            }
            switch (_myMove)
            {
                case 'X':
                    score += 0;
                    break;
                case 'Y':
                    score += 3;
                    break;
                case 'Z':
                    score += 6;
                    break;
            }
            return score;
        }
    }
}
