using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\drawing.svg";
        string outputPath = "output\\drawing_16bit.png";

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

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with 16‑bit depth
                var pngOptions = new PngOptions
                {
                    BitDepth = 16,
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
                };

                // Configure vector rasterization (anti‑aliasing)
                var rasterOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Set page size if the source is a vector image
                if (image is VectorImage vectorImage)
                {
                    rasterOptions.PageSize = vectorImage.Size;
                }

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as high‑quality PNG
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
 * 1. When a web application needs to convert user‑uploaded SVG logos into high‑quality 16‑bit PNG thumbnails with smooth edges for retina displays, a developer can use this code.
 * 2. When a desktop publishing tool must export vector illustrations as lossless PNG files with anti‑aliased text and graphics for print‑ready PDFs, this snippet provides the needed rasterization.
 * 3. When an automated build pipeline generates asset bundles and must transform SVG icons into 16‑bit true‑color PNGs with consistent white backgrounds for game UI assets, the code handles the conversion.
 * 4. When a scientific visualization system requires rendering vector charts as high‑depth PNG images to preserve color fidelity while applying anti‑aliasing for publication‑grade figures, this example shows how to achieve it.
 * 5. When a document management service needs to preview vector drawings by rasterizing them into 16‑bit PNG previews with smooth rendering for fast client‑side display, the provided C# code performs the task.
 */