// HOW-TO: Create BMP with Light Blue Background and Overlapping Transparent Rectangles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);

            int width = 400;
            int height = 300;

            using (Image image = Image.Create(createOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.FromArgb(255, 173, 216, 230)); // Light blue background

                // First semi‑transparent red rectangle
                using (SolidBrush brush1 = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 150));
                }

                // Second semi‑transparent green rectangle overlapping the first
                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, 0, 255, 0)))
                {
                    graphics.FillRectangle(brush2, new Rectangle(150, 100, 200, 150));
                }

                // Optional outlines
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
                graphics.DrawRectangle(pen, new Rectangle(150, 100, 200, 150));

                // Save the image (output path already bound)
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
 * 1. When you need to generate a BMP image with a light‑blue canvas and semi‑transparent overlay shapes for a reporting UI.
 * 2. When you want to programmatically draw overlapping translucent rectangles on a BMP background for a game level‑design preview.
 * 3. When you must produce a BMP thumbnail that demonstrates alpha blending by stacking semi‑transparent red and green rectangles.
 * 4. When you are building a custom watermarking tool that adds translucent colored blocks on top of an existing image background.
 * 5. When you need to export a simple illustration, such as a UI mock‑up, directly to BMP format without using external graphics editors.
 */
