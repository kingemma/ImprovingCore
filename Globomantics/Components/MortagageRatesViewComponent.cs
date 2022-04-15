using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    /// <summary>
    /// Views/Shared/Components/MortagageRates/Default.cshtml
    /// </summary>
    public class MortagageRatesViewComponent : ViewComponent
    {
        private IRateService _rateService;

        public MortagageRatesViewComponent(IRateService rateService)
        {
            _rateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rates = this._rateService.GetMortgageRates();
            return View(rates);
        }
    }
}
