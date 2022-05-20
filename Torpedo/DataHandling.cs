using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Torpedo.Model;

namespace Torpedo
{
    class DataHandling
    {
        public void AddResultToJson(Result newResult)
        {
            if (File.Exists(@"..\..\..\results.json"))
            {
                string inJson = File.ReadAllText(@"..\..\..\results.json");
                List<Result> results = JsonConvert.DeserializeObject<List<Result>>(inJson);

                results.Add(newResult);

                string outJson = JsonConvert.SerializeObject(results.ToArray());

                File.WriteAllText(@"..\..\..\results.json", outJson);
            }
            else
            {
                List<Result> results = new List<Result>();

                results.Add(newResult);

                string outJson = JsonConvert.SerializeObject(results.ToArray());

                File.WriteAllText(@"..\..\..\results.json", outJson);
            }
        }
        public List<Rank> getRankList()
        {
            string inJson = File.ReadAllText(@"..\..\..\results.json");
            List<Result> allResult = JsonConvert.DeserializeObject<List<Result>>(inJson);
            List<String> uniqueNames = allResult.Select(x => x.username).Distinct().ToList();
            List<Rank> ranking = new List<Rank>();

            for (int i = 0; i < uniqueNames.Count; i++)
            {
                int wins = allResult.Where(name => name.username == uniqueNames[i]).Where(result => result.result == "win").Count();
                int defeat = allResult.Where(name => name.username == uniqueNames[i]).Where(result => result.result == "defeat").Count();
                Rank rank = new Rank() { Name = uniqueNames[i], Wins = wins, Loses = defeat };
                ranking.Add(rank);
            }
            return ranking;
        }

    }
}
