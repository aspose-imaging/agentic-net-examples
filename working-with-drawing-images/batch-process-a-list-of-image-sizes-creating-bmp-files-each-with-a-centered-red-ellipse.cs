using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output directory
            string outputDir = "output";
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // List of image sizes to process
            var sizes = new (int width, int height)[]
            {
                (200, 200),
                (400, 300),
                (800, 600)
            };

            foreach (var size in sizes)
            {
                // Construct output file path
                string outputPath = Path.Combine(outputDir, $"image_{size.width}x{size.height}.bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up BMP options with a bound file source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create the image canvas
                using (Image image = Image.Create(bmpOptions, size.width, size.height))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);

                    // Clear background to white
                    graphics.Clear(Color.White);

                    // Create a red pen for the ellipse
                    Pen redPen = new Pen(Color.Red, 2);

                    // Draw a centered ellipse that fits the canvas
                    graphics.DrawEllipse(redPen, 0, 0, size.width, size.height);

                    // Save the image (file is already bound via FileCreateSource)
                    image.Save();
                }
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
 * 1. When generating placeholder graphics for UI mockups, a developer can batch‑create BMP files of various dimensions with a centered red ellipse to represent image slots.
 * 2. When preparing test data for automated image‑processing pipelines, this code can quickly produce a set of BMP images at different resolutions containing a known shape for validation.
 * 3. When building a reporting tool that needs thumbnail previews of different page sizes, the code can generate BMP thumbnails with a red ellipse to indicate the printable area.
 * 4. When creating assets for a game’s level editor, developers can use the script to produce BMP markers of various canvas sizes that show a centered ellipse as a collision‑boundary visual.
 * 5. When setting up a batch conversion benchmark, the code can generate BMP files of multiple sizes with a simple red ellipse to measure rendering and file‑write performance across resolutions.
 */