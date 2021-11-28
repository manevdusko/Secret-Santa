using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Email.Clients;
using Aspose.Email.Clients.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly SecretSantaContext _context;

        private string smtpFrom = "dushkomanev@outlook.com";
        private string SMTPhost = "smtp.office365.com";
        private int SMTPport = 587;

        private string username = "dushkomanev@outlook.com";
        private string password = "TestPassword1!";


        private void sendMail(string to, string title, string body)
        {
            try
            {
                //nova poraka
                Aspose.Email.MailMessage EmailMessage = new Aspose.Email.MailMessage();

                //popolnuvanje na porakata
                EmailMessage.Subject = title;
                EmailMessage.To = to;
                EmailMessage.Body = body;
                EmailMessage.From = smtpFrom;

                //Inicijalizacija na smtp klient
                SmtpClient SMTPEmailClient = new SmtpClient();

                //postavuvanje na postavkite na smtp
                SMTPEmailClient.Host = SMTPhost;
                SMTPEmailClient.Username = username;
                SMTPEmailClient.Password = password;
                SMTPEmailClient.Port = SMTPport;
                SMTPEmailClient.SecurityOptions = SecurityOptions.SSLExplicit;

                //prakjanje na mailot
                SMTPEmailClient.Send(EmailMessage);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
        }



        public async Task<IActionResult> Invite(int? id)
        {
            List<Participants> participants = await _context.Participants.Where(x => x.Host == id).ToListAsync();
            var p = await _context.Participants.FindAsync(id);
            foreach (Participants participant in participants)
            {
                sendMail(participant.email, "Покана за учество во Secret Santa", "Вие сте поканети за учество во Secret Santa, организатое е " + p.Name + ". Кликнете <a href='google.com'>тука</a> за да видите со кого ќе учествувате ");
            }

            return RedirectToAction("Index", "Participants", new { id = id });
        }


        public ParticipantsController(SecretSantaContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.Participants.Where(x => x.Host == id).ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participants = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participants == null)
            {
                return NotFound();
            }

            return View(participants);
        }

        // GET: Participants/Create
        public IActionResult Create(int id)
        {
            ViewBag.Message = id;
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,email,message")] Participants participants)
        {
            Debug.WriteLine("NOR WE ARE HERE");
            var p = await _context.Participants.FindAsync(participants.Id);
            if (p == null) //participants
            {
                Debug.WriteLine("NOT WE ARE HERE");

                if (ModelState.IsValid)
                {
                    _context.Add(participants);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Participants", new { id = participants.Id });
                }
            }
            else
            {
                Debug.WriteLine("WE ARE HERE");
                _context.Participants.Add(new Participants(participants.Name, participants.email, participants.message, participants.Id));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Participants", new { id = participants.Id });
            }
            return View(participants);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
             if (id == null)
             {
                 return NotFound();
             }

             var participants = await _context.Participants.FindAsync(id);
             if (participants == null)
             {
                 return NotFound();
             }

            return View(participants);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,email,message")] Participants participants)
        {
            if (id != participants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantsExists(participants.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(participants);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participants = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participants == null)
            {
                return NotFound();
            }

            return View(participants);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participants = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(participants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantsExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
