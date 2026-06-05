using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF background image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Create a Graphics object for the active frame
                Graphics graphics = new Graphics(gif.ActiveFrame);

                // Define a semi‑transparent red brush
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    brush.Opacity = 128; // 0 (transparent) to 255 (opaque)

                    // Define the overlay rectangle (200x150) at position (50,50)
                    Rectangle overlayRect = new Rectangle(50, 50, 200, 150);

                    // Fill the rectangle onto the GIF frame
                    graphics.FillRectangle(brush, overlayRect);
                }

                // Save the modified GIF using default options
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}