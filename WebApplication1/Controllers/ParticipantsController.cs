using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
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
                /*System.Net.Mail.SmtpClient ss = new System.Net.Mail.SmtpClient();
                ss.Host = SMTPhost;
                ss.Port = SMTPport;
                ss.Timeout = 10000;
                ss.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                ss.UseDefaultCredentials = false;
                ss.EnableSsl = false;
                ss.Credentials = new NetworkCredential(username, password);

                MailMessage mailMsg = new MailMessage(username, to, title, body);
                mailMsg.IsBodyHtml = true;
                mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                ss.Send(mailMsg);*/


                //nova poraka
                Aspose.Email.MailMessage EmailMessage = new Aspose.Email.MailMessage();

                //popolnuvanje na porakata
                EmailMessage.Subject = title;
                EmailMessage.To = to;
                //EmailMessage.Body = body;
                EmailMessage.HtmlBody = body;
                EmailMessage.From = smtpFrom;

                //Inicijalizacija na smtp klient
                Aspose.Email.Clients.Smtp.SmtpClient SMTPEmailClient = new Aspose.Email.Clients.Smtp.SmtpClient();

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
            {//http://manevdusko-001-site1.ftempurl.com/
                string ss = participant.Id.ToString();
                Debug.WriteLine(Encrypt(ss));
                 sendMail(participant.email, "pokana", "<!DOCTYPE html> <html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'> <head> <title></title> <meta charset='utf-8'/> <meta content='width=device-width, initial-scale=1.0' name='viewport'/> <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--> <!--[if !mso]><!--> <!--<![endif]--> <style> * { box-sizing: border-box; } body { margin: 0; padding: 0; } a[x-apple-data-detectors] { color: inherit !important; text-decoration: inherit !important; } #MessageViewBody a { color: inherit; text-decoration: none; } p { line-height: inherit } @media (max-width:700px) { .icons-inner { text-align: center; } .icons-inner td { margin: 0 auto; } .fullMobileWidth, .row-content { width: 100% !important; } .image_block img.big { width: auto !important; } .mobile_hide { display: none; } .stack .column { width: 100%; display: block; } .mobile_hide { min-height: 0; max-height: 0; max-width: 0; overflow: hidden; font-size: 0px; } } </style> </head> <body style='background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;'> <table border='0' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-1' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f04b4d;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 0px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='width:100%;padding-right:0px;padding-left:0px;padding-top:35px;'> <div align='center' style='line-height:10px'><img alt='Company Logo' src='images/Logo.png' style='display: block; height: auto; border: 0; width: 136px; max-width: 100%;' title='Company Logo' width='136'/></div> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='width:100%;padding-right:0px;padding-left:0px;padding-top:35px;'> <div align='center' style='line-height:10px'><img alt='Santa Claus' class='fullMobileWidth big' src='images/Christmas_Sale.png' style='display: block; height: auto; border: 0; width: 680px; max-width: 100%;' title='Santa Claus' width='680'/></div> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'> <tr> <td style='padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:45px;'> <div style='font-family: sans-serif'> <div style='font-size: 14px; mso-line-height-alt: 16.8px; color: #ffffff; line-height: 1.2; font-family: Verdana, Geneva, sans-serif;'> <p style='margin: 0; font-size: 14px; text-align: center;'><span style='font-size:42px;'><strong>Покана за учество во Secret Santa</strong></span></p> </div> </div> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='button_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='padding-bottom:65px;padding-left:10px;padding-right:10px;padding-top:10px;text-align:center;'> <div align='center'> <!--[if mso]><v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='https://localhost:7160/Participants/Play/" +Encrypt(ss) + "' style='height:42px;width:183px;v-text-anchor:middle;' arcsize='10%' stroke='false' fillcolor='#ffffff'><w:anchorlock/><v:textbox inset='0px,0px,0px,0px'><center style='color:#f04b4d; font-family:Verdana, sans-serif; font-size:16px'><![endif]--><a href='https://localhost:7160/Participants/Play/" + Encrypt(ss) + "' style='text-decoration:none;display:inline-block;color:#f04b4d;background-color:#ffffff;border-radius:4px;width:auto;border-top:1px solid #ffffff;border-right:1px solid #ffffff;border-bottom:1px solid #ffffff;border-left:1px solid #ffffff;padding-top:5px;padding-bottom:5px;font-family:Verdana, Geneva, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;' target='_blank'><span style='padding-left:55px;padding-right:55px;font-size:16px;display:inline-block;letter-spacing:normal;'><span style='font-size: 16px; line-height: 2; word-break: break-word; mso-line-height-alt: 32px;'>Прифати</span></span></a> <!--[if mso]></center></v:textbox></v:roundrect><![endif]--> </div> </td> </tr> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-2' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'> <tr> <td style='padding-top:10px;padding-right:10px;padding-bottom:30px;padding-left:10px;'> <div style='font-family: sans-serif'> <div style='font-size: 14px; mso-line-height-alt: 16.8px; color: #555555; line-height: 1.2; font-family: Verdana, Geneva, sans-serif;'> <p style='margin: 0; font-size: 14px;'>"+participant.message+"</p> </div> </div> </td> </tr> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-3' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <div class='spacer_block' style='height:25px;line-height:25px;font-size:1px;'> </div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-4' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f04b4d;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <div class='spacer_block' style='height:40px;line-height:40px;font-size:1px;'> </div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-5' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f04b4d;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <div class='spacer_block' style='height:5px;line-height:5px;font-size:1px;'> </div> <div class='spacer_block mobile_hide' style='height:40px;line-height:40px;font-size:1px;'> </div> <div class='spacer_block' style='height:5px;line-height:5px;font-size:1px;'> </div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-6' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <table border='0' cellpadding='0' cellspacing='0' class='icons_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='color:#9d9d9d;font-family:inherit;font-size:15px;padding-bottom:5px;padding-top:5px;text-align:center;'> <table cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='text-align:center;'> <!--[if vml]><table align='left' cellpadding='0' cellspacing='0' role='presentation' style='display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;'><![endif]--> <!--[if !vml]><!--> <table cellpadding='0' cellspacing='0' class='icons-inner' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;'> <!--<![endif]--> <tr> <td style='text-align:center;padding-top:5px;padding-bottom:5px;padding-left:5px;padding-right:6px;'><a href='https://www.softicus.studio/'><img align='center' alt='Designed by MANEV' class='icon' height='32' src='images/bee.png' style='display: block; height: auto; border: 0;' width='34'/></a></td> <td style='font-family:Verdana, Geneva, sans-serif;font-size:15px;color:#9d9d9d;vertical-align:middle;letter-spacing:undefined;text-align:center;'><a href='https://softicus.studio' style='color:#9d9d9d;text-decoration:none;'>Designed by Softicus</a></td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table><!-- End --> </body> </html>");
                 //sendMail(participant.email, "pokana", "<!DOCTYPE html> <html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'> <head> <title></title> <meta charset='utf-8'/> <meta content='width=device-width, initial-scale=1.0' name='viewport'/> <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--> <!--[if !mso]><!--> <!--<![endif]--> <style> * { box-sizing: border-box; } body { margin: 0; padding: 0; } a[x-apple-data-detectors] { color: inherit !important; text-decoration: inherit !important; } #MessageViewBody a { color: inherit; text-decoration: none; } p { line-height: inherit } @media (max-width:700px) { .icons-inner { text-align: center; } .icons-inner td { margin: 0 auto; } .fullMobileWidth, .row-content { width: 100% !important; } .image_block img.big { width: auto !important; } .mobile_hide { display: none; } .stack .column { width: 100%; display: block; } .mobile_hide { min-height: 0; max-height: 0; max-width: 0; overflow: hidden; font-size: 0px; } } </style> </head> <body style='background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;'> <table border='0' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-1' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f04b4d;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 0px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='width:100%;padding-right:0px;padding-left:0px;padding-top:35px;'> <div align='center' style='line-height:10px'><img alt='Company Logo' src='images/Logo.png' style='display: block; height: auto; border: 0; width: 136px; max-width: 100%;' title='Company Logo' width='136'/></div> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='width:100%;padding-right:0px;padding-left:0px;padding-top:35px;'> <div align='center' style='line-height:10px'><img alt='Santa Claus' class='fullMobileWidth big' src='images/Christmas_Sale.png' style='display: block; height: auto; border: 0; width: 680px; max-width: 100%;' title='Santa Claus' width='680'/></div> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'> <tr> <td style='padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:45px;'> <div style='font-family: sans-serif'> <div style='font-size: 14px; mso-line-height-alt: 16.8px; color: #ffffff; line-height: 1.2; font-family: Verdana, Geneva, sans-serif;'> <p style='margin: 0; font-size: 14px; text-align: center;'><span style='font-size:42px;'><strong>Покана за учество во Secret Santa</strong></span></p> </div> </div> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='button_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='padding-bottom:65px;padding-left:10px;padding-right:10px;padding-top:10px;text-align:center;'> <div align='center'> <!--[if mso]><v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='http://manevdusko-001-site1.ftempurl.com/Participants/Play/" + Encrypt(ss) + "' style='height:42px;width:183px;v-text-anchor:middle;' arcsize='10%' stroke='false' fillcolor='#ffffff'><w:anchorlock/><v:textbox inset='0px,0px,0px,0px'><center style='color:#f04b4d; font-family:Verdana, sans-serif; font-size:16px'><![endif]--><a href='http://manevdusko-001-site1.ftempurl.com/Participants/Play/" + Encrypt(ss) + "' style='text-decoration:none;display:inline-block;color:#f04b4d;background-color:#ffffff;border-radius:4px;width:auto;border-top:1px solid #ffffff;border-right:1px solid #ffffff;border-bottom:1px solid #ffffff;border-left:1px solid #ffffff;padding-top:5px;padding-bottom:5px;font-family:Verdana, Geneva, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;' target='_blank'><span style='padding-left:55px;padding-right:55px;font-size:16px;display:inline-block;letter-spacing:normal;'><span style='font-size: 16px; line-height: 2; word-break: break-word; mso-line-height-alt: 32px;'>Прифати</span></span></a> <!--[if mso]></center></v:textbox></v:roundrect><![endif]--> </div> </td> </tr> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-2' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'> <tr> <td style='padding-top:10px;padding-right:10px;padding-bottom:30px;padding-left:10px;'> <div style='font-family: sans-serif'> <div style='font-size: 14px; mso-line-height-alt: 16.8px; color: #555555; line-height: 1.2; font-family: Verdana, Geneva, sans-serif;'> <p style='margin: 0; font-size: 14px;'>"+participant.message+"</p> </div> </div> </td> </tr> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-3' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <div class='spacer_block' style='height:25px;line-height:25px;font-size:1px;'> </div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-4' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f04b4d;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <div class='spacer_block' style='height:40px;line-height:40px;font-size:1px;'> </div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-5' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f04b4d;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <div class='spacer_block' style='height:5px;line-height:5px;font-size:1px;'> </div> <div class='spacer_block mobile_hide' style='height:40px;line-height:40px;font-size:1px;'> </div> <div class='spacer_block' style='height:5px;line-height:5px;font-size:1px;'> </div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-6' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tbody> <tr> <td> <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'> <tbody> <tr> <td class='column' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'> <table border='0' cellpadding='0' cellspacing='0' class='icons_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='color:#9d9d9d;font-family:inherit;font-size:15px;padding-bottom:5px;padding-top:5px;text-align:center;'> <table cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'> <tr> <td style='text-align:center;'> <!--[if vml]><table align='left' cellpadding='0' cellspacing='0' role='presentation' style='display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;'><![endif]--> <!--[if !vml]><!--> <table cellpadding='0' cellspacing='0' class='icons-inner' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;'> <!--<![endif]--> <tr> <td style='text-align:center;padding-top:5px;padding-bottom:5px;padding-left:5px;padding-right:6px;'><a href='https://www.softicus.studio/'><img align='center' alt='Designed by MANEV' class='icon' height='32' src='images/bee.png' style='display: block; height: auto; border: 0;' width='34'/></a></td> <td style='font-family:Verdana, Geneva, sans-serif;font-size:15px;color:#9d9d9d;vertical-align:middle;letter-spacing:undefined;text-align:center;'><a href='https://softicus.studio' style='color:#9d9d9d;text-decoration:none;'>Designed by Softicus</a></td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table><!-- End --> </body> </html>");


            }
            string s = id.ToString();

            return RedirectToAction("Index", "Participants", new { id = Encrypt(s) });
        }


        public ParticipantsController(SecretSantaContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index(string? id)
        {
            string ss = Decrypt(id);
            int hostId = Int32.Parse(ss);
            return View(await _context.Participants.Where(x => x.Host == hostId).ToListAsync());
        }
        public async Task<IActionResult> Play(string? id)
        {
            string ss = Decrypt(id);
            int playerId = Int32.Parse(ss);
            Participants player = await _context.Participants.FindAsync(playerId);
            if (player != null)
            {
                List<Participants> sameHost = await _context.Participants.Where(x => x.Host == player.Host).ToListAsync();
                List<Participants> participantsWithoutReceive = new List<Participants>();

                foreach(Participants participant in sameHost)
                {
                    if (participant.receiveFrom == null)
                        participantsWithoutReceive.Add(participant);
                }
                

                Random random = new Random();   

                int inList = random.Next(participantsWithoutReceive.Count());
                Debug.WriteLine("Random " + inList + " vkupno " + participantsWithoutReceive.Count());
                Participants buyTo = participantsWithoutReceive.ElementAt(inList);
                while(buyTo.Id == playerId)
                {
                    if (participantsWithoutReceive.Count() == 1)
                        break;
                    inList = random.Next(participantsWithoutReceive.Count());
                    Debug.WriteLine("Random " + inList + " vkupno " + participantsWithoutReceive.Count());
                    buyTo = participantsWithoutReceive.ElementAt(inList);
                }
                player.buysTO = buyTo.Id;
                buyTo.receiveFrom = player.Id;
                await _context.SaveChangesAsync();
                return View(buyTo);
            }
            return View();
        }



        public static string Encrypt(string stringvalue)
        { 
            Encoding encoding = System.Text.Encoding.Unicode;
            Byte[] stringBytes = encoding.GetBytes(stringvalue);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
        public static string Decrypt(String hexInput)
        {
            Encoding encoding = System.Text.Encoding.Unicode;
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
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
            var p = await _context.Participants.FindAsync(participants.Id);
            if (p == null) //participants
            {
                if (ModelState.IsValid)
                {
                    _context.Add(participants);
                    await _context.SaveChangesAsync();
                    string s = participants.Id.ToString();
                    return RedirectToAction("Index", "Participants", new { id = Encrypt(s) });
                }
            }
            else
            {
                _context.Participants.Add(new Participants(participants.Name, participants.email, participants.message, participants.Id));
                await _context.SaveChangesAsync();
                string s = participants.Id.ToString();
                return RedirectToAction("Index", "Participants", new { id = Encrypt(s) });
            }
            return View(participants);
        }

        private bool ParticipantsExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
