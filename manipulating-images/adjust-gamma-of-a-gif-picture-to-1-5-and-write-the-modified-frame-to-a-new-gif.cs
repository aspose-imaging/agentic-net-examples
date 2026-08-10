// HOW-TO: Adjust Gamma of GIF to 1.5 and Save New GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.gif";
        string outputPath = @"c:\temp\sample.adjusted.gif";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Apply gamma correction (same value for R, G, B)
                gifImage.AdjustGamma(1.5f);

                // Save the modified image as a new GIF
                gifImage.Save(outputPath);
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
 * 1. When you need to brighten a GIF animation for web display by applying a gamma boost of 1.5 using Aspose.Imaging in C#.
 * 2. When you must correct the overall luminance of a legacy GIF file before embedding it in a mobile app.
 * 3. When you want to programmatically enhance the contrast of each frame in a GIF for better visual impact in a marketing email.
 * 4. When you are building an automated batch process that adjusts gamma of multiple GIFs to a consistent level and saves them as new files.
 * 5. When you need to preprocess GIF assets for a game engine, ensuring they have the desired brightness without manually editing each image.
 */
