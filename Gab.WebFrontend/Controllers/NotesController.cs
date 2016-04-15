using Gab.WebFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gab.WebFrontend.Controllers
{
    public class NotesController : Controller
    {
        private static string SERVICEURIBASE = "PASTE YOUR ADDRESS";

        // GET: Notes
        public  ActionResult Index()
        {            
            var plainresult = GetHttp(SERVICEURIBASE);
            var model = JsonConvert.DeserializeObject<List<Note>>(plainresult);
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            var visitorsIpAddress = GetIPAddress();
            string res = $"http://ipinfo.io/{visitorsIpAddress}/city";
            string ipResponse =  IpRequestHelper(res);
            note.City = ipResponse;
            System.Diagnostics.Trace.WriteLine($"User is from {ipResponse}");

            var response = PostHttp(SERVICEURIBASE, JsonConvert.SerializeObject(note));

            System.Diagnostics.Trace.WriteLine($"response from {SERVICEURIBASE} POST: {response}");
            return RedirectToAction("Index");
        }

        protected string GetIPAddress()
        {
            var userHostaddr = this.HttpContext.Request.UserHostAddress;
            //for local testing we hardcode an ip from OOe
            if (userHostaddr == "127.0.0.1" || userHostaddr == "::1")
            {
                return "212.183.17.0";
            }
            else
            {
                return userHostaddr;
            }
        }

        private string IpRequestHelper(string res)
        {
            return GetHttp(res);
        }

        public string GetHttp(string url)
        {
            //HttpClient... 
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();
            responseRead = responseRead.Replace("\n", String.Empty);
            responseStream.Close();
            responseStream.Dispose();
            return responseRead;
        }

        public string PostHttp(string url, string body)
        {
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentType = "application/json";
            Stream dataStream = objRequest.GetRequestStream();        
            byte[] messageBytes = Encoding.UTF8.GetBytes(body);
            dataStream.Write(messageBytes, 0, messageBytes.Length);
            dataStream.Close();
            
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();
            responseRead = responseRead.Replace("\n", String.Empty);
            responseStream.Close();
            responseStream.Dispose();
            return responseRead;
        }
    }
}
