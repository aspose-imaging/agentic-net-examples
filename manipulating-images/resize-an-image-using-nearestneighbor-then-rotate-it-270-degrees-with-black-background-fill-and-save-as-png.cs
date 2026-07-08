using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(image.Width / 2, image.Height / 2, ResizeType.NearestNeighbourResample);
                image.Rotate(270f, false, Color.Black);
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
 * 1. When generating thumbnail previews for a web gallery, a developer can resize the original JPEG by 50 % using nearest‑neighbor interpolation, rotate it 270° to portrait orientation, and save the result as a PNG with a black background fill.
 * 2. When preparing product images for a mobile app that requires smaller PNG files rotated to match device orientation, the code resizes the JPEG with nearest‑neighbor scaling, rotates it 270°, and fills empty areas with black.
 * 3. When converting scanned JPEG documents into PNGs for an OCR pipeline, a developer may need to downscale the image, rotate it 270 degrees, and use a black background to maintain consistent contrast.
 * 4. When creating sprite sheets for a game, a developer can shrink each source JPEG sprite, rotate it 270° to align with the engine’s coordinate system, and export it as a PNG with a black fill to avoid transparent artifacts.
 * 5. When automating batch processing of user‑uploaded photos, a C# service can resize each image by half using nearest‑neighbor resampling, rotate it 270°, and save it as a PNG with a black background to ensure uniform presentation across browsers.
 */