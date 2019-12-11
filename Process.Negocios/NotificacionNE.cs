using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process.Datos;
using Process.Modelos;

namespace Process.Negocios
{
    public class NotificacionNE
    {
        public int notificacionAsignacion(string _correo_destino, int _id_tarea, string _nombre_tarea, string _flujo_nombre, string _nombre_funcionario_destino, string _nombre_funcionario_origen, string _nombre_equipo, string _nombre_unidad, string _nombre_empresa)
        {
            //Instancia de libreria Mail
            System.Net.Mail.MailMessage auxCorreo = new System.Net.Mail.MailMessage();

            try
            {
                int retorno = 1;

                //Asunto Correo
                string _asunto_correo = "ATENCION Asignacion de Tarea, se le acaba de asignar una Tarea en Plataforma PROCESS";
                //Cuerpo Correo
                string _cuerpo_correo = "Estimado " + _nombre_funcionario_destino.ToUpper() + "\n\r" +
                                        "Le notificamos que se le acaba de asignar la tarea Nº " + _id_tarea + " con el nombre:" + _nombre_tarea.ToUpper() + "\n\r" +
                                        "que pertenece al Flujo de trabajo " + _flujo_nombre.ToUpper() + ", esta tarea fue asignada por " + _nombre_funcionario_origen.ToUpper() + " que pertenece al equipo de trabajo " + _nombre_equipo.ToUpper() + "\n\r" +
                                        "correspondiente a la Unidad " + _nombre_unidad.ToUpper() + " de la Empresa " + _nombre_empresa.ToUpper() + " ." + "\n\r" +
                                        "Favor estar atento a su tarea recien asignada." + "\n\r" +
                                        "\n\r" +
                                        "\n\r" +
                                        "Saludos" + "\n\r" +
                                        "Atentamente Plataforma PROCESS.";

                //Creacion de formato correo
                //Agregar Destinatario funcionario asignado
                auxCorreo.To.Add(_correo_destino);                
                //Agregar asunto
                auxCorreo.Subject = _asunto_correo;
                auxCorreo.SubjectEncoding = System.Text.Encoding.UTF8;
                //Agregar Cuerpo de Mensaje
                auxCorreo.Body = _cuerpo_correo;
                auxCorreo.BodyEncoding = System.Text.Encoding.UTF8;
                auxCorreo.IsBodyHtml = false;
                //Agregar Remitente de Correo
                auxCorreo.From = new System.Net.Mail.MailAddress("CONTACTO.PROCESS@gmail.com");
                //Crear cliente correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials = new System.Net.NetworkCredential("CONTACTO.PROCESS@gmail.com", "Portafolio.2019");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";// mail.dominio.com
                                                //Enviar correo
                cliente.Send(auxCorreo);

                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int notificacionRechazo(string _correo_destino, int _id_tarea, string _nombre_tarea, string _flujo_nombre, string _nombre_funcionario_destino, string _nombre_funcionario_origen, string _nombre_empresa, string _motivo)
        {
            //Instancia de libreria Mail
            System.Net.Mail.MailMessage auxCorreo = new System.Net.Mail.MailMessage();

            try
            {
                int retorno = 1;

                //Asunto Correo
                string _asunto_correo = "ATENCION Rechazo de Tarea, se acaba de Rechazar una tarea asignada por Usted en Plataforma PROCESS";
                //Cuerpo Correo
                string _cuerpo_correo = "Estimado " + _nombre_funcionario_destino.ToUpper() + "\n\r" +
                                        "Le notificamos que se acaba de rechazar la tarea Nº " + _id_tarea + " con el nombre:" + _nombre_tarea.ToUpper() + "\n\r" +
                                        "que pertenece al Flujo de trabajo " + _flujo_nombre.ToUpper() + ", esta tarea fue rechazada por " + _nombre_funcionario_origen.ToUpper() + " de la Empresa " + _nombre_empresa.ToUpper() + " ." + "\n\r" +
                                        "El motivo del rechazo es el siguiente " + _motivo.ToUpper() + "." + "\n\r" +
                                        "\n\r" +
                                        "\n\r" +
                                        "Saludos" + "\n\r" +
                                        "Atentamente Plataforma PROCESS.";

                //Creacion de formato correo
                //Agregar Destinatario funcionario asignado
                auxCorreo.To.Add(_correo_destino);
                //Agregar asunto
                auxCorreo.Subject = _asunto_correo;
                auxCorreo.SubjectEncoding = System.Text.Encoding.UTF8;
                //Agregar Cuerpo de Mensaje
                auxCorreo.Body = _cuerpo_correo;
                auxCorreo.BodyEncoding = System.Text.Encoding.UTF8;
                auxCorreo.IsBodyHtml = false;
                //Agregar Remitente de Correo
                auxCorreo.From = new System.Net.Mail.MailAddress("CONTACTO.PROCESS@gmail.com");
                //Crear cliente correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials = new System.Net.NetworkCredential("CONTACTO.PROCESS@gmail.com", "Portafolio.2019");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";// mail.dominio.com
                                                //Enviar correo
                cliente.Send(auxCorreo);

                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int notificacionProblema(string _correo_destino, int _id_tarea, string _nombre_tarea, string _flujo_nombre, string _nombre_funcionario_destino, string _nombre_funcionario_origen, string _nombre_empresa, string _descripcion)
        {
            //Instancia de libreria Mail
            System.Net.Mail.MailMessage auxCorreo = new System.Net.Mail.MailMessage();

            try
            {
                int retorno = 1;

                //Asunto Correo
                string _asunto_correo = "ATENCION Problema de Tarea, se acaba de notificar una tarea asignada por Usted en Plataforma PROCESS";
                //Cuerpo Correo
                string _cuerpo_correo = "Estimado " + _nombre_funcionario_destino.ToUpper() + "\n\r" +
                                        "Le notificamos que se acaba de notificar un problema en la tarea Nº " + _id_tarea + " con el nombre:" + _nombre_tarea.ToUpper() + "\n\r" +
                                        "que pertenece al Flujo de trabajo " + _flujo_nombre.ToUpper() + ", esta tarea fue notificada por " + _nombre_funcionario_origen.ToUpper() + " de la Empresa " + _nombre_empresa.ToUpper() + " ." + "\n\r" +
                                        "La descripcion del problema es la siguiente " + _descripcion.ToUpper() + "." + "\n\r" +
                                        "\n\r" +
                                        "\n\r" +
                                        "Saludos" + "\n\r" +
                                        "Atentamente Plataforma PROCESS.";

                //Creacion de formato correo
                //Agregar Destinatario funcionario asignado
                auxCorreo.To.Add(_correo_destino);
                //Agregar asunto
                auxCorreo.Subject = _asunto_correo;
                auxCorreo.SubjectEncoding = System.Text.Encoding.UTF8;
                //Agregar Cuerpo de Mensaje
                auxCorreo.Body = _cuerpo_correo;
                auxCorreo.BodyEncoding = System.Text.Encoding.UTF8;
                auxCorreo.IsBodyHtml = false;
                //Agregar Remitente de Correo
                auxCorreo.From = new System.Net.Mail.MailAddress("CONTACTO.PROCESS@gmail.com");
                //Crear cliente correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials = new System.Net.NetworkCredential("CONTACTO.PROCESS@gmail.com", "Portafolio.2019");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";// mail.dominio.com
                                                //Enviar correo
                cliente.Send(auxCorreo);

                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
