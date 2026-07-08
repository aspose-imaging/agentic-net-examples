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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.png";

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
                SvgImage svgImage = (SvgImage)image;

                // Configure rasterization options to match SVG size
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Set PNG save options with consistent DPI
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // Desired DPI
                };

                // Save rasterized PNG
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When generating print‑ready product catalogs, a developer can load vector SVG logos and rasterize them to PNG at 300 DPI to match the document’s resolution.
 * 2. When creating thumbnails for a web gallery that must appear at a uniform size on high‑resolution displays, the code aligns the SVG’s page size and sets a consistent DPI before saving as PNG.
 * 3. When converting SVG icons for inclusion in a PDF report, a developer uses this approach to ensure the rasterized PNGs retain the same DPI as other embedded images.
 * 4. When automating batch processing of SVG diagrams for a scientific publication, the code guarantees each diagram is rasterized with identical resolution settings for accurate scaling.
 * 5. When preparing assets for a mobile app that requires PNG images at a specific DPI for consistent rendering across devices, the developer aligns the SVG resolution before rasterization.
 */