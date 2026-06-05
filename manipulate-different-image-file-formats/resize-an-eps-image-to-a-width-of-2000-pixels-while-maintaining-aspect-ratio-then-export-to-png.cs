using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = Image.Load(inputPath))
            {
                // Desired width
                int targetWidth = 2000;

                // Calculate height to maintain aspect ratio
                int targetHeight = (int)((double)image.Height * targetWidth / image.Width);

                // Resize using Mitchell cubic interpolation
                image.Resize(targetWidth, targetHeight, ResizeType.Mitchell);

                // Save the resized image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a high‑resolution EPS vector logo to a web‑friendly PNG thumbnail of 2000 px width while preserving the original aspect ratio using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must generate product preview images from EPS artwork, resizing them to a fixed width of 2000 pixels and exporting to PNG for fast page loads.
 * 3. When a publishing workflow requires batch processing of EPS illustrations, scaling them to a consistent width for print‑on‑demand PDFs and saving the results as PNG files via .NET.
 * 4. When a marketing automation script has to take client‑provided EPS files, resize them to a standard 2000‑pixel width for email campaigns, and output PNGs without losing quality.
 * 5. When a desktop application needs to display EPS diagrams on high‑DPI screens, it can resize the image to 2000 px width while maintaining aspect ratio and render it as a PNG using Aspose.Imaging in C#.
 */