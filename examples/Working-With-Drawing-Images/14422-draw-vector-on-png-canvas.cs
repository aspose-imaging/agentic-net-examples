using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class DrawVectorOnPngCanvas
{
    static void Main()
    {
        // Paths for the source vector image (SVG) and the resulting PNG canvas
        string vectorPath = @"C:\temp\sample.svg";
        string outputPath = @"C:\temp\output.png";

        // Load the vector image (SVG) as a VectorImage
        using (VectorImage vectorImage = (VectorImage)Image.Load(vectorPath))
        {
            // Rasterize the vector image into a PNG stored in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Configure PNG options with vector rasterization settings
                PngOptions rasterPngOptions = new PngOptions
                {
                    // Default rasterization options; can be customized if needed
                    VectorRasterizationOptions = new VectorRasterizationOptions()
                };

                // Save the vector image as PNG into the memory stream
                vectorImage.Save(rasterStream, rasterPngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image (now a RasterImage) from the memory stream
                using (RasterImage rasterizedVector = (RasterImage)Image.Load(rasterStream))
                {
                    // Create a new PNG canvas (800x600) using Image.Create and PngOptions
                    PngOptions canvasOptions = new PngOptions
                    {
                        // Direct the canvas creation to a file stream
                        Source = new StreamSource(new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    };

                    using (Image canvas = Image.Create(canvasOptions, 800, 600))
                    {
                        // Initialize Graphics for drawing on the canvas
                        Graphics graphics = new Graphics(canvas);

                        // Optional: clear the canvas with a background color
                        graphics.Clear(Color.White);

                        // Draw the rasterized vector image onto the canvas at position (50,50)
                        graphics.DrawImage(rasterizedVector, new Point(50, 50));

                        // Save the canvas (the underlying stream is already linked to outputPath)
                        canvas.Save();
                    }
                }
            }
        }
    }
}