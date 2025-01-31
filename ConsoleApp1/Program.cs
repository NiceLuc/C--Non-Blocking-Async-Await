Console.WriteLine("Started...");

// notice use of "await" keyword here
var didCall = await FireAndForgetAsync();

Console.WriteLine($"Finished! (Background Thread: {didCall})");

// let the program run for a while to see the results of the background thread results...
await Task.Delay(5000);

Console.WriteLine("Done!");

/* ************************************************************************************************ */

Task<bool> FireAndForgetAsync()
{
    // I am the "caller" and I don't care if/when the content is delivered
    Task.Run(LongRunningTaskAsync);

    return Task.FromResult(true);
}

async Task LongRunningTaskAsync()
{
    // I am a long-running task and I take time to finish
    await Task.Delay(1000); 

    Console.WriteLine("Getting content...");
    var client = new HttpClient();
    var response = await client.GetAsync("https://www.microsoft.com");
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Got content: " + content);
}
