using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\source.eps";
            string outputPath = @"C:\Images\ResizedResult.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate double size
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using a high‑quality interpolation method
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Save as high‑resolution PNG
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
 * 1. When a developer needs to double the size of a vector EPS logo for printing and export it as a high‑resolution PNG for web use.
 * 2. When an application must convert legacy EPS artwork into a larger PNG thumbnail while preserving quality using Aspose.Imaging in C#.
 * 3. When a batch process has to upscale EPS diagrams for inclusion in a PowerPoint presentation and save them as PNG files.
 * 4. When a graphics pipeline requires resizing EPS schematics to double dimensions before embedding them in a PDF report as PNG images.
 * 5. When a .NET service must validate the existence of an EPS file, enlarge it, and deliver a high‑resolution PNG to a client‑side viewer.
 */