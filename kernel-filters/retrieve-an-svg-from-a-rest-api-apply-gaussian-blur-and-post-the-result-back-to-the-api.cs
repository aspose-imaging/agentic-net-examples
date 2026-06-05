using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths and URLs
        string inputUrl = "https://example.com/api/input.svg";
        string downloadPath = "downloaded.svg";
        string tempPngPath = "temp.png";
        string outputPath = "blurred.png";
        string postUrl = "https://example.com/api/upload";

        try
        {
            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download SVG from REST API
            using (HttpClient httpClient = new HttpClient())
            {
                byte[] svgData = httpClient.GetByteArrayAsync(inputUrl).Result;
                File.WriteAllBytes(downloadPath, svgData);
            }

            // Verify download succeeded
            if (!File.Exists(downloadPath))
            {
                Console.Error.WriteLine($"File not found: {downloadPath}");
                return;
            }

            // Load SVG and rasterize to PNG
            using (Image svgImage = Image.Load(downloadPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Verify rasterized PNG exists
            if (!File.Exists(tempPngPath))
            {
                Console.Error.WriteLine($"File not found: {tempPngPath}");
                return;
            }

            // Load raster PNG, apply Gaussian blur, and save result
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImage;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath);
            }

            // Verify output exists
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Post the blurred image back to the API
            using (HttpClient httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileBytes = File.ReadAllBytes(outputPath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                    content.Add(fileContent, "file", Path.GetFileName(outputPath));

                    var response = httpClient.PostAsync(postUrl, content).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.Error.WriteLine($"Upload failed: {response.StatusCode}");
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

/*
 * Real-World Use Cases:
 * 1. When a web service needs to fetch a vector logo in SVG format, apply a soft Gaussian blur for a hover effect, and send the blurred PNG back to the API for storage.
 * 2. When an e‑commerce platform wants to automatically generate blurred preview images of user‑uploaded SVG product designs by downloading them via a REST endpoint, rasterizing to PNG, applying blur, and posting the result.
 * 3. When a marketing automation tool must retrieve SVG banners from a content API, apply a Gaussian blur to create background images, and upload the processed PNGs to the same API for later use in email campaigns.
 * 4. When a mobile app backend processes SVG icons from a remote service, converts them to raster PNGs, adds a blur filter for UI consistency, and returns the modified images through a POST request.
 * 5. When a document generation system pulls SVG diagrams from a REST API, softens them with a Gaussian blur to meet branding guidelines, and posts the blurred PNGs back to the API for inclusion in generated PDFs.
 */