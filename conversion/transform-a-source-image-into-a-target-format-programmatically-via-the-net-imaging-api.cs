using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (first argument) or default.
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        // Output image path (second argument) or default.
        string outputPath = args.Length > 1 ? args[1] : "output.png";
        // Desired output format (third argument) or default.
        string format = args.Length > 2 ? args[2].ToLowerInvariant() : "png";

        // Load the source image.
        using (Image image = Image.Load(inputPath))
        {
            // Choose appropriate save options based on the requested format.
            switch (format)
            {
                case "png":
                    image.Save(outputPath, new PngOptions());
                    break;
                case "jpg":
                case "jpeg":
                    image.Save(outputPath, new JpegOptions());
                    break;
                case "bmp":
                    image.Save(outputPath, new BmpOptions());
                    break;
                case "gif":
                    image.Save(outputPath, new GifOptions());
                    break;
                case "webp":
                    image.Save(outputPath, new WebPOptions());
                    break;
                case "tiff":
                    image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                    break;
                case "pdf":
                    image.Save(outputPath, new PdfOptions());
                    break;
                case "apng":
                    image.Save(outputPath, new ApngOptions());
                    break;
                default:
                    throw new NotSupportedException($"The format '{format}' is not supported.");
            }
        }
    }
}