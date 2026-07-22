using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
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
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(cropRect);

                int centerX = cropWidth / 2;
                int centerY = cropHeight / 2;
                MagicWandTool
                    .Select(image, new MagicWandSettings(centerX, centerY))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate a thumbnail of a large BMP scan by extracting the central 400 × 400 pixels, applying a soft‑edge selection around a subject, and saving it as a PNG with transparency.
 * 2. When an e‑commerce platform must automatically isolate the product area from a high‑resolution BMP photograph, feather the edges to blend with the website background, and output a PNG for faster page loads.
 * 3. When a medical imaging system has to crop the region of interest from a BMP X‑ray, use a feathered Magic Wand to smooth the boundary of a lesion, and store the result as a lossless PNG for diagnostic review.
 * 4. When a game developer wants to preprocess sprite sheets stored as BMP files by extracting the central sprite, applying a feathered selection to remove jagged borders, and exporting the sprite as a PNG with an alpha channel.
 * 5. When a digital archivist needs to prepare scanned BMP documents for web publishing by centering a 400 × 400 excerpt, softening the selection edges to avoid harsh cuts, and converting the output to a PNG for universal browser compatibility.
 */