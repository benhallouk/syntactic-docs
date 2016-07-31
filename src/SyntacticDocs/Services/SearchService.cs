using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SyntacticDocs.Services
{
    public class SearchService
    {
        public readonly string SolrBaseUrl;
        public SearchService(IHostingEnvironment env)
        {            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            SolrBaseUrl = builder.Build()["SolrBaseUrl"];    
        }

        public async void ImportData()
        {            
            var solrRequest = WebRequest.Create(SolrBaseUrl+"dataimport?command=full-import&verbose=false&clean=true&commit=true&optimize=false&core=SyntacticDocs");
            solrRequest.Method = "POST";
            var solrResponse =  await solrRequest.GetResponseAsync();       
            var solrResponseStream = solrResponse.GetResponseStream();                 
            var solrResponseReader = new StreamReader(solrResponseStream);               
            string solrResponseData = solrResponseReader.ReadToEnd();
            //Console.WriteLine("======== Solr Response =========");   
            //Console.WriteLine(solrResponseData);
            //Console.WriteLine("======== Solr Response End =====");            
        }
    }
}