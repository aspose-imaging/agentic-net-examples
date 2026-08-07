using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.png";

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
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using default options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        // Handle BMP-specific format errors gracefully
        catch (BmpImageException bmpEx)
        {
            Console.Error.WriteLine($"BMP format error: {bmpEx.Message}");
        }
        // Catch any other unexpected exceptions
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application allows users to upload BMP files and must convert them to PNG while handling unsupported BMP format errors gracefully.
 * 2. When a desktop utility processes batch image conversions from BMP to PNG and needs to verify file existence and catch BmpImageException to avoid crashes.
 * 3. When an automated image pipeline receives BMP inputs from legacy systems and must ensure the output directory is created before saving the PNG conversion.
 * 4. When a cloud service validates uploaded images, loads them with Aspose.Imaging, and provides clear error messages for corrupted BMP files.
 * 5. When a C# console tool integrates Aspose.Imaging to transform user‑provided BMP images to PNG and must handle any unexpected exceptions during processing.
 */