using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Webp;

namespace ImagingConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ImagingConversion <inputFile> <outputFile>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();

            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                switch (ext)
                {
                    case ".png":
                        using (var png = new PngOptions())
                        {
                            png.VectorRasterizationOptions = vectorOptions;
                            image.Save(outputPath, png);
                        }
                        break;
                    case ".jpg":
                    case ".jpeg":
                        using (var jpeg = new JpegOptions())
                        {
                            jpeg.VectorRasterizationOptions = vectorOptions;
                            image.Save(outputPath, jpeg);
                        }
                        break;
                    case ".bmp":
                        using (var bmp = new BmpOptions())
                        {
                            bmp.VectorRasterizationOptions = vectorOptions;
                            image.Save(outputPath, bmp);
                        }
                        break;
                    case ".gif":
                        using (var gif = new GifOptions())
                        {
                            gif.VectorRasterizationOptions = vectorOptions;
                            image.Save(outputPath, gif);
                        }
                        break;
                    case ".tif":
                    case ".tiff":
                        using (var tiff = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                        {
                            tiff.VectorRasterizationOptions = vectorOptions;
                            image.Save(outputPath, tiff);
                        }
                        break;
                    case ".webp":
                        using (var webp = new WebPOptions())
                        {
                            webp.VectorRasterizationOptions = vectorOptions;
                            image.Save(outputPath, webp);
                        }
                        break;
                    default:
                        Console.WriteLine("Unsupported output format. Supported: png, jpg, bmp, gif, tiff, webp.");
                        break;
                }
            }
        }
    }
}