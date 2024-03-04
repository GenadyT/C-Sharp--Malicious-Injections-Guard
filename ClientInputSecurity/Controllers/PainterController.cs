using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using CheckMalicious;
using ClientInputSecurity.Models.Painter;

namespace ClientInputSecurity.Controllers
{
    public class PainterController : ApiController
    {
        // POST: Painters
        [HttpPost]
        //[Route("api/Painter/InsertPainter")]
        //[Route("InsertPainter/{painter}")]
        public IHttpActionResult InsertPainter(Painter painter)
        {
            try
            {
                PainterUmbrel painterUmbrel = new PainterUmbrel(painter);
                MaliciousInfo maliciousInfo = painterUmbrel.ReportMalicious();                                
                return Ok(maliciousInfo);                
            }
            catch (System.Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
