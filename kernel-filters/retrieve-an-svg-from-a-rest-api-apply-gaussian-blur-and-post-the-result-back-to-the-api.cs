using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded URLs and file paths
            string inputUrl = "https://example.com/input.svg";
            string tempInputPath = "temp_input.svg";
            string tempRasterPath = "temp_raster.png";
            string outputPath = "output.png";

            // Download SVG from REST API
            var httpClient = new System.Net.Http.HttpClient();
            var svgBytes = httpClient.GetByteArrayAsync(inputUrl).Result;
            File.WriteAllBytes(tempInputPath, svgBytes);

            // Verify input file exists
            if (!File.Exists(tempInputPath))
            {
                Console.Error.WriteLine($"File not found: {tempInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to PNG
            using (Image image = Image.Load(tempInputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempRasterPath, pngOptions);
            }

            // Verify rasterized PNG exists
            if (!File.Exists(tempRasterPath))
            {
                Console.Error.WriteLine($"File not found: {tempRasterPath}");
                return;
            }

            // Load raster PNG, apply Gaussian blur, and save final output
            using (Image rasterImageContainer = Image.Load(tempRasterPath))
            {
                var rasterImage = (RasterImage)rasterImageContainer;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                rasterImage.Save(outputPath);
            }

            // Post the processed image back to the API
            var resultBytes = File.ReadAllBytes(outputPath);
            var content = new System.Net.Http.ByteArrayContent(resultBytes);
            var postResponse = httpClient.PostAsync("https://example.com/upload", content).Result;
            if (!postResponse.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Failed to upload: {postResponse.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}