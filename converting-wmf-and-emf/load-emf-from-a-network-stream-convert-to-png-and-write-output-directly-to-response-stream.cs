using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input URL and output path
            string inputUrl = "https://example.com/sample.emf";
            string outputPath = "output.png";

            // Validate input URL by attempting to download (no file existence check for URLs)
            // Validate output path directory
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Download EMF image from network stream
            using (HttpClient httpClient = new HttpClient())
            using (Stream networkStream = httpClient.GetStreamAsync(inputUrl).Result)
            using (Image image = Image.Load(networkStream))
            {
                // Prepare PNG options with vector rasterization for EMF
                PngOptions pngOptions = new PngOptions();
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Simulate response stream (replace with actual response stream in real scenario)
                using (Stream responseStream = new MemoryStream())
                {
                    // Save PNG to response stream
                    image.Save(responseStream, pngOptions);

                    // For demonstration, also write the stream to a file
                    responseStream.Position = 0;
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}