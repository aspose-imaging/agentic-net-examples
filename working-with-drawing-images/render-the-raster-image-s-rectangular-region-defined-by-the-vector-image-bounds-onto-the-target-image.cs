using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Expect three arguments: vector image path, raster image path, output image path
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <vectorImagePath> <rasterImagePath> <outputImagePath>");
            return;
        }

        string vectorPath = args[0];
        string rasterPath = args[1];
        string outputPath = args[2];

        // Load vector image to obtain its bounds (width and height)
        int boundWidth, boundHeight;
        using (Image vectorImage = Image.Load(vectorPath))
        {
            boundWidth = vectorImage.Width;
            boundHeight = vectorImage.Height;
        }

        // Load raster image
        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterPath))
        {
            // Create output file source
            Source outputSource = new FileCreateSource(outputPath, false);

            // Set PNG options with the source
            PngOptions pngOptions = new PngOptions { Source = outputSource };

            // Create a canvas matching the vector image bounds
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, boundWidth, boundHeight))
            {
                // Create graphics for drawing onto the canvas
                Graphics graphics = new Graphics(canvas);

                // Define source and destination rectangles (top-left corner at 0,0)
                Rectangle srcRect = new Rectangle(0, 0, Math.Min(rasterImage.Width, boundWidth), Math.Min(rasterImage.Height, boundHeight));
                Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);

                // Draw the specified region of the raster image onto the canvas
                graphics.DrawImage(rasterImage, destRect, srcRect, GraphicsUnit.Pixel);

                // Save the bound canvas (output file is already bound via FileCreateSource)
                canvas.Save();
            }
        }
    }
}