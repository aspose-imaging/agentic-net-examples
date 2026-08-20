// HOW-TO: Remove White Background from SVG While Keeping White Objects in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

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

            // Load the image as a VectorImage
            using (VectorImage vectorImage = Image.Load(inputPath) as VectorImage)
            {
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
                    return;
                }

                // Configure background removal to treat white as background
                var bgSettings = new RemoveBackgroundSettings
                {
                    Color1 = Aspose.Imaging.Color.White // set background color to white
                };

                // Remove the background using the configured settings
                vectorImage.RemoveBackground(bgSettings);

                // Save the processed image
                vectorImage.Save(outputPath);
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
 * 1. When you need to clean up scanned SVG logos by stripping a white canvas but retaining white text or icons.
 * 2. When preparing SVG assets for dark‑mode websites, you want to eliminate the white background without losing white foreground elements.
 * 3. When converting vector graphics for printing, you may need to remove the page‑white background while preserving white decorative details.
 * 4. When automating batch processing of SVG files to make them transparent for overlay on other images, you set the background color to white to keep white shapes visible.
 * 5. When integrating SVGs into a UI that applies its own background, you remove the original white background to avoid double‑layering while keeping any white graphics intact.
 */
