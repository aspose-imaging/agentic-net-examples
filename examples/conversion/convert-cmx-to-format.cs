using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input.cmx> <output>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        string ext = Path.GetExtension(outputPath).ToLowerInvariant();

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = cmx.Width,
                PageHeight = cmx.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            ImageOptionsBase options;

            switch (ext)
            {
                case ".png":
                    var pngOpt = new PngOptions();
                    pngOpt.VectorRasterizationOptions = vectorOptions;
                    options = pngOpt;
                    break;
                case ".jpg":
                case ".jpeg":
                    var jpegOpt = new JpegOptions();
                    jpegOpt.VectorRasterizationOptions = vectorOptions;
                    options = jpegOpt;
                    break;
                case ".bmp":
                    var bmpOpt = new BmpOptions();
                    bmpOpt.VectorRasterizationOptions = vectorOptions;
                    options = bmpOpt;
                    break;
                case ".gif":
                    var gifOpt = new GifOptions();
                    gifOpt.VectorRasterizationOptions = vectorOptions;
                    options = gifOpt;
                    break;
                case ".tif":
                case ".tiff":
                    var tiffOpt = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOpt.VectorRasterizationOptions = vectorOptions;
                    options = tiffOpt;
                    break;
                case ".pdf":
                    var pdfOpt = new PdfOptions();
                    pdfOpt.VectorRasterizationOptions = vectorOptions;
                    options = pdfOpt;
                    break;
                default:
                    throw new NotSupportedException($"The format '{ext}' is not supported.");
            }

            using (options)
            {
                cmx.Save(outputPath, options);
            }
        }
    }
}