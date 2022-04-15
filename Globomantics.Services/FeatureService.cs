using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Globomantics.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IHostEnvironment _hostingEnvironment;

        public FeatureService(IHostEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
            var path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\feature.json");
            string jsonContent = File.ReadAllText(path);
            this.featureStates = JsonConvert.DeserializeObject<Dictionary<string, bool>>(jsonContent);
        }
        private Dictionary<string, bool> featureStates = new Dictionary<string, bool>()
        {
            { "Quotes", true },
            { "Loans", true },
            { "Resources", true },
            { "BusinessServices", true}
        };

        public bool IsFeatureActive(string featureName)
        {
            return featureStates.FirstOrDefault(x => x.Key == featureName).Value;
        }
    }
}
