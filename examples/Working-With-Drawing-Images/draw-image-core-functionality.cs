using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.GraphicsPath;

public class DrawImageExample
{
    public static void Main()
    {
        // Output file path
        string outputPath = "output.png";

        // Source raster image to embed
        string sourceImagePath = "sample.bmp";

        // Create a PNG image with a stream source
        using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(outStream);

            // Create a new 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Fill background with wheat color
                graphics.Clear(Color.Wheat);

                // Draw a black rectangle border around the image
                graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, 500, 500);

                // Load a raster image from file
                using (RasterImage raster = (RasterImage)Image.Load(sourceImagePath))
                {
                    // Draw the raster image at (100,100) scaled to 200x150 pixels
                    graphics.DrawImage(
                        raster,
                        new Rectangle(100, 100, 200, 150),               // destination rectangle
                        new Rectangle(0, 0, raster.Width, raster.Height), // source rectangle (full image)
                        GraphicsUnit.Pixel);
                }

                // Draw a red diagonal line across the canvas
                graphics.DrawLine(new Pen(Color.Red, 3), 0, 0, 500, 500);

                // Persist changes to the output file
                image.Save();
            }
        }
    }
}