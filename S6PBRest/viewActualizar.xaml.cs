using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6PBRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewActualizar : ContentPage
    {
        public viewActualizar(int c, string n, string a, int e)
        {
            InitializeComponent();
            lblCodigo.Text = c.ToString();
            txtNombre.Text = n;
            txtApellido.Text = a;
            txtEdad.Text = e.ToString();
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                //conectamos al servicio web
                cliente.UploadValues("http://192.168.1.9/moviles/post.php?codigo=" +
                    Int32.Parse(lblCodigo.Text) + "&" + "nombre=" +
                    txtNombre.Text + "&" + "apellido=" + txtApellido.Text +
                    "&" + "edad=" + Int32.Parse(txtEdad.Text), "PUT", parametros);
                DisplayAlert("Mensaje", "Se actualizo correctamente", "OK");
                lblCodigo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "OK");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}