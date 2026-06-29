using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Create graphics for the GIF image
                Graphics graphics = new Graphics(gif);

                // Define a solid brush for the overlay rectangle
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    // Optional: set opacity (0-255). GIF does not support alpha, but setting may affect palette.
                    brush.Opacity = 255;

                    // Draw a rectangle of size 200x150 at position (50,50)
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                }

                // Prepare save options with a file source
                Source source = new FileCreateSource(outputPath, false);
                GifOptions options = new GifOptions { Source = source };

                // Save the modified GIF
                gif.Save(outputPath, options);
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
 * 1. When you need to add a branded blue banner overlay rectangle to an animated GIF for marketing emails using Aspose.Imaging for .NET.
 * 2. When you want to highlight a region of interest in a GIF tutorial by drawing a 200 × 150‑pixel rectangle with a SolidBrush in C#.
 * 3. When you must create a simple watermark overlay on a GIF before publishing it on a website, using the Graphics.FillRectangle method.
 * 4. When you are generating a frame‑specific call‑to‑action area in a GIF advertisement by blending a custom rectangle onto the background.
 * 5. When you are preparing a GIF with a colored overlay to test color contrast and accessibility compliance using Aspose.Imaging.
 */