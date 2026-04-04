using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.gif";
        string outputPath = @"C:\temp\sample.dithered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF‑specific methods
            GifImage gifImage = (GifImage)image;

            // Apply dithering (example: Floyd‑Steinberg with 8‑bit palette)
            gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

            // Assess transparency after dithering
            bool hasTransparentPixel = false;
            // GifImage derives from RasterImage, so we can use GetPixel
            for (int y = 0; y < gifImage.Height && !hasTransparentPixel; y++)
            {
                for (int x = 0; x < gifImage.Width; x++)
                {
                    // GetPixel returns a Color structure; A == 0 means fully transparent
                    if (gifImage.GetPixel(x, y).A == 0)
                    {
                        hasTransparentPixel = true;
                        break;
                    }
                }
            }

            Console.WriteLine(hasTransparentPixel
                ? "The dithered image contains transparent pixels."
                : "The dithered image does not contain transparent pixels.");

            // Save the dithered image (lossless PNG)
            PngOptions pngOptions = new PngOptions();
            gifImage.Save(outputPath, pngOptions);
        }
    }
}