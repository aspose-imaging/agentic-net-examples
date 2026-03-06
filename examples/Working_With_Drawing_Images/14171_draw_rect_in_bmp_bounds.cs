using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output BMP image path
        string outputPath = "output.bmp";

        // Load the raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Define the rectangular part to extract (center half of the image)
            Rectangle srcRect = new Rectangle(
                raster.Width / 4,
                raster.Height / 4,
                raster.Width / 2,
                raster.Height / 2);

            // Create a BMP canvas sized to the extracted rectangle
            Source fileSource = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = fileSource };

            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, srcRect.Width, srcRect.Height))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(canvas);
                // Optional: clear background
                graphics.Clear(Color.White);
                // Draw the selected rectangle portion onto the canvas
                graphics.DrawImage(
                    raster,
                    new Rectangle(0, 0, srcRect.Width, srcRect.Height), // destination rectangle
                    srcRect,                                          // source rectangle
                    GraphicsUnit.Pixel);

                // Save the BMP image (bound to the file source)
                canvas.Save();
            }
        }
    }
}