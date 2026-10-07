// HOW-TO: Create Precise Color Mask on BMP Using Magic Wand in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10) { Threshold = 5 })
                    .Apply();

                BmpOptions saveOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath)
                };
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
 * 1. When you need to isolate a small area of a BMP image for editing or analysis by applying a low‑threshold Magic Wand mask.
 * 2. When you want to programmatically generate a mask that selects pixels of a specific color range in a bitmap before saving the result.
 * 3. When you are building an automated pipeline that extracts precise regions from scanned documents or sprites using Aspose.Imaging’s MagicWandTool.
 * 4. When you need to create a mask for computer‑vision preprocessing, such as separating foreground objects from a background in a BMP file.
 * 5. When you must apply a custom threshold to a color‑based selection to ensure only tightly matching pixels are included in the mask for further processing.
 */
