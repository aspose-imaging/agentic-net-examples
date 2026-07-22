using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths and URLs
            string inputUrl = "https://example.com/input.svg";
            string uploadUrl = "https://example.com/upload";
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "blurred.png";

            // Download SVG from REST API
            using (HttpClient httpClient = new HttpClient())
            {
                byte[] svgData = httpClient.GetByteArrayAsync(inputUrl).Result;
                File.WriteAllBytes(inputPath, svgData);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Verify rasterized PNG exists
            if (!File.Exists(tempPngPath))
            {
                Console.Error.WriteLine($"File not found: {tempPngPath}");
                return;
            }

            // Load raster image and apply Gaussian blur
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImage;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath);
            }

            // Verify blurred image exists
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Post blurred image back to REST API
            using (HttpClient httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileBytes = File.ReadAllBytes(outputPath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    content.Add(fileContent, "file", Path.GetFileName(outputPath));
                    var response = httpClient.PostAsync(uploadUrl, content).Result;
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
 * 1. When a web service needs to fetch user‑generated SVG icons from a REST endpoint, apply a Gaussian blur for a soft‑shadow effect, and send the blurred PNG back for display in a mobile app.
 * 2. When an e‑commerce platform automatically retrieves product vector graphics via an API, rasterizes them to PNG, blurs the background to create promotional banners, and uploads the result to the content‑delivery network.
 * 3. When a marketing automation tool pulls SVG logos from a cloud API, uses Aspose.Imaging in C# to add a subtle blur for watermarking, and posts the processed PNG to the same API for archival.
 * 4. When a SaaS reporting dashboard downloads SVG charts from a microservice, applies a Gaussian blur to de‑emphasize old data layers, and returns the blurred PNG for inclusion in PDF reports.
 * 5. When a digital signage system retrieves SVG advertisements from a REST API, blurs the edges to match a background theme, and uploads the final PNG back to the server for scheduled playback.
 */