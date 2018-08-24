using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PokedexNET;

namespace Poke
{
	public partial class MainPage : ContentPage
	{
        private PokedexNET.Pokedex _pokedex;
        private Pokemon _pokemon;
		public MainPage()
		{
			InitializeComponent();
            _pokedex = new Pokedex();
		}

        private void btnFind_Clicked(object sender, EventArgs e)
        {
            var text = txtNumber.Text;
            if (int.TryParse(text, out int number))
            {
                _pokemon = _pokedex.GetPokemon(number);
                txtName.Text = _pokemon.Name;
                imgImage.Source = ImageSource.FromUri(new Uri(_pokemon.ImageUrl));
            }
        }

        private void btnView_Clicked(object sender, EventArgs e)
        {
            if(_pokemon != null)
            {
                Navigation.PushAsync(new DetailPage(_pokemon));

            }
        }
    }
}
