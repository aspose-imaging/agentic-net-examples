using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\vector.svg";
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
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
 * 1. When a developer needs to convert brand SVG logos to PNG thumbnails with a 180‑degree hue shift for a night‑mode UI theme.
 * 2. When an e‑commerce platform must generate product image variants that use a complementary color scheme by rotating the hue of vector illustrations before saving them as PNGs.
 * 3. When a game developer wants to programmatically recolor SVG sprites for different player teams and export the results as PNG assets using C# and Aspose.Imaging.
 * 4. When a marketing automation script has to create color‑shifted PNG banners from SVG templates to match seasonal campaign palettes.
 * 5. When a reporting tool must render SVG charts with an inverted hue for accessibility compliance and save them as PNG files for inclusion in PDF reports.
 */