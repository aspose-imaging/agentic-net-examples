using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Crop(new Rectangle(50, 50, 200, 200));
                image.Resize(400, 400);
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
 * 1. When a developer needs to generate a thumbnail from a large PNG by cropping a region of interest and resizing it to a standard 400 × 400 pixel size for display in a web gallery.
 * 2. When an e‑commerce platform must extract a product logo from a PNG file, crop out surrounding whitespace, and resize it to a fixed square size before embedding it in email newsletters.
 * 3. When a mobile app processes user‑uploaded PNG avatars, automatically crops the central area and scales it to 400 × 400 pixels to ensure consistent profile picture dimensions across devices.
 * 4. When a document management system prepares PNG scans for OCR by cropping the relevant page area and resizing it to a uniform size to improve recognition accuracy.
 * 5. When a digital signage solution needs to pre‑process PNG artwork by cutting a specific rectangle and scaling it to 400 × 400 pixels so the image fits the required screen slot without distortion.
 */