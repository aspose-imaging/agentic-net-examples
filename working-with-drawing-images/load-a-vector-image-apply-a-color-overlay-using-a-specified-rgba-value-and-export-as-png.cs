using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Create a graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Define the overlay color (RGBA)
                // Example: semi‑transparent red (A=128, R=255, G=0, B=0)
                Aspose.Imaging.Color overlayColor = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0);

                // Create a solid brush with the overlay color
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = overlayColor;
                    // Fill the entire image with the overlay
                    graphics.FillRectangle(brush, image.Bounds);
                }

                // Save the result as PNG
                PngOptions pngOptions = new PngOptions();
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
 * 1. When a web application needs to generate product thumbnails from SVG icons with a semi‑transparent brand color overlay and deliver them as PNG files.
 * 2. When a reporting tool must apply a corporate color scheme to vector diagrams (SVG) before embedding them in PDF or HTML reports as PNG images.
 * 3. When an e‑learning platform wants to highlight specific regions of SVG illustrations by adding a translucent RGBA overlay and export the result for use in slide decks.
 * 4. When a mobile app backend processes user‑uploaded SVG avatars, adds a customizable color tint for theme consistency, and stores the final PNG for fast rendering on devices.
 * 5. When a batch‑processing script converts a library of SVG assets to PNG while applying a uniform color filter to match a marketing campaign’s visual style.
 */