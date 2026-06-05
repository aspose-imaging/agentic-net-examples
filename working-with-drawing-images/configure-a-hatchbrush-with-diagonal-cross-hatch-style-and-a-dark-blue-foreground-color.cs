using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Configure a HatchBrush with diagonal cross style and dark blue foreground
                HatchBrush brush = new HatchBrush();
                brush.HatchStyle = HatchStyle.DiagonalCross;          // Diagonal cross hatch
                brush.ForegroundColor = Color.DarkBlue;               // Dark blue lines
                brush.BackgroundColor = Color.Transparent;            // Optional background

                // Use the brush to create a pen
                Pen pen = new Pen(brush, 5f);

                // Draw a rectangle using the hatch‑filled pen
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 200));

                // Save the modified image to the output path
                image.Save(outputPath);
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
 * 1. When generating a BMP report graphic that needs a dark‑blue diagonal‑cross hatch overlay to highlight a selected region.
 * 2. When creating a printable PDF watermark by drawing a rectangle with a diagonal‑cross hatch brush on a bitmap before embedding it.
 * 3. When building a CAD‑style diagram in a .NET desktop app where areas must be filled with a dark‑blue cross‑hatch pattern for visual distinction.
 * 4. When processing scanned images and adding a dark‑blue diagonal‑cross hatch border to indicate areas that require manual review.
 * 5. When developing a game UI that uses a hatch‑filled rectangle as a button background, requiring C# Graphics, Pen, and HatchBrush configuration.
 */