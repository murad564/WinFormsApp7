using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveApp.Forms
{
    public partial class MainForm : Form
    {
        const string _apiKey = " a95caf75";
        const string _url = $"http://www.omdbapi.com/?apikey={_apiKey}";
        public MainForm()
        {
            InitializeComponent();
        }

        private async Task btn_search_ClickAsync(object sender, EventArgs e)
        {
            string search = $"{_url}&t={txt_search.Text}";

            using HttpClient client = new();
            string jsonStr = await client.GetStringAsync(search);

            var movie = JsonSerializer.Deserialize<Movie>(jsonStr);
            pictureBox1.LoadAsync(movie?.Poster);
        }
    }
}
