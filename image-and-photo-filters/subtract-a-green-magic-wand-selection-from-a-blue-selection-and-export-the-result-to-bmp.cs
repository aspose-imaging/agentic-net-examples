using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\result.bmp";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask for the blue selection (example coordinates and threshold)
                ImageBitMask blueMask = MagicWandTool.Select(
                    image,
                    new MagicWandSettings(100, 100) { Threshold = 50 });

                // Create a mask for the green selection (example coordinates and threshold)
                ImageBitMask greenMask = MagicWandTool.Select(
                    image,
                    new MagicWandSettings(200, 200) { Threshold = 50 });

                // Subtract the green mask from the blue mask
                ImageBitMask resultMask = blueMask.Subtract(greenMask);

                // Apply the resulting mask to the image
                resultMask.Apply();

                // Save the processed image as BMP
                image.Save(outputPath, new BmpOptions());
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
 * 1. When creating a product catalog where the blue background must be kept but any overlapping green branding needs to be removed before saving the final image as a BMP for high‑resolution printing.
 * 2. When preprocessing satellite imagery to isolate water bodies (blue) while excluding vegetation (green) and exporting the cleaned raster to BMP for integration with GIS tools.
 * 3. When generating game assets that require a blue texture mask with green highlights removed, using C# Magic Wand selection and saving the result as a BMP for the engine’s texture pipeline.
 * 4. When preparing medical scans where a blue contrast agent is highlighted but green artifacts must be subtracted, and the cleaned image is saved as BMP for archival compliance.
 * 5. When automating the creation of marketing banners that keep a blue call‑to‑action area while eliminating green overlay elements, using Aspose.Imaging’s Magic Wand tool and exporting the final design to BMP for legacy systems.
 */