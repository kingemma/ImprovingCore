using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    /// <summary>
    /// Views/Shared/Components/CreditCardRates/Default.cshtml
    /// </summary>
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private IRateService _rateService;


        public CreditCardRatesViewComponent(IRateService rateService)
        {
            _rateService = rateService;
        }

        /// <summary>
        ///  @await Component.InvokeAsync("CreditCardRates", new { title = "Credit Card Rates", subTitle = "The lowest rates - guaranteed." })
        ///  or
        ///  @await Component.InvokeAsync("CreditCardRates", new { title = "Credit Card Rates", subTitle = "The lowest rates - guaranteed." })
        ///  The input parameters are case non-sensitive
        /// </summary>
        /// <param name="title"></param>
        /// <param name="subTitle"></param>
        /// <returns></returns>
        public async Task<ViewViewComponentResult> InvokeAsync(string title, string subTitle)
        {
            var rates = this._rateService.GetCreditCardRates();
            CreditCardRatesVm creditCardRatesVm = new CreditCardRatesVm();
            creditCardRatesVm.Title = title;
            creditCardRatesVm.SubTitle = subTitle;
            creditCardRatesVm.Rates = rates;
            return View(creditCardRatesVm);
        }

    }
}
