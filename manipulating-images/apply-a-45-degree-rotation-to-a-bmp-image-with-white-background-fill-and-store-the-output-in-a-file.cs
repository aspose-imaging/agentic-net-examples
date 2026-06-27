using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!image.IsCached) image.CacheData();

                // Rotate 45 degrees clockwise, resize canvas proportionally, fill background with white
                image.Rotate(45f, true, Color.White);

                // Save the rotated image as BMP
                BmpOptions saveOptions = new BmpOptions();
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
 * 1. When a developer needs to rotate a BMP logo 45 degrees clockwise and fill the empty corners with a white background before embedding it into a C# Windows Forms application.
 * 2. When an imaging service must reorient scanned BMP receipts by 45 degrees and preserve a white canvas to maintain printable layout using Aspose.Imaging in .NET.
 * 3. When a game engine requires BMP sprite sheets to be rotated for isometric view, with a white background fill to avoid transparent artifacts during rendering.
 * 4. When an automated batch job processes BMP product images, applying a 45-degree rotation and white fill to meet a marketing department’s layout specifications.
 * 5. When a document generation tool converts BMP diagrams to a rotated orientation while ensuring the output file remains a BMP with a solid white background for consistent PDF embedding.
 */