using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : Attribute, IAuthorizationFilter
    {
        public string FeatureName { get; set; }

        private Dictionary<string, bool> FeatureStatus = new Dictionary<string, bool>()
        {
            { "Loan",false},
            { "Insurance",true},
            { "Resources",true}
        };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!FeatureStatus.Keys.Contains(FeatureName) || !FeatureStatus[FeatureName])
            {
                //The feature not online yet
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }


    public class FeatureAuthFilterWithoutAttribute : IAuthorizationFilter
    {
        public string _featureName;

        public FeatureAuthFilterWithoutAttribute(IFeatureService featureService, string featureName)
        {
            this.featureService = featureService;
            this._featureName = featureName;
        }
        private readonly IFeatureService featureService;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!featureService.IsFeatureActive(this._featureName))
            {
                //The feature not online yet
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
