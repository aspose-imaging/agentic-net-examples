using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));
                raster.Save(outputPath, new PngOptions());
            }

            // Upload to Azure Blob Storage (filtered container) using a SAS URL
            string sasUrl = "https://<account>.blob.core.windows.net/filtered/filtered_image.png?<sas-token>";

            using (var httpClient = new HttpClient())
            using (FileStream fileStream = File.OpenRead(outputPath))
            using (var content = new StreamContent(fileStream))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                var response = httpClient.PutAsync(sasUrl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"Upload failed: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}