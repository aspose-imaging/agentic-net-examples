// HOW-TO: Adjust Brightness and Contrast of a BMP Image in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Custom adjustment parameters
                int brightness = 50; // range -255 to 255
                int contrast = 30;   // range -100 to 100

                // Apply adjustments
                image.AdjustBrightness(brightness);
                image.AdjustContrast(contrast);

                // Save the modified image
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
 * 1. When you need to programmatically brighten scanned BMP documents before OCR processing in a C# application.
 * 2. When you want to enhance the visual contrast of legacy BMP assets for a Windows desktop UI using Aspose.Imaging.
 * 3. When you must batch‑process user‑uploaded BMP photos to meet a specific brightness level for a photo‑sharing service.
 * 4. When you are creating a custom image‑editing tool that lets users adjust brightness and contrast of BMP files on the fly.
 * 5. When you need to generate a corrected copy of a BMP screenshot with predefined brightness and contrast settings for automated testing.
 */
