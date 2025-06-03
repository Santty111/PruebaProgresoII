using System.Net.Http.Json;

namespace PruebaProgresoII;

public partial class ChistesPage : ContentPage
{
	public ChistesPage()
	{
		InitializeComponent();
        LoadJoke();
    }

    private async void LoadJoke()
    {
        try
        {
            var httpClient = new HttpClient();
            var joke = await httpClient.GetFromJsonAsync<Joke>("https://official-joke-api.appspot.com/random_joke");
            JokeLabel.Text = $"{joke.Setup}\n{joke.Punchline}";
        }
        catch
        {
            JokeLabel.Text = "Error al obtener el chiste.";
        }
    }

    private void Button_ClickedChiste(object sender, EventArgs e)
    {
        LoadJoke();
    }
}

public class Joke
{
    public string Setup { get; set; }
    public string Punchline { get; set; }
}
