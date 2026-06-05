using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(image.Width / 2, image.Height / 2, ResizeType.NearestNeighbourResample);
                image.Rotate(270f, true, Color.Black);
                image.Save(outputPath, new PngOptions());
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
 * 1. When generating thumbnail previews for a web gallery, a developer can halve the original JPEG size using NearestNeighbour resampling, rotate it 270° to match portrait orientation, and save the result as a PNG with a black background for consistent display.
 * 2. When preparing product images for a mobile app that requires landscape orientation, a C# routine can resize the source JPEG by 50%, rotate it 270 degrees while filling empty corners with black, and output a PNG that preserves transparency.
 * 3. When converting scanned documents into a standardized format for archival, a developer may need to shrink the high‑resolution JPEG, rotate it 270° to correct upside‑down scans, and store the final image as a PNG with a black fill to avoid white margins.
 * 4. When creating sprite sheets for a game, the code can quickly downscale each source JPEG using NearestNeighbour, rotate the sprite 270° to align with the engine’s coordinate system, and save it as a PNG so the graphics pipeline can handle it efficiently.
 * 5. When automating batch processing of camera images that were captured in portrait mode, a developer can use this C# snippet to resize the JPEG, rotate it 270° to landscape, fill the background with black, and export a PNG ready for further analysis or display.
 */