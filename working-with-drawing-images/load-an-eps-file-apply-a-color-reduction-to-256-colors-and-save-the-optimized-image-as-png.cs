using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.eps";
            string outputPath = "output\\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for 256‑color indexed palette
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    // Generate a palette that best fits the image (256 colors)
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(
                        (RasterImage)image,
                        256,
                        PaletteMiningMethod.Histogram)
                };

                // Save the optimized PNG
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
 * 1. When a web application needs to display legacy EPS vector graphics as lightweight PNG thumbnails with a limited 256‑color palette for faster page loads.
 * 2. When an e‑commerce platform converts vendor‑provided EPS logos into PNG icons that must meet a 256‑color limit to comply with a mobile app’s image size constraints.
 * 3. When a document‑management system archives EPS drawings by generating PNG previews that use indexed color to reduce storage space while preserving visual fidelity.
 * 4. When a batch‑processing tool prepares EPS artwork for printing on low‑resolution devices by reducing the color depth to 256 colors and saving it as PNG for compatibility.
 * 5. When a content‑delivery network optimizes EPS files for email newsletters by converting them to 256‑color PNGs to ensure consistent rendering across email clients.
 */