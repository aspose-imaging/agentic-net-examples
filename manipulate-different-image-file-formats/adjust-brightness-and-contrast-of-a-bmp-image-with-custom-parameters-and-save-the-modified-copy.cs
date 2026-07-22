using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access adjustment methods
                RasterImage rasterImage = (RasterImage)image;

                // Adjust brightness (range -255 to 255)
                int brightness = 50; // example value
                rasterImage.AdjustBrightness(brightness);

                // Adjust contrast (range -100 to 100)
                float contrast = 30f; // example value
                rasterImage.AdjustContrast(contrast);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to programmatically enhance the visibility of a BMP scan by increasing its brightness and contrast before archiving it using Aspose.Imaging in C#.
 * 2. When an application must generate a brighter version of a legacy bitmap logo for display on high‑resolution monitors by adjusting brightness and contrast with C# image processing.
 * 3. When a batch‑processing tool has to automatically adjust the tonal balance of user‑uploaded BMP photos to meet printing specifications without manual editing.
 * 4. When a Windows service prepares BMP screenshots for OCR by boosting brightness and contrast to improve character recognition.
 * 5. When a game asset pipeline requires creating a contrast‑adjusted copy of a BMP texture to achieve a specific visual style during runtime.
 */