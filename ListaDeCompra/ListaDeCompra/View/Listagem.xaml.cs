using ListaDeCompra.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeCompra.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagem : ContentPage
    {
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();

        public Listagem()
        {
            InitializeComponent();

            lst_produtos.ItemsSource = lista_produtos;
        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            double soma = lista_produtos.Sum(i => i.Precototal);

            DisplayAlert("Total é: ", soma.ToString("C"), "OK");
        }

        private void ToolbarItem_Clicked_Add(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new Formulario());
        }

        protected override void OnAppearing()
        {
            if(lista_produtos.Count == 0)
            {
                Task.Run(async () =>
                {
                    List<Produto> temp = await App.Db.getAll();

                    foreach (Produto p in temp)
                    {
                        lista_produtos.Add(p);
                    }
                });
            }
        }
    }
}