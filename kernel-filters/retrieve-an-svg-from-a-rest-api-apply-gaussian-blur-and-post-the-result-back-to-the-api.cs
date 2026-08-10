// HOW-TO: Download SVG From API, Apply Gaussian Blur, and Upload PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "downloaded.svg";
            string tempPngPath = "temp.png";
            string outputPath = "blurred.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download SVG from REST API
            using (var httpClient = new HttpClient())
            {
                var downloadResponse = httpClient.GetAsync("https://example.com/api/svg").Result;
                if (!downloadResponse.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"Failed to download SVG: {downloadResponse.StatusCode}");
                    return;
                }

                var svgBytes = downloadResponse.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(inputPath, svgBytes);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load SVG and rasterize to PNG
            using (Image svgImg = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)svgImg;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG, apply Gaussian blur, and save result
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImg;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                raster.Save(outputPath);
            }

            // Post the blurred image back to the API
            using (var httpClient = new HttpClient())
            {
                var content = new ByteArrayContent(File.ReadAllBytes(outputPath));
                var uploadResponse = httpClient.PostAsync("https://example.com/api/upload", content).Result;
                if (!uploadResponse.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"Failed to upload image: {uploadResponse.StatusCode}");
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
 * 1. When you need to fetch vector graphics from a web service, rasterize them, and add a soft blur before storing them as PNG files.
 * 2. When an e‑commerce platform wants to generate blurred product thumbnails on the fly by retrieving SVG logos via REST and returning blurred PNGs.
 * 3. When a reporting tool requires blurred background images for PDFs and must download SVG assets, apply Gaussian blur, and upload the processed PNGs to the same API.
 * 4. When a mobile app backend processes user‑submitted SVG icons, adds a Gaussian blur for privacy, and sends the blurred PNG back to the server.
 * 5. When an automated CI pipeline validates image processing by downloading SVG assets, applying a blur filter, and posting the resulting PNG to a test endpoint.
 */
