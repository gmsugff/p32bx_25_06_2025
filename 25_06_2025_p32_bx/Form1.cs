using System.Text.Json;

namespace _25_06_2025_p32_bx
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            checkedListBoxSearchEngines.Items.AddRange(new string[] { "DuckDuckGo", "Bing", "Google" });
            radioButtonTextSearch.Checked = true;

            buttonSearch.Click += ButtonSearch_Click;
        }
        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            string query = textBoxQuery.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Введите поисковый запрос.");
                return;
            }

            var selectedEngines = checkedListBoxSearchEngines.CheckedItems.Cast<string>().ToList();
            if (selectedEngines.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну поисковую систему.");
                return;
            }

            tabControlResults.TabPages.Clear();

            bool isTextSearch = radioButtonTextSearch.Checked;

            
            var tasks = selectedEngines.Select(engine => SearchAndDisplayAsync(engine, query, isTextSearch));
            await Task.WhenAll(tasks);
        }

        private async Task SearchAndDisplayAsync(string engine, string query, bool isTextSearch)
        {
            var tabPage = new TabPage(engine);
            if (isTextSearch)
            {
                var listBox = new ListBox { Dock = DockStyle.Fill };
                tabPage.Controls.Add(listBox);

                List<string> results = engine switch
                {
                    "DuckDuckGo" => await SearchDuckDuckGoTextAsync(query),
                    "Bing" => await SearchBingTextAsync(query), 
                    "Google" => await SearchGoogleTextAsync(query), 
                    _ => new List<string> { "Поисковая система не поддерживается." }
                };

                foreach (var item in results)
                    listBox.Items.Add(item);
            }
            else
            {
                var flowPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
                tabPage.Controls.Add(flowPanel);

                List<string> imageUrls = engine switch
                {
                    "DuckDuckGo" => await SearchDuckDuckGoImagesAsync(query),
                    "Bing" => await SearchBingImagesAsync(query), 
                    "Google" => await SearchGoogleImagesAsync(query), 
                    _ => new List<string>()
                };

                foreach (var url in imageUrls)
                {
                    var pictureBox = new PictureBox
                    {
                        Width = 120,
                        Height = 120,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Padding = new Padding(5)
                    };

                    try
                    {
                        var bytes = await httpClient.GetByteArrayAsync(url);
                        using var ms = new System.IO.MemoryStream(bytes);
                        pictureBox.Image = Image.FromStream(ms);
                    }
                    catch
                    {
                        
                    }

                    flowPanel.Controls.Add(pictureBox);
                }
            }

           
            Invoke(() => tabControlResults.TabPages.Add(tabPage));
        }

        
        private async Task<List<string>> SearchDuckDuckGoTextAsync(string query)
        {
            var results = new List<string>();
            string url = $"https://api.duckduckgo.com/?q={Uri.EscapeDataString(query)}&format=json&no_redirect=1&no_html=1";

            try
            {
                string json = await httpClient.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                
                if (root.TryGetProperty("RelatedTopics", out var relatedTopics))
                {
                    foreach (var item in relatedTopics.EnumerateArray())
                    {
                        if (item.TryGetProperty("Text", out var text))
                            results.Add(text.GetString());
                    }
                }

                
                if (results.Count == 0 && root.TryGetProperty("AbstractText", out var abstractText))
                {
                    var abs = abstractText.GetString();
                    if (!string.IsNullOrEmpty(abs))
                        results.Add(abs);
                }
            }
            catch
            {
                results.Add("Ошибка при поиске в DuckDuckGo.");
            }

            return results;
        }

        
        private async Task<List<string>> SearchDuckDuckGoImagesAsync(string query)
        {
            var imageUrls = new List<string>();
            try
            {
                
                string tokenUrl = $"https://duckduckgo.com/?q={Uri.EscapeDataString(query)}&iax=images&ia=images";
                string html = await httpClient.GetStringAsync(tokenUrl);

                var token = ExtractVqdToken(html);
                if (token == null)
                    return imageUrls;

                string requestUrl = $"https://duckduckgo.com/i.js?l=us-en&o=json&q={Uri.EscapeDataString(query)}&vqd={token}";

                string json = await httpClient.GetStringAsync(requestUrl);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("results", out var results))
                {
                    foreach (var item in results.EnumerateArray())
                    {
                        if (item.TryGetProperty("image", out var image))
                            imageUrls.Add(image.GetString());
                    }
                }
            }
            catch
            {
                
            }

            return imageUrls;
        }

        
        private string ExtractVqdToken(string html)
        {
            
            var marker = "vqd='";
            int idx = html.IndexOf(marker);
            if (idx < 0) return null;
            int start = idx + marker.Length;
            int end = html.IndexOf("'", start);
            if (end < 0) return null;
            return html.Substring(start, end - start);
        }

        
        private Task<List<string>> SearchBingTextAsync(string query)
        {
            return Task.FromResult(new List<string> { "Bing Search API требует ключ." });
        }

        private Task<List<string>> SearchGoogleTextAsync(string query)
        {
            return Task.FromResult(new List<string> { "Google Custom Search API требует ключ." });
        }

        private Task<List<string>> SearchBingImagesAsync(string query)
        {
            return Task.FromResult(new List<string>());
        }

        private Task<List<string>> SearchGoogleImagesAsync(string query)
        {
            return Task.FromResult(new List<string>());
        }
    }













}
