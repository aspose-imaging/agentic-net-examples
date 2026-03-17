using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input image, overlay image, and output directory (fallback defaults)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string overlayPath = args.Length > 1 ? args[1] : "overlay.png";
        string outputDir = args.Length > 2 ? args[2] : "output";

        Directory.CreateDirectory(outputDir);

        // Load the base image as a raster image
        using (RasterImage baseImage = (RasterImage)Image.Load(inputPath))
        {
            if (!baseImage.IsCached) baseImage.CacheData();

            // Apply brightness, contrast, gamma adjustments and convert to grayscale
            baseImage.AdjustBrightness(20);
            baseImage.AdjustContrast(0.5f);
            baseImage.AdjustGamma(1.2f);
            baseImage.Grayscale();

            // Rotate 45 degrees, expand canvas, fill background with white
            baseImage.Rotate(45f, true, Color.White);

            // Resize to half of the original dimensions
            int newWidth = baseImage.Width / 2;
            int newHeight = baseImage.Height / 2;
            baseImage.Resize(newWidth, newHeight);

            // Save as JPEG with quality 80
            string jpegPath = Path.Combine(outputDir, "result.jpg");
            var jpegOptions = new JpegOptions { Quality = 80 };
            baseImage.Save(jpegPath, jpegOptions);

            // Save as PNG
            string pngPath = Path.Combine(outputDir, "result.png");
            baseImage.Save(pngPath, new PngOptions());

            // Remove metadata and save as BMP
            baseImage.RemoveMetadata();
            string bmpPath = Path.Combine(outputDir, "result.bmp");
            baseImage.Save(bmpPath, new BmpOptions());

            // Load overlay image and blend it onto the base image at (0,0) with 50% opacity
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                if (!overlay.IsCached) overlay.CacheData();
                baseImage.Blend(new Point(0, 0), overlay, 128);
            }

            // Save the blended result as GIF
            string gifPath = Path.Combine(outputDir, "blended.gif");
            baseImage.Save(gifPath, new GifOptions());
        }
    }
}