using Globomantics.Core.Models;
using System.Collections.Generic;

namespace Globomantics.Models
{
    public class CreditCardRatesVm
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
