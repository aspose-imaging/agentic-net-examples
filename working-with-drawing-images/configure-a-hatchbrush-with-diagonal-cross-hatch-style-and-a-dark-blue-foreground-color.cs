using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

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

            // Configure HatchBrush with diagonal cross style and dark blue foreground
            HatchBrush brush = new HatchBrush();
            brush.HatchStyle = HatchStyle.DiagonalCross; // diagonal cross hatch pattern
            brush.ForegroundColor = Color.Blue; // dark blue color for hatch lines

            // Example usage: create an image, draw a rectangle using the brush, and save
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen that uses the configured HatchBrush
                Pen pen = new Pen(brush, 5);
                graphics.DrawRectangle(pen, new Rectangle(new Point(20, 20), new Size(160, 160)));

                // Save the image
                image.Save();
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
 * 1. When generating a BMP report thumbnail that highlights selected regions with a dark‑blue diagonal‑cross hatch overlay using Aspose.Imaging for .NET.
 * 2. When creating a printable engineering diagram in C# where the background must be white and the boundary of a component is emphasized with a 5‑pixel dark‑blue diagonal‑cross hatch rectangle.
 * 3. When building a custom UI skin that draws scalable vector‑style icons on the fly and needs a consistent dark‑blue diagonal‑cross hatch brush for shading button borders in a BMP image.
 * 4. When automating the production of water‑marked images for a document management system and the watermark is rendered as a dark‑blue diagonal‑cross hatch pattern around a rectangular area.
 * 5. When developing a batch image‑processing tool that adds a diagnostic overlay to scanned BMP files, using a HatchBrush with diagonal‑cross style and dark‑blue foreground to outline regions of interest.
 */