using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string format = args.Length > 1 ? args[1] : args[0]; // use first argument as format if second missing
            string outputPath = Path.Combine("Output", $"result.{format}");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Choose appropriate save options based on format
                switch (format.ToLower())
                {
                    case "png":
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                        break;
                    case "jpg":
                    case "jpeg":
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
                        break;
                    case "bmp":
                        var bmpOptions = new BmpOptions();
                        image.Save(outputPath, bmpOptions);
                        break;
                    case "gif":
                        var gifOptions = new GifOptions();
                        image.Save(outputPath, gifOptions);
                        break;
                    case "tiff":
                    case "tif":
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        image.Save(outputPath, tiffOptions);
                        break;
                    case "pdf":
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                        break;
                    case "webp":
                        var webpOptions = new WebPOptions();
                        image.Save(outputPath, webpOptions);
                        break;
                    default:
                        throw new NotSupportedException($"Format '{format}' is not supported.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}