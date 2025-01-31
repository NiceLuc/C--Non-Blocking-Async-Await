var client = new HttpClient();
var response = await client.GetAsync("https://www.microsoft.com");
var pageContents = await response.Content.ReadAsStringAsync();
Console.WriteLine(pageContents);
