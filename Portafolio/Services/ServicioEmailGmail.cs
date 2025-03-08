using System.Net;
using System.Net.Mail;
using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var port = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PORT");

            var smtpÇliente = new SmtpClient(host, port);
            smtpÇliente.EnableSsl = true;
            smtpÇliente.UseDefaultCredentials = false;

            smtpÇliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor, emailEmisor, $"El cliente {contacto.Nombre} ({contacto.Email}) quiere contactarte", contacto.Mensaje);

            await smtpÇliente.SendMailAsync(mensaje);

        }
    }
}
