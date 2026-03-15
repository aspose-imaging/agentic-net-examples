using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageFormatConverter
{
    static void Main(string[] args)
    {
        // Example usage:
        // args[0] = source image path (any supported format)
        // args[1] = target image path (desired format based on extension)
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ImageFormatConverter <sourcePath> <targetPath>");
            return;
        }

        string sourcePath = args[0];
        string targetPath = args[1];

        try
        {
            // Load the source image using Aspose.Imaging's generic loader.
            using (Image sourceImage = Image.Load(sourcePath))
            {
                // Determine the target format from the file extension.
                string targetExtension = System.IO.Path.GetExtension(targetPath).ToLowerInvariant();

                // Choose appropriate save options based on the target format.
                ImageOptionsBase saveOptions = GetSaveOptionsForExtension(targetExtension);

                // Save the image in the desired format.
                sourceImage.Save(targetPath, saveOptions);
            }

            Console.WriteLine($"Image successfully converted and saved to: {targetPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }

    // Returns a suitable ImageOptions instance for the given file extension.
    private static ImageOptionsBase GetSaveOptionsForExtension(string extension)
    {
        switch (extension)
        {
            case ".png":
                // PNG options – lossless compression.
                return new PngOptions
                {
                    ColorType = PngColorType.Rgb,
                    BitDepth = PngBitDepth.Bit8
                };
            case ".jpg":
            case ".jpeg":
                // JPEG options – specify quality (0-100).
                return new JpegOptions
                {
                    Quality = 90
                };
            case ".bmp":
                // BMP options – default settings.
                return new BmpOptions();
            case ".gif":
                // GIF options – default settings.
                return new GifOptions();
            case ".tiff":
            case ".tif":
                // TIFF options – use default compression.
                return new TiffOptions(TiffExpectedFormat.Default);
            case ".webp":
                // WebP options – default settings.
                return new WebPOptions();
            case ".ico":
                // ICO options – default settings.
                return new IcoOptions();
            default:
                // Fallback to generic raster options (PNG) if format is unknown.
                return new PngOptions();
        }
    }
}