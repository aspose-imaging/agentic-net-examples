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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG options with 256‑color indexed palette
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    // Generate a palette of 256 colors using histogram method
                    Palette = ColorPaletteHelper.GetCloseImagePalette((RasterImage)image, 256, PaletteMiningMethod.Histogram)
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
 * 1. When a developer needs to convert vector EPS artwork into a web‑friendly PNG with a 256‑color indexed palette to reduce file size for faster page loads.
 * 2. When an e‑commerce platform must generate thumbnail previews of EPS product logos and limit colors to 256 to meet CDN bandwidth constraints.
 * 3. When a print‑to‑screen workflow requires extracting raster data from an EPS file, applying histogram‑based color reduction, and saving the result as a PNG for archival.
 * 4. When a mobile app processes user‑uploaded EPS files and needs to output a low‑color PNG that complies with the device’s memory limits.
 * 5. When a batch‑processing script automates the conversion of legacy EPS graphics to optimized PNG images using C# and Aspose.Imaging for consistent color depth across a digital asset library.
 */