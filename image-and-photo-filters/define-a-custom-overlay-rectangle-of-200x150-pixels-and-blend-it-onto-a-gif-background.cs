// HOW-TO: Blend a 200x150 Overlay Rectangle onto a GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\background.gif";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the background GIF
            using (GifImage background = (GifImage)Image.Load(inputPath))
            {
                // Create an overlay rectangle block of 200x150 pixels
                using (GifFrameBlock overlay = new GifFrameBlock(200, 150))
                {
                    // Fill the overlay with a solid color (e.g., blue)
                    Graphics graphics = new Graphics(overlay);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, overlay.Bounds);

                    // Position where the overlay will be placed on the background
                    int posX = 50; // example X offset
                    int posY = 30; // example Y offset

                    // Load overlay pixel data
                    int[] overlayPixels = overlay.LoadArgb32Pixels(overlay.Bounds);

                    // Blend the overlay onto the background at the specified position
                    background.SaveArgb32Pixels(new Rectangle(posX, posY, overlay.Width, overlay.Height), overlayPixels);
                }

                // Save the modified GIF with default options
                GifOptions gifOptions = new GifOptions();
                background.Save(outputPath, gifOptions);
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
 * 1. When you need to add a solid‑color banner or badge to an animated GIF for branding or notification purposes.
 * 2. When you want to programmatically overlay a custom‑sized rectangle onto a GIF frame to highlight a region in a web‑based image editor.
 * 3. When you are generating dynamic GIFs that require a colored placeholder (e.g., loading indicator) positioned at a specific offset.
 * 4. When you must combine a generated graphic with an existing GIF background for creating composite animations in a C# application.
 * 5. When you are implementing a server‑side service that adds a colored overlay to user‑uploaded GIFs before storing or serving them.
 */
