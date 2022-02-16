
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace scrapper.Models
{
    public partial class RequestPage
    {
        public string ProductId { get; set; }
        public string Vendor { get; set; }
        public string Url { get; set; }
        public string Selector { get; set; }

        public async Task<string> CheckPrice(IPage page)
        {

            var price = await page.TextContentAsync(this.Selector);

            return GetPrice($"{price}");

        }

        private string GetPrice(string priceString)
        {

            var priceSplit = priceString.Split("USD");

            var value = priceSplit[priceSplit.Length - 1];

            var price = value.Replace(",", ".").Trim();

            return price;

        }
    }

    public static class RequestPageExtensions
    {

        public static IEnumerable<RequestPage> GetRequests()
        {

            var requests = new List<RequestPage>();

            requests.Add(new RequestPage
            {
                ProductId = "tv_59_rca",
                Vendor = "Siman",
                Url = "https://ni.siman.com/smart-tv-led-rca-59-103428711/p",
                Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            });

            requests.Add(new RequestPage
            {
                ProductId = "microondas_9_p",
                Vendor = "Siman",
                Url = "https://ni.siman.com/microondas-0-9-pies-acero-inox-733973/p",
                Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            });

            requests.Add(new RequestPage
            {
                ProductId = "refri_wp_18_pc",
                Vendor = "Siman",
                Url = "https://ni.siman.com/refrig-tm-18pc-xper-energy-saver-inox-102141469/p",
                Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            });
            // /** tv_50_samsung **/

            // requests.Add(new RequestPage
            // {
            //     ProductId = "tv_50_samsung ",
            //     Vendor = "Siman",
            //     Url = "https://ni.siman.com/tv-crystal-smart-50-uhd-4k-103237071/p",
            //     Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            // });

            // requests.Add(new RequestPage
            // {
            //     ProductId = "tv_50_samsung ",
            //     Vendor = "LaCuracao",
            //     Url = "https://www.lacuracaonline.com/nicaragua/productos/promociones/samsung-televisor-smart-tv-50-un50au8000px-4k-uhd",
            //     Selector = "#product-price-82551"
            // });

            // requests.Add(new RequestPage
            // {
            //     ProductId = "tv_50_samsung ",
            //     Vendor = "GMG",
            //     Url = "https://www.elgallomasgallo.com.ni/pantalla-smart-uhd-4k-samsung-50-pulgadas-un50au7000smart-171698",
            //     Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            // });

            // requests.Add(new RequestPage
            // {
            //     ProductId = "tv_50_samsung ",
            //     Vendor = "Pricesmart",
            //     Url = "https://www.pricesmart.com/site/ni/es/pagina-producto/419741",
            //     Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            // });

            // requests.Add(new RequestPage
            // {
            //     ProductId = "tv_50_samsung ",
            //     Vendor = "Walmart",
            //     Url = "https://www.walmart.com.ni/led-smart-4k-50-samsung-un50au8000pxpa/p",
            //     Selector = ".vtex-flex-layout-0-x-flexRow--row-two-price"
            // });


            return requests.ToArray();

        }

    }

}