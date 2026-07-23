using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.gif";

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
                // Configure rasterization options with smoothing (anti‑aliasing)
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size
                    PageSize = svgImage.Size,
                    // Enable anti‑aliasing for smoother rendering
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Optional: improve text rendering quality
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                // Configure GIF save options
                GifOptions gifOptions = new GifOptions
                {
                    // Enable palette correction for better color fidelity
                    DoPaletteCorrection = true,
                    // Optional: make the GIF interlaced
                    Interlaced = true,
                    // Attach the rasterization options
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the SVG as a GIF with the specified options
                svgImage.Save(outputPath, gifOptions);
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
 * 1. When converting vector‑based SVG icons into animated GIFs for web banners, a developer can use this code to apply anti‑aliasing and produce smooth, non‑pixelated animations.
 * 2. When generating product‑demo GIFs from SVG diagrams in a C# reporting tool, the smoothing mode ensures the rendered frames retain crisp edges and readable text.
 * 3. When creating low‑resolution GIF thumbnails of SVG illustrations for mobile apps, enabling SmoothingMode.AntiAlias prevents jagged edges during rasterization.
 * 4. When automating batch conversion of SVG logos to animated GIFs for email newsletters, the code’s smoothing and palette correction keep colors accurate and animation fluid.
 * 5. When building a server‑side image service that serves GIF previews of user‑uploaded SVG artwork, applying anti‑aliasing guarantees the preview looks professional across browsers.
 */