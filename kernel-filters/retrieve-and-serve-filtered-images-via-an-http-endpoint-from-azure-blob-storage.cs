using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Azure Blob URL of the source image
            string blobUrl = "https://example.blob.core.windows.net/container/sample.webp";

            // Output file path
            string outputPath = Path.Combine("Output", "filtered.webp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download image from Azure Blob Storage
            byte[] imageData;
            using (var httpClient = new HttpClient())
            {
                imageData = httpClient.GetByteArrayAsync(blobUrl).Result;
            }

            // Load image from memory, apply grayscale filter, and save to output file
            using (var inputStream = new MemoryStream(imageData))
            using (RasterImage raster = (RasterImage)Image.Load(inputStream))
            {
                raster.Grayscale();

                using (var outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    var options = new WebPOptions();
                    raster.Save(outStream, options);
                }
            }

            // Start simple HTTP server to serve the filtered image
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:8080/ ...");

            while (true)
            {
                var context = listener.GetContext();
                var response = context.Response;

                using (var fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
                {
                    response.ContentLength64 = fileStream.Length;
                    response.ContentType = "image/webp";
                    fileStream.CopyTo(response.OutputStream);
                }

                response.OutputStream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}