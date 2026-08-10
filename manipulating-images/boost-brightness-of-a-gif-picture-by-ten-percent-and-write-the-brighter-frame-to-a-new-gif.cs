// HOW-TO: Increase GIF Brightness By 10 Percent Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_brighter.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Increase brightness by roughly 10% (255 * 0.10 ≈ 26)
                gifImage.AdjustBrightness(26);

                // Save the brighter GIF
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
 * 1. When you need to make an animated GIF appear lighter for a web banner without altering its animation frames, you can adjust its brightness with Aspose.Imaging in C#.
 * 2. When preparing product showcase GIFs for mobile apps, increasing brightness by a small percentage ensures visibility on high‑contrast screens.
 * 3. When automating a batch process that enhances user‑uploaded GIFs before storing them in a content management system, this code provides a simple brightness boost.
 * 4. When creating marketing email campaigns that embed GIFs, raising the brightness helps the animation stand out in various email clients.
 * 5. When integrating image processing into a .NET service that dynamically generates brighter GIF thumbnails for preview galleries, this snippet performs the adjustment quickly.
 */
