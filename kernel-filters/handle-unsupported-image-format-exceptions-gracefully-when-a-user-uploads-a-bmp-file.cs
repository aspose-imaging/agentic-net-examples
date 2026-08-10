// HOW-TO: Convert BMP to PNG in C# with Unsupported Format Handling (Aspose.Imaging for .NET)
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
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image, handling BMP-specific format issues
            Image image;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (BmpImageException bmpEx)
            {
                // Gracefully handle unsupported BMP format
                Console.Error.WriteLine($"Unsupported BMP image: {bmpEx.Message}");
                return;
            }

            // Use the loaded image
            using (image)
            {
                // Save as PNG using default options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Catch any other unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives user‑uploaded BMP files that may contain unsupported features, this code safely converts them to PNG while informing the user of format issues.
 * 2. When migrating legacy BMP assets to a modern PNG workflow, developers can use this snippet to batch‑process files and gracefully skip corrupted or unsupported BMPs.
 * 3. When building a desktop tool that lets users edit images, the code ensures that loading a BMP that Aspose.Imaging cannot parse does not crash the app.
 * 4. When integrating Aspose.Imaging into an automated pipeline that generates thumbnails, the example shows how to catch BMP format exceptions and still produce PNG outputs.
 * 5. When validating image uploads before storing them in a database, this pattern lets you verify the file exists, handle unsupported BMP formats, and store a universally supported PNG version.
 */
