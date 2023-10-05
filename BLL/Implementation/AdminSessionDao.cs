using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;

namespace BLL.Implementation
{
    public class AdminSessionDao : AdminSessionDAO
    {
        public async Task<long> CreateSession(int id)
        {
          await using (var _context= new Online_Food_ApplicationContext())
            {
                AdminSession session = new AdminSession();
                var _sessionId = _context.TblAdminSessions.Max(x => (int?)x.AdminSessionId) ?? 0;
                TblAdminSession tbl = new TblAdminSession();
                tbl.AdminSessionId = (int)(_sessionId + 1);
                tbl.SessionStart = Convert.ToDateTime(DateTime.Now.ToString());
                tbl.AdminId = id;
                _context.TblAdminSessions.Add(tbl);
                _context.SaveChanges();
                return tbl.AdminSessionId;
            }
        }

        public async Task<bool> EndSession(long id)
        {
            await using (var _context= new Online_Food_ApplicationContext())
            {
                TblAdminSession session = new TblAdminSession();
                session=await _context.TblAdminSessions.FindAsync(id);
                if (session != null)
                {
                    session.SessionEnd = Convert.ToDateTime(DateTime.Now.ToString());
                    _context.TblAdminSessions.Update(session);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
