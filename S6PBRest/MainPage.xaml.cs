using Newtonsoft.Json;
using S6PBRest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace S6PBRest
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.9/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<S6PBRest.Model.PersonaModel> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<S6PBRest.Model.PersonaModel> posts = JsonConvert.DeserializeObject<List<S6PBRest.Model.PersonaModel>>(content);
                _post = new ObservableCollection<S6PBRest.Model.PersonaModel>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewInsertar()); 
        }
        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
         
        }

        private async void btnPut_Clicked(object sender, EventArgs e)
        {
            PersonaModel c = MyListView.SelectedItem as PersonaModel;
            int codigo = c.codigo;
            string nombre = c.nombre;
            string apellido = c.apellido;
            int edad = c.edad;
            await Navigation.PushAsync(new viewActualizar(codigo, nombre, apellido, edad));
        }

        private async void btnElimine_Clicked(object sender, EventArgs e)
        {
            PersonaModel c = MyListView.SelectedItem as PersonaModel;
            int codigo = c.codigo;
            await Navigation.PushAsync(new viewEliminar(codigo));
        }
    }
}
