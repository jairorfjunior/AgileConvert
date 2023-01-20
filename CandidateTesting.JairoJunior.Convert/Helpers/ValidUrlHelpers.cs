using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidateTesting.JairoJunior.Convert.Helpers
{
    public class ValidUrlHelpers
    {

        public static bool ValidHttpURL(string s, out Uri resultURI)
        {
            if (!Regex.IsMatch(s, @"^https?:\/\/", RegexOptions.IgnoreCase))
                s = "http://" + s;

            if (Uri.TryCreate(s, UriKind.Absolute, out resultURI))
                return resultURI.Scheme == Uri.UriSchemeHttp ||
                        resultURI.Scheme == Uri.UriSchemeHttps;

            return false;
        }

        //[TestCase("http://www.example.com/")]
        //[TestCase("https://www.example.com")]
        //[TestCase("http://example.com")]
        //[TestCase("https://example.com")]
        //[TestCase("www.example.com")]
        //public void IsValidUrlTest(string url)
        //{
        //    bool result = UriHelper.IsValidUrl(url);

        //    Assert.AreEqual(result, true);
        //}

        //[TestCase("http.www.example.com")]
        //[TestCase("http:www.example.com")]
        //[TestCase("http:/www.example.com")]
        //[TestCase("http://www.example.")]
        //[TestCase("http://www.example..com")]
        //[TestCase("https.www.example.com")]
        //[TestCase("https:www.example.com")]
        //[TestCase("https:/www.example.com")]
        //[TestCase("http:/example.com")]
        //[TestCase("https:/example.com")]
        //public void IsInvalidUrlTest(string url)
        //{
        //    bool result = UriHelper.IsValidUrl(url);

        //    Assert.AreEqual(result, false);
        //}
    }

}

