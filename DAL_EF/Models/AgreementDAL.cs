using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
        public class AgreementDAL
        {
            DMSEntities db = new DMSEntities();

            public List<Agreement> GetAll()
            {
                return db.Agreements.ToList();
            }

            public Agreement GetById(int id)
            {
                return db.Agreements.Where(p => p.AgreementId == id).SingleOrDefault();
            }

            public void Insert(Agreement agreement)
            {
                db.Agreements.Add(agreement);
                db.SaveChanges();
            }

            public void Update(Agreement agreement)
            {
                db.Entry(agreement).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            public Int32 InsertReturnId(Agreement agreement)
            {
                int id = Int32.MinValue;
                db.Agreements.Add(agreement);
                TransactionScope ts = new TransactionScope();
                try
                {
                    if (db.SaveChanges() > 0)
                    {
                        id = agreement.AgreementId;
                        ts.Complete();
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message, ex.InnerException);
                }
                finally
                {
                    if (ts != null)
                    {
                        ((IDisposable)ts).Dispose();
                    }
                }

                return id;

            }

            public void DeletePermanently(Agreement agreement)
            {
                db.Agreements.Remove(agreement);
                db.SaveChanges();
            }

        }
    }
