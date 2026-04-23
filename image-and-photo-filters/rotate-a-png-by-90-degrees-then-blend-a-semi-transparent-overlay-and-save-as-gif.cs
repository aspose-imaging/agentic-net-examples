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
            // Hardcoded input and overlay image paths
            string inputPngPath = "input.png";
            string overlayPath = "overlay.png";
            // Hardcoded output GIF path
            string outputGifPath = "output.gif";

            // Validate input PNG exists
            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            // Validate overlay image exists
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            // Load the base PNG image as a raster image
            using (RasterImage baseImage = (RasterImage)Image.Load(inputPngPath))
            {
                // Rotate the image 90 degrees clockwise, resize proportionally, white background
                baseImage.Rotate(90f, true, Color.White);

                // Load the semi‑transparent overlay image
                using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                {
                    // Blend overlay onto the rotated image at (0,0) with 50% opacity (128 out of 255)
                    baseImage.Blend(new Point(0, 0), overlay, 128);
                }

                // Prepare GIF save options with a file source
                GifOptions gifOptions = new GifOptions
                {
                    Source = new FileCreateSource(outputGifPath, false)
                };

                // Save the resulting image as a GIF
                baseImage.Save(outputGifPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}