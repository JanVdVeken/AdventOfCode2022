using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace AoC2022Days.DayHelpers.Day16
{
    public class Valve
    {
        public string Name;
        private List<string> ConnectedValveNames = new List<string>();
        public List<Valve> ConnectedValves;
        public int FlowRate;
        public Valve(string input)
        {
            ConnectedValves = new List<Valve>();
            //Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
            var temp = input.Replace("Valve ", "")
                .Replace("has flow rate=", "")
                .Replace("; tunnels lead ", "")
                .Replace("; tunnel leads ", "")
                .Replace("valves", "")
                .Replace("valve", "")
                .Split("to ");
            Name = temp[0].Trim().Split(" ").First().Trim();
            FlowRate = int.Parse(temp[0].Split(" ").Last().Trim());
            foreach (var connectedValve in temp[1].Split(", "))
            {
                ConnectedValveNames.Add(connectedValve.Trim());
            }
        }

        public void SetConnections(List<Valve> valves)
        {
            foreach (var connectedValveName in ConnectedValveNames)
            {
                ConnectedValves.Add(valves.First(v => string.Equals(v.Name.Trim(), connectedValveName.Trim())));
            }
        }
    }
}
