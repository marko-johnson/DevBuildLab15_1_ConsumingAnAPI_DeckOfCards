using Lab15_1_ConsumingAnAPI_DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http; // Add this

namespace Lab15_1_ConsumingAnAPI_DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> generateNewDeck(int numOfDecks)
        {
            string domain = "https://deckofcardsapi.com/";
            string path = $"/api/deck/new/shuffle/?deck_count={numOfDecks}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Root result = await connection.Content.ReadAsAsync<Root>();

            return View(result);
        }

        public async Task<IActionResult> generateNewDeckID(int numOfDecks)
        {
            string domain = "https://deckofcardsapi.com/";
            string path = $"/api/deck/new/shuffle/?deck_count={numOfDecks}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Root result = await connection.Content.ReadAsAsync<Root>();

            return View(result);
        }

        public async Task<IActionResult> deckDetails(string deck_id, int numOfCardsDrawn)
        {
            string domain = "https://deckofcardsapi.com/";
            string path = $"/api/deck/{deck_id}/ draw/?count={numOfCardsDrawn}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Root result = await connection.Content.ReadAsAsync<Root>();

            //return View(result);
            return Content("hello");
        }


        //public async Task<IActionResult> drawCardsFromDeck(int numOfCardsDrawn)
        //{
        //    string domain = "https://deckofcardsapi.com/";
        //    string path = $"/api/deck/new/shuffle/?deck_count={numOfDecks}";

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(domain);
        //    var connection = await client.GetAsync(path);
        //    Root result = await connection.Content.ReadAsAsync<Root>();

        //    return View(result);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
