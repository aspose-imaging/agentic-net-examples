using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

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

            // Load the raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create MagicWandSettings with a point inside the target region and a custom threshold of 30
                var settings = new MagicWandSettings(50, 50) { Threshold = 30 };

                // Apply the magic wand selection and mask to the image
                MagicWandTool
                    .Select(image, settings)
                    .Apply();

                // Save the processed image
                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
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
 * 1. When a developer needs to automatically remove a solid‑color background from a PNG product photo by selecting a pixel inside the background and using a custom threshold of 30 to create a precise mask.
 * 2. When building an image‑editing tool that lets users click on a region of a JPEG or PNG and instantly isolate that area for further processing, such as applying filters or exporting a cut‑out.
 * 3. When generating transparent overlays for a web‑ready PNG sprite sheet, the code can select a specific color region with a tolerance of 30 and convert it to an alpha mask.
 * 4. When preprocessing scanned documents in C# to extract a logo or stamp by selecting a point inside the logo’s color and using the magic wand threshold to create a clean selection for OCR.
 * 5. When creating automated batch scripts that need to mask out watermarks or signatures from PNG images by defining a point inside the watermark and applying a threshold of 30 to ensure consistent removal across varied images.
 */