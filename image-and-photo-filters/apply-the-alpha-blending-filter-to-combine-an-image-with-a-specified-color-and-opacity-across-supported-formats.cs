using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";
        string outputFormat = "JPG";
        Aspose.Imaging.Color overlayColor = Aspose.Imaging.Color.FromArgb(255, 0, 0, 255);
        byte opacity = 128;

        using (Aspose.Imaging.RasterImage source = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            using (MemoryStream overlayStream = new MemoryStream())
            {
                Aspose.Imaging.Sources.StreamSource overlaySource = new StreamSource(overlayStream);
                PngOptions overlayOptions = new PngOptions() { Source = overlaySource };

                using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(overlayOptions, source.Width, source.Height))
                {
                    int pixelCount = source.Width * source.Height;
                    int[] pixels = new int[pixelCount];
                    int argb = overlayColor.ToArgb();
                    for (int i = 0; i < pixelCount; i++)
                        pixels[i] = argb;

                    overlay.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, source.Width, source.Height), pixels);
                    source.Blend(new Aspose.Imaging.Point(0, 0), overlay, opacity);
                }
            }

            Aspose.Imaging.Sources.FileCreateSource outSource = new FileCreateSource(outputPath, false);

            switch (outputFormat.ToUpperInvariant())
            {
                case "JPG":
                case "JPEG":
                    var jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
                    source.Save(outputPath, jpegOptions);
                    break;
                case "PNG":
                    var pngOptions = new PngOptions() { Source = outSource };
                    source.Save(outputPath, pngOptions);
                    break;
                case "BMP":
                    var bmpOptions = new BmpOptions() { Source = outSource };
                    source.Save(outputPath, bmpOptions);
                    break;
                case "TIFF":
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = outSource };
                    source.Save(outputPath, tiffOptions);
                    break;
                case "GIF":
                    var gifOptions = new GifOptions() { Source = outSource };
                    source.Save(outputPath, gifOptions);
                    break;
                case "WEBP":
                    var webpOptions = new WebPOptions() { Source = outSource };
                    source.Save(outputPath, webpOptions);
                    break;
                case "PDF":
                    var pdfOptions = new PdfOptions();
                    source.Save(outputPath, pdfOptions);
                    break;
                default:
                    var defaultOptions = new JpegOptions() { Source = outSource, Quality = 90 };
                    source.Save(outputPath, defaultOptions);
                    break;
            }
        }
    }
}