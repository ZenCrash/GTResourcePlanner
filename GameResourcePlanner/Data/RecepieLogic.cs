using System.Text.Json;

namespace GameResourcePlanner.Data
{
    public class RecepieLogic
    {
        private string filePath = @"..\GameResourcePlanner\GameResourcePlanner\Data\DataStorage\Recepies.json"; // Update this with your file path

        //GetAll Recepies
        public List<Recepie> GetRecepiesFromJson()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Recepie>>(jsonData);
            }
            else
            {
                return new List<Recepie>();
            }
        }

        //Insert List<Recepie>
        public void InsertRecepiesToJson(List<Recepie> recepies)
        {
            string jsonData = JsonSerializer.Serialize(recepies, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, jsonData);
        }

        //Insert Recepie
        public void InsertRecepie(Recepie newRecepie)
        {
            List<Recepie> existingRecepies = GetRecepiesFromJson();
            List<Recepie> UpdatedRecepies = new();

            //if (existingRecepies.Exists(r => r.MachineName == newRecepie.MachineName &&
            //                                 r.Inputs.Count == newRecepie.Inputs.Count &&
            //                                 r.Inputs.Values.All(value => newRecepie.Inputs.ContainsValue(value)) &&
            //                                 r.Outputs.Count == newRecepie.Outputs.Count &&
            //                                 r.Outputs.Values.All(value => newRecepie.Outputs.ContainsValue(value)) &&
            //                                 r.TotalEU == newRecepie.TotalEU &&
            //                                 r.EUPerTick == newRecepie.EUPerTick &&
            //                                 r.CraftingTime == newRecepie.CraftingTime
            //                                 ))
            //{
            //    throw new Exception($"Recipe already exists.");
            //}

            UpdatedRecepies = existingRecepies;
            UpdatedRecepies.Add(newRecepie);

            string jsonData = JsonSerializer.Serialize(UpdatedRecepies, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }
    }
}
