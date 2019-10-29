using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EjemploTwilio
{
    public partial class EnvioMensajes : Form
    {
        public EnvioMensajes()
        {
            InitializeComponent();
        }



        private void smssendBT_Click(object sender, EventArgs e)
        {
            try
            {
                //ID de la Cuenta del proyecto de Twilio Creado en la Pagina
                var accountSid = "ACb03a93862115f88222ca8142d7988c94";

                //Codigo de verificacion de la cuenta
                var authToken = "1eab81685fabd3213cbead05074da6cb";

                //inicializa el servicio del Twilio
                TwilioClient.Init(accountSid, authToken);

                //Creamos un nuevo Mensaje, se inicializa con el numero que recibe el mensaje
                var messageOptions = new CreateMessageOptions(new PhoneNumber($"+506{toTB.Text}"));

                //agregamos el numero que envia, este nos lo da Twilio
                messageOptions.From = new PhoneNumber(senderTB.Text);

                //Llenamos el cuerpo del mensaje
                messageOptions.Body = mensajeTB.Text;
                

                // se envia el mensaje
                var message = MessageResource.Create(messageOptions);




                detalleTB.Text = $"De: {message.From}\n";
                detalleTB.Text += $"Para: {message.To}\n";
                detalleTB.Text += $"Mensaje: {message.Body}\n";
            }
            catch (Exception ex)
            {
                detalleTB.Text = ex.Message;
                
            }
        }

        private void WsmsBT_Click(object sender, EventArgs e)
        {
            try
            {
                var accountSid = "ACb03a93862115f88222ca8142d7988c94";
                var authToken = "1eab81685fabd3213cbead05074da6cb";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:+506{WtoTB.Text}"));
                messageOptions.From = new PhoneNumber($"whatsapp:{WsenderTB.Text}");
                messageOptions.Body = WmensajeTB.Text;
                

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
                WdetalleTB.Text = $"De: {message.From}\n";
                WdetalleTB.Text += $"Para: {message.To}\n";
                WdetalleTB.Text += $"Mensaje: {message.Body}\n";
            }
            catch (Exception ex)
            {

                detalleTB.Text = ex.Message;
            }
        }
    }
}
