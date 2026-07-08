using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\curved_line.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for the image
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Apply anti-aliasing for smoother curves
                graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define a pen for drawing
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);

                // Draw a curved line
                graphics.DrawCurve(pen, new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(50, 250),
                    new Aspose.Imaging.Point(150, 50),
                    new Aspose.Imaging.Point(350, 450),
                    new Aspose.Imaging.Point(450, 250)
                });

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
 * 1. When generating a BMP thumbnail for a scientific chart, setting Graphics.SmoothingMode to AntiAlias and drawing a curved line ensures the visual data appears smooth and professional.
 * 2. When adding a custom curved signature watermark to a BMP image for document security, anti‑aliased rendering prevents jagged edges and preserves brand quality.
 * 3. When creating a game asset such as a curved road overlay in a BMP sprite sheet, using AntiAlias smoothing produces clean edges that look polished in the final game.
 * 4. When exporting a CAD polyline as a BMP preview, applying SmoothingMode.AntiAlias to the drawn curve eliminates pixelated lines for clearer engineering visuals.
 * 5. When building a reporting tool that renders smooth trend lines on BMP graphs for printable PDFs, anti‑aliased curves improve readability and aesthetic appeal.
 */