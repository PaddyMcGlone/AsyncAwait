using System.Collections.Generic;

namespace AsyncAndAwaitMVCProject.Models
{
    public class HomePageModel
    {
        public HomePageModel()
        {
            Message = new List<string>();    
        }

        public List<string> Message { get; set; }
    }
}