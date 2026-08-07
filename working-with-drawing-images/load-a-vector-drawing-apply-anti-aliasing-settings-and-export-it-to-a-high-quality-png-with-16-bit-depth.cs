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
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with anti-aliasing
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Configure PNG options with 16-bit depth
                PngOptions pngOptions = new PngOptions
                {
                    BitDepth = 16,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized PNG
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
 * 1. When a developer needs to convert an SVG logo into a high‑resolution PNG for print media while preserving smooth edges with anti‑aliasing and 16‑bit color depth using Aspose.Imaging for .NET.
 * 2. When a web application must generate retina‑ready PNG thumbnails from vector illustrations on the fly, ensuring crisp rendering by applying SmoothingMode.AntiAlias and TextRenderingHint.AntiAlias.
 * 3. When a desktop tool has to batch‑process SVG icons into 16‑bit PNG assets for a UI theme, requiring precise color depth control and vector rasterization options in C#.
 * 4. When an e‑learning platform wants to embed scalable diagrams as PNG images with accurate color fidelity and anti‑aliased text for PDF export, using Aspose.Imaging’s SvgRasterizationOptions.
 * 5. When a GIS system needs to render complex SVG maps as high‑quality PNG layers with 16‑bit depth to maintain gradient detail and smooth lines before overlaying them on satellite imagery.
 */