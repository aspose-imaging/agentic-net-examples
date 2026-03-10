using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (provide via command line or use defaults)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Determine the appropriate save options based on output file extension
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();
            ImageOptionsBase options;

            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    options = new JpegOptions();
                    break;
                case ".png":
                    options = new PngOptions();
                    break;
                case ".bmp":
                    options = new BmpOptions();
                    break;
                case ".gif":
                    options = new GifOptions();
                    break;
                case ".tif":
                case ".tiff":
                    options = new TiffOptions(TiffExpectedFormat.Default);
                    break;
                case ".pdf":
                    options = new PdfOptions();
                    break;
                case ".webp":
                    options = new WebPOptions();
                    break;
                default:
                    throw new NotSupportedException($"The output format '{ext}' is not supported.");
            }

            // Save the image using the selected options
            using (options)
            {
                image.Save(outputPath, options);
            }
        }
    }
}