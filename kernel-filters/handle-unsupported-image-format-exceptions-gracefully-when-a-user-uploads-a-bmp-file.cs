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
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, handling BMP-specific format issues
            Image image;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (BmpImageException bmpEx)
            {
                Console.Error.WriteLine($"Unsupported BMP format: {bmpEx.Message}");
                return;
            }

            using (image)
            {
                // Convert and save as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application allows users to upload BMP photos and must convert them to PNG while providing a clear error message if the BMP version is unsupported.
 * 2. When an enterprise document management system processes scanned BMP files in bulk and needs to skip corrupted or legacy BMP formats without crashing the batch job.
 * 3. When a desktop C# utility imports user‑selected BMP images for editing and must gracefully inform the user when the file uses an unsupported BMP compression scheme.
 * 4. When a cloud‑based image‑processing API receives BMP uploads from mobile devices and must convert them to PNG while handling format exceptions to maintain service reliability.
 * 5. When an automated workflow converts legacy BMP assets to modern PNG format for a marketing website and must log unsupported BMP errors without interrupting the pipeline.
 */