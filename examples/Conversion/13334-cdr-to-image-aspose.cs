using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        // Expect input CDR file path and output file path as arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input.cdr> <output>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        string ext = Path.GetExtension(outputPath).ToLowerInvariant();

        // Load the CDR image.
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for vector conversion.
            var rasterOptions = new CdrRasterizationOptions
            {
                BackgroundColor = Color.White,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };

            // Choose save options based on the desired output format.
            switch (ext)
            {
                case ".pdf":
                    var pdfOptions = new PdfOptions();
                    pdfOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, pdfOptions);
                    break;
                case ".jpg":
                case ".jpeg":
                    var jpegOptions = new JpegOptions();
                    jpegOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, jpegOptions);
                    break;
                case ".png":
                    var pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, pngOptions);
                    break;
                case ".bmp":
                    var bmpOptions = new BmpOptions();
                    bmpOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, bmpOptions);
                    break;
                case ".gif":
                    var gifOptions = new GifOptions();
                    gifOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, gifOptions);
                    break;
                case ".tif":
                case ".tiff":
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, tiffOptions);
                    break;
                case ".webp":
                    var webpOptions = new WebPOptions();
                    webpOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, webpOptions);
                    break;
                default:
                    throw new NotSupportedException($"The format '{ext}' is not supported.");
            }
        }
    }
}