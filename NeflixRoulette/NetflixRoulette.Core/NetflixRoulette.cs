using NetflixRoulette.Core.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace NetflixRoulette.Core
{
    public class NetflixRoulette
    {

        public const string ApiUrl = "http://netflixroulette.net/api/api.php";

        Dictionary<string, string> parameters = new Dictionary<string, string>();

        public NetflixRoulette()
        {

        }
        public MediaObject GetData(string title)
        {
            return getData(title, null);
        }
        public MediaObject GetData(string title, int year, string director, string actor)
        {
            return getData(title, year, director, actor);
        }
        private MediaObject getData(string title, int year, string director, string actor)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.BaseAddress = ApiUrl;
                    StringBuilder sb = new StringBuilder();

                    sb.Append("?");

                    foreach (var kvp in parameters) //kvp stands for KeyValuePair.
                    {
                        sb.Append($"&{kvp.Key}={kvp.Value}");
                    }

                    string url = "http://netflixroulette.net/api/api.php" + sb.ToString();

                    if (!string.IsNullOrEmpty(title))
                    {
                        parameters.Add("title", title);
                    }
                    if (!string.IsNullOrEmpty(year))
                    {

                        parameters.Add("year", year);
                    }

                    if (!string.IsNullOrEmpty(actor))

                    {
                        parameters.Add("actor", actor);
                    }
                    if (!string.IsNullOrEmpty(director))
                    {
                        parameters.Add("director", director);
                    }
                    Stream stream = client.OpenRead(sb.ToString());
                    var reader = new StreamReader(stream);
                    MediaObject media = JsonConvert.DeserializeObject<MediaObject>(reader.ReadToEnd());
                    if (string.IsNullOrEmpty(media.show_title))
                    {
                        media.success = false;
                        media.mediatype = MediaObject.MediaType.Error;

                    }
                    else
                    {
                        media.success = true;
                    }
                    return media;
                }
            }
            catch (Exception ex)
            {
                return new MediaObject() { success = false, mediatype = MediaObject.MediaType.Error };
            }
        }
    }
}

