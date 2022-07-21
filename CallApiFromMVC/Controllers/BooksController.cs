using CallApiFromMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace CallApiFromMVC.Controllers
{
    public class BooksController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        List<Book> _oBook = new List<Book>();
        List<Book> _oBooks = new List<Book>();

        public BooksController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44382/Books"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);

                }
            }
            return _oBooks;
        }

        [HttpGet]
        public async Task<List<Book>> GetById(string id)
        {
            _oBook = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44382/Books/" + id ))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBook = JsonConvert.DeserializeObject<List<Book>>(apiResponse);

                }
            }
            return _oBook;
        }

        [HttpPost]
        public async Task<List<Book>> AddUpdateBook(Book book)
        {
            _oBook = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44382/Books/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBook = JsonConvert.DeserializeObject<List<Book>>(apiResponse);

                }
            }
            return _oBook;
        }

        [HttpDelete]
        public async Task<string> Delete(string id)
        {
            string message = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44382/Books/" + id))
                {
                    message = await response.Content.ReadAsStringAsync();

                }
            }
            return message;
        }
    }
}
