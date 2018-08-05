using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace CheHtmlToPdfConverter.Helpers
{
    public static class ResponseTagHelper
    {
        public static string GetTitleFromUrl(string url)
        {
            var title = "";
            try
            {
                var request = (HttpWebRequest.Create(url) as HttpWebRequest);
                if (request != null)
                {
                    var response = (request.GetResponse() as HttpWebResponse);

                    if (response != null)
                        using (var stream = response.GetResponseStream())
                        {
                            // compiled regex to check for <title></title> block
                            var titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>",
                                RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            const int bytesToRead = 8092;
                            var buffer = new byte[bytesToRead];
                            var contents = "";
                            int length;
                            while (stream != null && (length = stream.Read(buffer, 0, bytesToRead)) > 0)
                            {
                                // convert the byte-array to a string and add it to the rest of the
                                // contents that have been downloaded so far
                                contents += Encoding.UTF8.GetString(buffer, 0, length);

                                var m = titleCheck.Match(contents);
                                if (m.Success)
                                {
                                    // we found a <title></title> match =]
                                    title = m.Groups[1].Value;
                                    break;
                                }
                                else if (contents.Contains("</head>"))
                                {
                                    // reached end of head-block; no title found =[
                                    break;
                                }
                            }
                        }
                }
            }
            catch (Exception)
            {
                return "";
            }
            return title;
        }

        public static string GetWebPageTitle(string url, int timeout)
        {
            try
            {
                var request = (HttpWebRequest.Create(url) as HttpWebRequest);
                request.Timeout = timeout;
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                var response = (request.GetResponse() as HttpWebResponse);
                using (var stream = response.GetResponseStream())
                {
                    // compiled regex to check for <title></title> block
                    var titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    const int bytesToRead = 8092;
                    var buffer = new byte[bytesToRead];
                    var contents = "";
                    int length;
                    while ((length = stream.Read(buffer, 0, bytesToRead)) > 0)
                    {
                        // convert the byte-array to a string and add it to the rest of the
                        // contents that have been downloaded so far
                        contents += Encoding.UTF8.GetString(buffer, 0, length);

                        var m = titleCheck.Match(contents);
                        if (m.Success)
                        {
                            // we found a <title></title> match =]
                            return m.Groups[1].Value;
                        }
                        else if (contents.Contains("</head>"))
                        {
                            // reached end of head-block; no title found =[
                            return "";
                        }
                    }
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
