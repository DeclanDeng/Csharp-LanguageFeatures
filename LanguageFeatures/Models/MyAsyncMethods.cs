using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        // A simple asynchronous method
        public static Task<long?> GetPageLength1()
        { 
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");
            // we could do other things here while we are waiting for the HTTP request to complete
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }

        // Using the async and await keywords
        public async static Task<long?> GetPageLength2()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            // we could do other things here while we are waiting for the HTTP request to complete
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}
