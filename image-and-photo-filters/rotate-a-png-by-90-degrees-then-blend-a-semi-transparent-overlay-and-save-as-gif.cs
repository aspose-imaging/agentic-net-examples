using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "input.png";
        string overlayPath = "overlay.png";
        string outputPath = "output.gif";

        // Input file checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load base PNG, rotate, blend overlay, and save as GIF
        using (RasterImage baseImg = (RasterImage)Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise, resize proportionally, transparent background
            baseImg.Rotate(90f, true, Color.Transparent);

            // Load overlay image
            using (RasterImage overlayImg = (RasterImage)Image.Load(overlayPath))
            {
                // Blend overlay with 50% opacity (128 out of 255)
                baseImg.Blend(new Point(0, 0), overlayImg, 128);
            }

            // Save result as GIF
            GifOptions gifOptions = new GifOptions();
            baseImg.Save(outputPath, gifOptions);
        }
    }
}