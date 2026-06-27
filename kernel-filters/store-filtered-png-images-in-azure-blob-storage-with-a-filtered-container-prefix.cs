using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output_filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                PngOptions pngOptions = new PngOptions
                {
                    FilterType = PngFilterType.Adaptive
                };

                raster.Save(outputPath, pngOptions);
            }

            string blobUrl = "https://<account>.blob.core.windows.net/filtered/output_filtered.png?<sas-token>";

            using (HttpClient httpClient = new HttpClient())
            using (FileStream fileStream = File.OpenRead(outputPath))
            {
                HttpContent content = new StreamContent(fileStream);
                HttpResponseMessage response = httpClient.PutAsync(blobUrl, content).Result;
                Console.WriteLine($"Upload response: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to apply a Gaussian blur filter to a PNG image and store the filtered result in an Azure Blob Storage container with a “filtered” prefix for later retrieval by a web app.
 * 2. When an e‑commerce platform wants to generate blurred product thumbnails on the fly, save them as adaptive‑filtered PNG files, and upload them to a secure Azure Blob endpoint for CDN distribution.
 * 3. When a medical imaging system must anonymize patient scans by blurring sensitive regions, convert the output to PNG with adaptive filtering, and archive the files in a “filtered” Azure Blob container for compliance audits.
 * 4. When a content moderation tool processes user‑uploaded PNGs, applies a Gaussian blur to hide inappropriate details, and stores the sanitized images in Azure Blob Storage using a SAS‑secured URL for downstream analysis.
 * 5. When a mobile game backend needs to pre‑process PNG assets with a blur effect, save them with optimal PNG filter settings, and push the assets to an Azure Blob storage folder named “filtered” for dynamic loading by the game client.
 */