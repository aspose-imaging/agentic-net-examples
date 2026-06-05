using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
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

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG options with indexed color (256‑color palette)
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    // Generate a palette that best fits the image using histogram method
                    Palette = ColorPaletteHelper.GetCloseImagePalette(
                        (RasterImage)image,          // Cast to RasterImage for palette extraction
                        256,                         // Desired number of colors
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
 * 1. When a web application must display vector‑based EPS logos on browsers that only support PNG, a developer can load the EPS, reduce it to a 256‑color palette, and save it as an optimized PNG for fast loading.
 * 2. When generating printable product catalogs, a developer can convert high‑resolution EPS artwork to a 256‑color PNG to meet the printer’s limited color gamut while keeping file sizes small.
 * 3. When building a mobile app that caches promotional graphics, a developer can use this code to transform EPS files into indexed‑color PNGs, ensuring low memory usage on devices.
 * 4. When automating the archival of design assets, a developer can standardize all EPS files by converting them to 256‑color PNGs for consistent storage and easy preview in file browsers.
 * 5. When creating email newsletters that embed images, a developer can convert EPS illustrations to 256‑color PNGs to comply with email client size restrictions and maintain visual fidelity.
 */