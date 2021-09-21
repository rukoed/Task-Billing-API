using System.Web.Mvc;

namespace Test.Models
{
    public class Result
    {
        public ActionResult Status { get; set; }

        public Receipt Receipt { get; set; }
    }
}