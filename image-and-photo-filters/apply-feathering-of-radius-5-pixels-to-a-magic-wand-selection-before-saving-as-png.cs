using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
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

            // Load the image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a magic wand mask at point (120, 100), feather it with radius 5, and apply to the image
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save the resulting image as PNG
                image.Save(outputPath);
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
 * 1. When a developer needs to smooth the edges of a region selected with a magic wand tool in a PNG screenshot before exporting it for a web UI, they can apply a 5‑pixel feather to the selection using Aspose.Imaging for .NET.
 * 2. When creating product catalog images where the background must be softly blended around a selected object, the code can feather the magic wand selection by 5 pixels and save the result as a transparent PNG.
 * 3. When automating the preparation of icons that require a subtle anti‑alias border around a color‑based selection, a developer can use this C# snippet to feather the selection and output a PNG file.
 * 4. When processing scanned documents to isolate a logo and need a gentle transition to the surrounding area, the magic wand with a 5‑pixel feather applied via Aspose.Imaging ensures the logo is saved cleanly as a PNG.
 * 5. When building a batch image‑processing tool that refines user‑defined selections with soft edges before archiving them, the code demonstrates how to feather a magic wand selection and store the final image in PNG format.
 */