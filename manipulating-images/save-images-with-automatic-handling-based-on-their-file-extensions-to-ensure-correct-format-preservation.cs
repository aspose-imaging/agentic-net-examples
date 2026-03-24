using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Determine output format based on file extension
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();
            ImageOptionsBase saveOptions;

            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    saveOptions = new JpegOptions();
                    break;
                case ".png":
                    saveOptions = new PngOptions();
                    break;
                case ".bmp":
                    saveOptions = new BmpOptions();
                    break;
                case ".gif":
                    saveOptions = new GifOptions();
                    break;
                case ".tif":
                case ".tiff":
                    saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    break;
                case ".webp":
                    saveOptions = new WebPOptions();
                    break;
                case ".pdf":
                    saveOptions = new PdfOptions();
                    break;
                case ".svg":
                    saveOptions = new SvgOptions();
                    break;
                case ".apng":
                    saveOptions = new ApngOptions();
                    break;
                case ".psd":
                    saveOptions = new PsdOptions();
                    break;
                default:
                    // Fallback to JPEG if format is unsupported
                    saveOptions = new JpegOptions();
                    break;
            }

            // Save the image with the selected options
            using (saveOptions)
            {
                image.Save(outputPath, saveOptions);
            }
        }
    }
}