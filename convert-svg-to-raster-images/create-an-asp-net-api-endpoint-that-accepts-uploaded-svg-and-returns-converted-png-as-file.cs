using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to let users upload vector SVG logos and instantly provide a raster PNG version for display on browsers that only support bitmap images.
 * 2. When an e‑commerce platform must convert product illustration SVG files to PNG thumbnails on the fly via an ASP.NET API endpoint.
 * 3. When a content management system requires automated processing of designer‑submitted SVG assets into PNG assets for email newsletters and social media sharing.
 * 4. When a reporting service generates charts as SVG and needs to embed them as PNG images in PDF reports using C# and Aspose.Imaging.
 * 5. When a mobile backend service accepts SVG icons from client apps and returns optimized PNG files to reduce bandwidth and ensure compatibility with older devices.
 */