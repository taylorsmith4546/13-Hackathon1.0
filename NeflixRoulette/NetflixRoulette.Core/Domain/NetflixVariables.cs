using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoulette.Core.Domain
{
    public class MediaObject
    {
        
       
        public enum MediaType : int
        {
            Movie = 0,
            TVShow = 1,
            Error = -1
        }

       
        public bool success { get; set; }
        public int unit { get; set; }
        public int show_id { get; set; }
        public string show_title { get; set; }
        public int release_year { get; set; }
      
        public decimal rating { get; set; }
        public string category { get; set; }
        public string show_cast { get; set; }
        public string director { get; set; }
        public string summary { get; set; }
      
        public string poster { get; set; }
        public MediaType mediatype { get; set; }
       
        public MediaObject()
        {

        }
    }
}
    
