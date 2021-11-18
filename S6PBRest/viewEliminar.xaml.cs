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
    public partial class viewEliminar : ContentPage
    {
        private int codigo;

        public viewEliminar(int c)
        {
            InitializeComponent();
            lblCodigo.Text = c.ToString();
        }

        private void btnQuitar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                //conectamos al servicio web
                cliente.UploadValues("http://192.168.1.9/moviles/post.php?codigo=" +
                    lblCodigo.Text, "DELETE", parametros);
                DisplayAlert("Mensaje", "Elimino correctamente", "OK");
                lblCodigo.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "OK");
            }
        }

        private void btnVuelva_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}