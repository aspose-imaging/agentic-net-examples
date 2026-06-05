using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input URL and output file path
            string inputUrl = "https://example.com/sample.emf";
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Download EMF image from the network stream
            using (var httpClient = new System.Net.Http.HttpClient())
            using (var inputStream = httpClient.GetStreamAsync(inputUrl).Result)
            // Load the EMF image from the stream
            using (Image image = Image.Load(inputStream))
            {
                // Set PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the image directly to the output stream (file)
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
                {
                    image.Save(outputStream, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}