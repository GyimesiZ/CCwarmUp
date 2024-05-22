using System.Net.Mail;
using System.Net;

namespace DevopsApi
{
    public class Mail
    {
        private MailMessage _message;
        private bool _testMode;

        public Mail(string subject, string body,bool testMode, bool prio = false)
        {
            _message = new MailMessage();
            _testMode = testMode;
            if (prio)
            {
                _message.Priority = MailPriority.High;
            }
            _message.Subject = subject;
            _message.Body = body;
            _message.IsBodyHtml = true;
        }
        public void AddRecipient(string RecipientAddress, string Type = "")
        {
            switch (Type.ToLower().Trim())
            {
                case "cc":
                    _message.CC.Add(RecipientAddress);
                    break;
                case "bcc":
                    _message.Bcc.Add(RecipientAddress);
                    break;
                default:
                    _message.To.Add(RecipientAddress);
                    break;
            }

        }
        public string SendMail()
        {
            if (_testMode)
            {
                _message.Body += "<br><h3>Teszt üzemmód</h3><b>Eredeti címzettek:</b><br>";
                _message.Subject += "(Teszt)";
                foreach(var c in _message.To)
                {
                    _message.Body += $"<li>{c.Address}";
                }
                _message.To.Clear();
                _message.To.Add("zoltan.gyimesi@semilab.hu");
                _message.To.Add("mihaly.urban@semilab.hu");
                _message.Body += "<br><b>Eredeti másolat címzettek:</b><br>";
                foreach (var cc in _message.CC)
                {
                    _message.Body += $"<li>{cc.Address}";
                }
                _message.CC.Clear();
            }
            else
            {
                _message.Body += "<br><br><i>Ez egy automatikusan generált levél a <a href = 'https://semilabshareddesk.azurewebsites.net/'>Semilab SharedDesk</a> rendszeréből. Ne válaszolj rá!</i>";
            }
            var smtpServer = new SmtpClient("semilab-hu.mail.protection.outlook.com")
            {
                Port = 25,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Timeout = 600000
            };
            _message.From = new MailAddress("shareddesk@semilab.hu");
            try
            {
                smtpServer.Send(_message);
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
