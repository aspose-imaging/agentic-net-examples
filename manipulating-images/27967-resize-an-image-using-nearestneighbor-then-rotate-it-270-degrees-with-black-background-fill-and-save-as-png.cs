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
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                image.Rotate(270f, true, Aspose.Imaging.Color.Black);
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
 * 1. When creating thumbnail previews for a web gallery that must be half the original size and displayed in portrait orientation, a developer can resize the JPEG with nearest‑neighbor resampling, rotate it 270° with a black background, and save it as a PNG.
 * 2. When processing scanned documents that need to be reduced in resolution, rotated to match printer requirements, and stored in a lossless format, this code resizes using nearest‑neighbor, rotates 270°, fills empty corners with black, and outputs a PNG.
 * 3. When generating assets for a mobile game where sprites are stored as PNGs, the developer can halve the source image, rotate it to align with the game’s coordinate system, and ensure any uncovered area is filled with black.
 * 4. When preparing product images for an e‑commerce catalog that requires a consistent portrait layout, the code can shrink the original photo, rotate it 270°, pad the background with black, and save it as a PNG for fast loading.
 * 5. When converting legacy JPEG screenshots into PNG thumbnails for a documentation portal, the developer can use nearest‑neighbor resizing for speed, rotate the image to the correct orientation, and apply a black background fill before saving.
 */