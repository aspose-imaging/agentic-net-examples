using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Supported output formats
    enum ImageFormat { Png, Bmp, Jpeg, Gif }

    static void Main()
    {
        // Example usage: create a 800x600 PNG image
        CreateImage(800, 600, @"C:\temp\output.png", ImageFormat.Png);
    }

    static void CreateImage(int width, int height, string outputPath, ImageFormat format)
    {
        // Choose appropriate image options based on the desired format
        ImageOptionsBase options;
        switch (format)
        {
            case ImageFormat.Png:
                var pngOptions = new PngOptions();
                // Example: set compression level (optional)
                pngOptions.CompressionLevel = 6;
                options = pngOptions;
                break;

            case ImageFormat.Bmp:
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24 // 24‑bit color
                };
                options = bmpOptions;
                break;

            case ImageFormat.Jpeg:
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // JPEG quality (0‑100)
                };
                options = jpegOptions;
                break;

            case ImageFormat.Gif:
                var gifOptions = new GifOptions();
                options = gifOptions;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(format), format, null);
        }

        // Create a new image with the specified dimensions using the selected options
        using (Image image = Image.Create(options, width, height))
        {
            // Optional: perform image processing here (e.g., fill background)

            // Save the image to the target file path
            image.Save(outputPath);
        }
    }
}