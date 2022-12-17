using Microsoft.Extensions.Configuration.UserSecrets;
using System.Net.WebSockets;
using System.Text;

namespace AoC2022Days.DayHelpers.Day16
{
    public class Tunnels
    {
        public List<Valve> Valves;
        private Dictionary<string, int> AlreadyVisitedStates;
        private Valve _firstValve;

        public Tunnels(List<string> inputs)
        {
            Valves = inputs.Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new Valve(x))
                .ToList();
            Valves.ForEach(v => v.SetConnections(Valves));
            Valves.OrderBy(v => v.FlowRate);
            _firstValve = Valves.First(v => v.Name == "AA");
        }

        public int CalulateMostPressure(int minutes, bool WithHelper)
        {
            AlreadyVisitedStates = new Dictionary<string, int>();
            var result = CalcMostPressureRecusive(_firstValve, new List<Valve>(), minutes, WithHelper);
            return result;
        }
        private int CalcMostPressureRecusive(Valve currentValve, List<Valve> openValves, int minutesLeft, bool helper)
        {
            if (minutesLeft == 0) return helper ? CalcMostPressureRecusive(_firstValve,openValves, 26, false) : 0;
            var sb = new StringBuilder();
            sb.Append(currentValve.Name);
            sb.Append(minutesLeft);
            openValves.ForEach(v => sb.Append("-" + v.Name));
            sb.Append(helper);
            string key = sb.ToString();

            if (AlreadyVisitedStates.ContainsKey(key)) return AlreadyVisitedStates[key];

            var currentBest = 0;
            if (!openValves.Contains(currentValve) && currentValve.FlowRate > 0)
            {
                var currentOpenValves = new List<Valve>(openValves) { currentValve };
                var additionToTotalPressure = currentValve.FlowRate * (minutesLeft - 1);
                currentBest = Math.Max(currentBest, additionToTotalPressure + CalcMostPressureRecusive(currentValve, currentOpenValves, minutesLeft - 1, helper));
            }
            foreach (var nextValve in currentValve.ConnectedValves)
            {
                currentBest = Math.Max(currentBest, CalcMostPressureRecusive(nextValve, openValves, minutesLeft - 1, helper));
            }

            AlreadyVisitedStates[key] = currentBest;
            return currentBest;
        }
    }
}
