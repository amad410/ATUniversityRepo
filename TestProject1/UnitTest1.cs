using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using Newtonsoft.Json;
using System.ComponentModel;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace TestProject1
{
    //class library .Net
    public class Tests
    {
        private string? URL;
        private string? SoapString;
        private string? ActionString;
        private static HttpClient? HClient;

        [SetUp]
        public void Setup()
        {
            HClient = new HttpClient();
            URL = "https://www.dataaccess.com/webservicesserver/NumberConversion.wso";
            ActionString = "SOAPAction";
            SoapString = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                        <NumberToWords 
                            xmlns = ""http://www.dataaccess.com/webservicesserver/"">
                            <ubiNum>500</ubiNum>
                        </NumberToWords>
                    </soap:Body>
                </soap:Envelope>";
        }

        [TearDown]
        public void Teardown()
        {
            URL = null;
            ActionString = null;
            SoapString = null;
            HClient = null;
        }

        /// <summary>
        /// This test method is only intended to exemplify the use of the tools mentioned in the lecture.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Test1()
        {
            //int celsius = 20;
            //int farenheit = 68;

            string result;

            //HClient = new HttpClient();
            //URL = GetTemperatureURL();
            //ActionString = GetTemperatureAction();
            //SoapString = ConstructSoapRequest(celsius);

            result = await RequestSOAP(URL, ActionString, SoapString, HClient);
            Console.WriteLine(result);

            result = await RequestSOAP();
            Console.WriteLine(result);

            result = await RequestREST();
            Console.WriteLine(result);

            //Assert.AreEqual(result, farenheit);

            Console.WriteLine( RequestRestS().ToString() );

            Console.WriteLine(ConvertToJson());
        }

        private static async Task<string> RequestSOAP(string url_,
            string action_, string body_, HttpClient client_)
        {
            using (HttpContent content = new StringContent(body_,
                Encoding.UTF8, "text/xml"))
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                    url_))
                {
                    request.Headers.Add("SOAPAction", action_);
                    request.Content = content;

                    using (HttpResponseMessage response = await client_.SendAsync(request))
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
        }


        private static async Task<string> RequestSOAP()
        {
            HttpClient client = new();

            using HttpContent content = new StringContent(
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                        <NumberToWords 
                            xmlns = ""http://www.dataaccess.com/webservicesserver/"">
                            <ubiNum>500</ubiNum>
                        </NumberToWords>
                    </soap:Body>
                </soap:Envelope>",
                Encoding.UTF8, "text/xml");

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                "https://www.dataaccess.com/webservicesserver/NumberConversion.wso");

            request.Headers.Add("SOAPAction", "");
            request.Content = content;

            using HttpResponseMessage response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }


        private static async Task<string> RequestREST()
        {
            HttpClient client = new();

            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://www.dataaccess.com/webservicesserver/" +
                "NumberConversion.wso/NumberToWords/JSON/debug?ubiNum=500");

            using HttpResponseMessage response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        private static List<StatsC19> RequestRestS()
        {
            RestClient client = new RestClient("https://api.covidtracking.com");
            RestRequest request = new RestRequest("/v1/us/current.json");

            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            
            IRestResponse response = client.Execute(request);

            string content = response.Content; Console.WriteLine(content);

            var stats = JsonConvert.DeserializeObject<List<StatsC19>>(content);
            
            return stats;
        }
        private string GetWeatherURL()
        {
            return "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";
        }
        private string GetTemperatureURL()
        {
            return "https://www.w3schools.com/xml/tempconvert.asmx";
        }
        private string GetTemperatureAction()
        {
            return "https://www.w3schools.com/xml/CelsiusToFahrenheit";
        }
        private static string ConstructSoapRequest()
        {
            return @"
                <?xml version=""1.0"" encoding=""utf - 8""?>
                < soap:Envelope xmlns: soap = ""http://schemas.xmlsoap.org/soap/envelope/"" >
                    < soap:Body >
                    < ListOfLanguagesByName xmlns = ""http://www.oorsprong.org/websamples.countryinfo"" >
                    </ ListOfLanguagesByName >
                    </ soap:Body >
                </ soap:Envelope >
            ";
        }

        private static string ConstructSoapRequest(int celsius_)
        {
            return String.Format(@"
                <?xml version=""1.0"" encoding=""utf - 8""?>
                <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                  < soap12:Body >
                     < CelsiusToFahrenheit xmlns = ""https://www.w3schools.com/xml/"" >
                        < Celsius > {0} </ Celsius >
                      </ CelsiusToFahrenheit >
                    </ soap12:Body >
                   </ soap12:Envelope >
                ", celsius_);
        }

        private string ToJson()
        {
            ObjTest session = new(URL, SoapString, ActionString);

            JsonNetSerializer serializer = new();
            return serializer.Serialize(session);
        }

        private string ConvertToJson()
        {
            ObjTest session = new(
                    "https://www.dataaccess.com/webservicesserver/NumberConversion.wso",
                    @"<?xml version=""1.0"" encoding="" utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                        <soap:Body>
                            <NumberToWords 
                                xmlns = ""http://www.dataaccess.com/webservicesserver/"">
                                <ubiNum>500</ubiNum>
                            </NumberToWords>
                        </soap:Body>
                    </soap:Envelope>",
                    "SOAPAction"
                );

            JsonNetSerializer serializer = new();
            return serializer.Serialize(session);
        }

        
    }
    
    class ObjTest
    {
        [JsonProperty(PropertyName = "Url")]
        private string URL { get; set; }
        [JsonProperty(PropertyName = "Content")]
        private string Content { get; set; }
        [JsonProperty(PropertyName = "Action")]
        private string Action { get; set; }

        public ObjTest(string url_, string content_, string action_)
        {
            this.URL = url_;
            this.Content = content_;
            this.Action = action_;
        }
    }

    class StatsC19
    {
        public int Date { get; set; }
        public int Positive { get; set; }
        public int Negative { get; set; }
        public int HospitalizedCurrently { get; set; }
        public int HospitalizedCumulative { get; set; }
        public int Hospitalized { get; set; }
        public int TotalTestResults { get; set; }
        public int HospitalizedIncrease { get; set; }
        public int NegativeIncrease { get; set; }
        public int PositiveIncrease { get; set; }
        public int TotalTestResultsIncrease { get; set; }
    }
}



