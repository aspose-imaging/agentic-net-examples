using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Paths (replace with actual file locations)
        string outputPath = "output.png";
        string sourceImagePath = "source.jpg";

        // Create output stream
        using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options with the output stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(outputStream);

            // Create a blank canvas image (800x600)
            using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(pngOptions, 800, 600))
            {
                // Load the source image to be drawn
                using (Aspose.Imaging.Image sourceImage = Aspose.Imaging.Image.Load(sourceImagePath))
                {
                    // Cast to RasterImage for drawing
                    Aspose.Imaging.RasterImage rasterSource = sourceImage as Aspose.Imaging.RasterImage;
                    if (rasterSource == null)
                        throw new InvalidOperationException("Source image must be a raster image.");

                    // Initialize graphics for the canvas
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

                    // Clear the canvas with a light gray background
                    graphics.Clear(Aspose.Imaging.Color.LightGray);

                    // Draw the source image at position (50, 50)
                    graphics.DrawImage(rasterSource, new Aspose.Imaging.Point(50, 50));

                    // Draw the same source image scaled to a rectangle at (400, 300)
                    graphics.DrawImage(
                        rasterSource,
                        new Aspose.Imaging.Rectangle(400, 300, 200, 150),   // destination rectangle
                        new Aspose.Imaging.Rectangle(0, 0, rasterSource.Width, rasterSource.Height), // source rectangle
                        Aspose.Imaging.GraphicsUnit.Pixel);

                    // Save the canvas (output is already bound to the stream)
                    canvas.Save();
                }
            }
        }
    }
}