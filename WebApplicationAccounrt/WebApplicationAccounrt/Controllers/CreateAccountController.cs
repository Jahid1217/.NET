using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAccounrt.ConText;

namespace WebApplicationAccounrt.Controllers
{
    public class CreateAccountController : Controller
    {
        // GET: CreateAccount
        AccountDBEntities _ConTextDB = new AccountDBEntities();
        public ActionResult Index()
        {
            var date = _ConTextDB.Accounts.ToList();
            return View(date);
        }
        public ActionResult AccountInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccountInfoSave(Account acc)
        {
            if (ModelState.IsValid)
            {
                _ConTextDB.Accounts.Add(acc);
                _ConTextDB.SaveChanges();
                TempData["Success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View("AccountInfo", acc);
        }


        public ActionResult AccountInfoDelete(int? Id)
        {
            var acc = _ConTextDB.Accounts.Where(x => x.Id == Id).First();
            if (acc != null)
            {
                _ConTextDB.Accounts.Remove(acc);
                _ConTextDB.SaveChanges();
                TempData["Success"] = "Deleted Successfully";
            }
            return RedirectToAction("Index");
        }

       

        public ActionResult BalanceInfoEdit(Account acc)
        {
            return View(acc);
        }
        [HttpPost]
        public ActionResult BalanceInfoEditSave(int Id, string TransactionType, float Balance)
        {
            // Validate input
            if (Id <= 0)
            {
                TempData["Error"] = "Invalid account ID.";
                return RedirectToAction("Index");
            }

            var account = _ConTextDB.Accounts.FirstOrDefault(x => x.Id == Id);
            if (account == null)
            {
                TempData["Error"] = "Account not found.";
                return RedirectToAction("Index");
            }

            if (Balance <= 0)
            {
                TempData["Error"] = "Amount must be greater than zero.";
                return RedirectToAction("BalanceInfoEdit", new { Id });
            }

            try
            {
                if (TransactionType == "deposit")
                {
                    account.Balance += Balance;
                    TempData["Success"] = $"Amount {Balance} deposited successfully. New balance: {account.Balance}";
                }
                else if (TransactionType == "credit")
                {
                    if (Balance > account.Balance)
                    {
                        TempData["Error"] = $"Insufficient balance. Available: {account.Balance}, Requested: {Balance}";
                        return RedirectToAction("BalanceInfoEdit", new { Id });
                    }

                    account.Balance -= Balance;
                    TempData["Success"] = $"Amount {Balance} credited successfully. New balance: {account.Balance}";
                }
                else
                {
                    TempData["Error"] = "Invalid transaction type.";
                    return RedirectToAction("BalanceInfoEdit", new { Id });
                }

                _ConTextDB.Entry(account).State = EntityState.Modified;
                _ConTextDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("BalanceInfoEdit", new { Id });
            }
        }
    }
}