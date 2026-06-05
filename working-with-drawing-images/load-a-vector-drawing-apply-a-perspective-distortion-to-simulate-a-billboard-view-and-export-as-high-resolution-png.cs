using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageSize = new Size(vectorImage.Width * 2, vectorImage.Height * 2),
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = rasterOptions
                };

                vectorImage.Save(outputPath, pngOptions);
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
 * 1. When a marketing application needs to convert an SVG logo into a high‑resolution PNG billboard mockup with perspective distortion for client presentations.
 * 2. When an e‑commerce platform automatically generates printable product labels from vector artwork, scaling the SVG and rendering it as a crisp PNG for large‑format printers.
 * 3. When a digital signage system pre‑processes SVG icons into billboard‑style PNG assets at double the original size to ensure sharpness on high‑DPI displays.
 * 4. When a web service provides on‑the‑fly conversion of user‑uploaded SVG illustrations into PNG thumbnails with a simulated viewing angle for preview galleries.
 * 5. When a desktop publishing tool rasterizes vector diagrams into white‑background PNG files at higher resolution to embed them in PDF brochures without losing quality.
 */