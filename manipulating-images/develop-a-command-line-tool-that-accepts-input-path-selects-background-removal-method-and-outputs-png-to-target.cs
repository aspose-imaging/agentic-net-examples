// HOW-TO: Remove Background From Vector PNG And Save As Transparent PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the image (vector or raster)
            using (Image image = Image.Load(inputPath))
            {
                // If the image is a vector image, remove its background
                if (image is VectorImage vectorImg)
                {
                    // Use the parameterless overload for default background removal
                    vectorImg.RemoveBackground();
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the processed image as PNG
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
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
 * 1. When you need to automatically strip the background from SVG or EPS files and output a transparent PNG for web thumbnails.
 * 2. When a desktop application must convert user‑uploaded vector graphics to PNG with an alpha channel without manual editing.
 * 3. When a build pipeline requires a lightweight command‑line utility to prepare assets by removing backgrounds before packaging.
 * 4. When an e‑commerce platform wants to generate product images with clean transparent backgrounds from supplier vector files.
 * 5. When a reporting service needs to ensure all exported charts are saved as PNGs with preserved transparency for PDF embedding.
 */
