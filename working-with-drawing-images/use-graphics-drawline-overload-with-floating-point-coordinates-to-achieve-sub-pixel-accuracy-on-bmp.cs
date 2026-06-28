using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Create a pen with sub‑pixel width
                Pen pen = new Pen(Color.Red, 2.5f);

                // Draw a line using floating‑point coordinates for sub‑pixel accuracy
                graphics.DrawLine(pen, 10.5f, 20.25f, 200.75f, 150.5f);

                // Save the modified image as BMP
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
 * 1. When a developer needs to add a precise red guide line to a BMP diagram for a CAD‑like overlay, using sub‑pixel coordinates to ensure smooth rendering.
 * 2. When a developer wants to annotate scanned documents with thin anti‑aliased lines in a .NET application while preserving BMP format compatibility.
 * 3. When a developer must generate pixel‑perfect UI mockups where line positions require fractional offsets for high‑resolution displays.
 * 4. When a developer is creating a custom watermark on a BMP image and needs sub‑pixel control to avoid visible jagged edges.
 * 5. When a developer is building a scientific visualization tool that draws measurement markers on BMP charts with floating‑point accuracy for accurate data representation.
 */