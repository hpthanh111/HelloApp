using PokedexNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poke
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        Pokemon _pokemon;

		public DetailPage (Pokemon pokemon)
		{
			InitializeComponent ();

            _pokemon = pokemon;

            var pokedex = new Pokedex();
            var info = pokedex.GetPokemonInfo(pokemon);

            txtName.Text = info.Names.En;
            txtDesc.Text = info.PokedexEntries.OmegaRuby.En;
            txtWeight.Text = info.WeightEu;
            txtHeight.Text = info.HeightEu;
            imgImage.Source = ImageSource.FromUri(new Uri(pokemon.ImageUrl));

		}

        private void btnOpenWeb_Clicked(object sender, EventArgs e)
        {
            var url = "http://www.pokemon.com/us/pokedex/" + _pokemon.Slug;
            Device.OpenUri(new Uri(url));

        }
    }
}