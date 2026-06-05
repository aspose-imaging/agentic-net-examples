using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.bmp";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to PngImage to access PNG-specific properties
                if (image is PngImage pngImage)
                {
                    // Set a solid background color to replace transparent pixels
                    pngImage.HasBackgroundColor = true;
                    pngImage.BackgroundColor = Aspose.Imaging.Color.Blue; // choose any solid color

                    // Save the image as BMP with default options (supports background color)
                    pngImage.Save(outputPath, new BmpOptions());
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a PNG file.");
                }
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
 * 1. When a developer needs to convert a PNG with transparent areas into a BMP for legacy Windows applications that do not support alpha channels, replacing transparency with a solid background color.
 * 2. When generating printable assets where BMP is required and transparent PNGs must be flattened to a specific background color such as blue.
 * 3. When preparing image resources for a game engine that only accepts BMP files and needs consistent background shading for sprites originally saved as transparent PNGs.
 * 4. When automating batch processing of user‑uploaded PNG logos to create BMP thumbnails with a uniform background for email signatures.
 * 5. When integrating Aspose.Imaging in a C# service that receives PNG icons and must store them as BMP files with a defined background color for compatibility with older reporting tools.
 */