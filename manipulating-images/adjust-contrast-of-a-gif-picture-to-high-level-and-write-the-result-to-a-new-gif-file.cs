using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_contrast.gif";

            // Verify that the input file exists
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
                // Cast to GifImage to access GIF‑specific methods
                GifImage gifImage = (GifImage)image;

                // Apply a high contrast value (maximum allowed is 100)
                gifImage.AdjustContrast(100f);

                // Save the modified image as a GIF
                GifOptions saveOptions = new GifOptions();
                gifImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enhance the visual clarity of animated GIF banners for a web page by increasing contrast using C# and Aspose.Imaging.
 * 2. When an e‑learning platform must preprocess user‑uploaded GIF quizzes to a high‑contrast style before embedding them in course material.
 * 3. When a marketing automation tool automatically converts low‑contrast promotional GIFs into eye‑catching assets by applying a maximum contrast adjustment in a .NET service.
 * 4. When a desktop application generates high‑contrast GIF thumbnails for accessibility compliance, using the AdjustContrast method of Aspose.Imaging.
 * 5. When a batch job processes a folder of legacy GIF icons, raising their contrast to improve readability on high‑resolution displays while preserving the GIF format.
 */