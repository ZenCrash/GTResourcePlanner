namespace GameResourcePlanner.Data
{
    public class Recepie
    {
        public string MachineName { get; set; }
        public Dictionary<string, int> Inputs { get; set; }
        public Dictionary<string, int> Outputs { get; set; }
        public double TotalEU { get; set; }
        public double EUPerTick { get; set; }
        public double CraftingTime { get; set; }
    }
}

