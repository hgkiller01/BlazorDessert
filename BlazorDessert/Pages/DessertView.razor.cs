using BlazorDessert.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorDessert.Pages
{
    public partial class DessertView
    {
        public IEnumerable<Dessert> model { get; set; }
        public int Total { get; set; } = 0;
        public int AllPage { get; set; } = 0;
        [Inject]
        public IJSRuntime JS { get; set; }
        [Inject]
        public HttpClient http { get; set; }
        [Inject]
        public NavigationManager MyNavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            //http.BaseAddress = new Uri("http://localhost:62376/api/");
            model = await http.GetFromJsonAsync<IEnumerable<Dessert>>("Dessert/GetDesserts?page=1");
            Total = await http.GetFromJsonAsync<int>("Dessert/GetCount");
            double temp = Total / 9;
            AllPage = Convert.ToInt32(Math.Ceiling(temp));
        }
        protected async Task ChangePage(int page)
        {
            model = await http.GetFromJsonAsync<IEnumerable<Dessert>>("Dessert/GetDesserts?page=" + page);
            await JS.InvokeVoidAsync("topFunction");
        }
    }
}
