using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\sample.adjusted.bmp";

        // Ensure any runtime exception is reported cleanly
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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access adjustment methods
                RasterImage rasterImage = (RasterImage)image;

                // Adjust brightness (range -255 to 255)
                int brightness = 40; // custom brightness value
                rasterImage.AdjustBrightness(brightness);

                // Adjust contrast (range -100f to 100f)
                float contrast = 30f; // custom contrast value
                rasterImage.AdjustContrast(contrast);

                // Save the modified image
                rasterImage.Save(outputPath);
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
 * 1. When a desktop application needs to automatically enhance scanned BMP documents by increasing brightness and contrast before archiving them, this C# code using Aspose.Imaging can apply custom adjustments and save the improved copy.
 * 2. When a batch‑processing service must prepare BMP assets for a legacy printing system that requires higher contrast levels, the code demonstrates how to programmatically modify each image and store the result.
 * 3. When a photo‑editing plugin for a Windows app wants to offer users a quick “brighten and boost contrast” feature for BMP files, the example shows the exact C# calls to adjust and save the image.
 * 4. When an automated quality‑control pipeline needs to normalize lighting conditions of BMP screenshots captured from hardware devices, the snippet illustrates how to apply consistent brightness and contrast settings.
 * 5. When a migration tool converts old BMP graphics to a more viewable state by tweaking visual parameters before moving them to a new system, this code provides a straightforward way to perform the adjustments in .NET.
 */