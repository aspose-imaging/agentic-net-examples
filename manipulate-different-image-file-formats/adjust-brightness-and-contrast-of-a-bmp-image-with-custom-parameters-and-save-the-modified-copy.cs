// HOW-TO: Adjust Brightness and Contrast of a BMP Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        // Custom brightness and contrast values
        int brightness = 50;          // Range: -255 to 255
        float contrast = 30f;         // Range: -100 to 100

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Adjust brightness
                bmpImage.AdjustBrightness(brightness);

                // Adjust contrast
                bmpImage.AdjustContrast(contrast);

                // Save the modified image
                bmpImage.Save(outputPath);
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
 * 1. When you need to enhance the visual clarity of a scanned BMP photo by increasing its brightness and contrast before displaying it in a Windows application.
 * 2. When preprocessing BMP assets for a game, you want to programmatically adjust brightness and contrast to match the game's lighting conditions.
 * 3. When converting legacy BMP files from a hardware device and you must correct exposure issues by applying custom brightness and contrast values.
 * 4. When generating thumbnails of BMP images for a web gallery and you need to improve their appearance without altering the original files.
 * 5. When automating batch processing of BMP screenshots to make text more readable by adjusting brightness and contrast in a C# script.
 */
