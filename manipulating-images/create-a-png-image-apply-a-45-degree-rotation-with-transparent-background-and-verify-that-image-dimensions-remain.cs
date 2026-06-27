using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "Output/output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 200;
            int height = 200;

            using (PngImage png = new PngImage(width, height))
            {
                Graphics graphics = new Graphics(png);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, png.Bounds);
                }

                int originalWidth = png.Width;
                int originalHeight = png.Height;

                png.Rotate(45f, false, Color.Transparent);

                if (png.Width == originalWidth && png.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }
                else
                {
                    Console.WriteLine("Dimensions changed after rotation.");
                }

                png.Save(outputPath);
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
 * 1. When a developer needs to generate a PNG thumbnail with a rotated watermark while preserving the original canvas size for consistent layout in a web UI.
 * 2. When an e‑commerce platform wants to create product images that are rotated 45 degrees with a transparent background so they fit into a fixed‑size grid without altering the image dimensions.
 * 3. When a reporting tool must embed rotated icons into PDF pages and must keep the PNG dimensions unchanged to align with pre‑defined placeholders.
 * 4. When a game UI designer requires programmatically created PNG sprites that are rotated for visual effect but must retain their original width and height for collision detection.
 * 5. When an automated batch process creates PNG assets for a mobile app, applying a 45‑degree rotation with transparency while ensuring the file size and dimensions stay constant for responsive design.
 */