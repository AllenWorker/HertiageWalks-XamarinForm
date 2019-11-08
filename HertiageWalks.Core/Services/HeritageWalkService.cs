using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HertiageWalks.Core.Model;
using Newtonsoft.Json;

namespace HertiageWalks.Core.Services
{
    public class HeritageWalkService
    {
        const string HeritageWalkUri = "https://heritage-walks.screencraft.net.au/api/{0}/{1}";
        public const string TrailImgPath = "https://heritage-walks.screencraft.net.au/images/trails/";

        public async Task<StopLocation> GetStop(int stopId)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(HeritageWalkUri, "stops", stopId);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<StopLocation>(json);
            }
        }

        public async Task<List<StopLocation>> GetAllStops()
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(HeritageWalkUri, "stops", "");
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<List<StopLocation>>(json);
            }
        }

        public async Task<List<StopLocation>> GetTrailStops(int trailId)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(HeritageWalkUri, "trails", trailId);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<List<StopLocation>>(json);
            }
        }

        public async Task<List<Trail>> GetAllTrails()
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(HeritageWalkUri, "trails", "");
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<List<Trail>>(json);
            }
        }

        public async Task<Trail> GetTrail(int trailId)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(HeritageWalkUri, "trails", trailId); //TODO web api need to retrieve  the specified  trail
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<Trail>(json);
            }
        }
    }
}
