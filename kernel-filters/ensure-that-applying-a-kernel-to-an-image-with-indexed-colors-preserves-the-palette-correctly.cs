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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the indexed PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 sharpening kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1,  0 },
                    { -1, 5, -1 },
                    { 0, -1,  0 }
                };

                // Apply the convolution kernel
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Re‑generate a palette that matches the processed image
                var palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(
                    raster, 256, Aspose.Imaging.PaletteMiningMethod.Histogram);

                // Prepare PNG save options with indexed color and the new palette
                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = palette,
                    CompressionLevel = 9
                };

                // Save the processed image preserving the palette
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to sharpen a legacy 8‑bit PNG sprite sheet for a game while keeping the original 256‑color palette intact.
 * 2. When an e‑commerce platform wants to enhance product thumbnail images stored as indexed PNGs without increasing file size, requiring palette regeneration after convolution.
 * 3. When a medical imaging system processes indexed PNG scans to improve edge definition and must preserve the exact palette for accurate color‑coded annotations.
 * 4. When a content management system batch‑updates archived infographic PNGs with a custom filter and needs to maintain compatibility with older browsers that only support indexed colors.
 * 5. When a printing workflow applies a sharpening filter to indexed PNG artwork before rasterizing, ensuring the final PDF uses the same palette to avoid color shifts.
 */