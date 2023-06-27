using Banco.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banco
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        private const string url = "http://172.29.96.1:8000/cuentas";
        private readonly HttpClient client = new HttpClient();
        public int idCliente = -1;
        public Inicio()
        {
            InitializeComponent();
            Get();
        }
        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(url);
                List<datosInicio> post = JsonConvert.DeserializeObject<List<datosInicio>>(content);
                nombreCliente.Text = post[0].nombre.ToString();
                monto.Text = post[0].monto.ToString()+ " $";
                idCuenta.Text = "Nro! " + post[0].idCuenta.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

}