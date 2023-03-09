using DALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.ModelDTO
{
    public class LogDataDto
    {
        private ApplicaitonDbContext context;
        public LogDataDto(ApplicaitonDbContext _context)
        {
            context = _context;
        }
        
        public void LogDetails(string Logmessage,string exceptionmessage)
        {
            Logs obj = new Logs();
            obj.Logmessage = Logmessage;
            obj.Execptionmessage = exceptionmessage!=""?exceptionmessage:null;
            obj.CreatedDate = DateTime.Now;
            context.Logs.Add(obj);
            context.SaveChanges();
        }
    }
}
