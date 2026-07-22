// HOW-TO: Apply Emboss Convolution to Indexed PNG While Preserving Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            // Load the image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply a convolution kernel (Emboss3x3) to the raster image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Prepare PNG save options with indexed color and a palette that matches the processed image
                PngOptions saveOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(raster, 256, Aspose.Imaging.PaletteMiningMethod.Histogram)
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
 * 1. When you need to add an emboss effect to a small‑size PNG sprite sheet without losing its indexed color palette.
 * 2. When you must process a game asset PNG with a convolution kernel and keep the original 256‑color palette for memory‑constrained devices.
 * 3. When you want to apply a custom filter to a PNG icon set while ensuring the saved file remains indexed for fast web loading.
 * 4. When you are generating stylized thumbnails from indexed PNGs and require the output to retain exact palette mapping for consistent colors.
 * 5. When you are automating batch image processing of indexed PNG maps and need each filtered image saved with a matching palette to avoid color distortion.
 */
