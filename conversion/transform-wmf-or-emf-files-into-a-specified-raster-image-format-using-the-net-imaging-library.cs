using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.png";

        using (Image image = Image.Load(inputPath))
        {
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();
            ImageOptionsBase options;

            if (ext == ".png")
            {
                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = CreateVectorOptions(image);
                options = pngOptions;
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                var jpegOptions = new JpegOptions();
                jpegOptions.VectorRasterizationOptions = CreateVectorOptions(image);
                options = jpegOptions;
            }
            else if (ext == ".bmp")
            {
                var bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = CreateVectorOptions(image);
                options = bmpOptions;
            }
            else if (ext == ".gif")
            {
                var gifOptions = new GifOptions();
                gifOptions.VectorRasterizationOptions = CreateVectorOptions(image);
                options = gifOptions;
            }
            else if (ext == ".tif" || ext == ".tiff")
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.VectorRasterizationOptions = CreateVectorOptions(image);
                options = tiffOptions;
            }
            else if (ext == ".webp")
            {
                var webpOptions = new WebPOptions();
                webpOptions.VectorRasterizationOptions = CreateVectorOptions(image);
                options = webpOptions;
            }
            else
            {
                throw new NotSupportedException("Unsupported output raster format: " + ext);
            }

            image.Save(outputPath, options);
        }
    }

    private static VectorRasterizationOptions CreateVectorOptions(Image image)
    {
        var vectorOptions = new VectorRasterizationOptions
        {
            BackgroundColor = Aspose.Imaging.Color.White,
            PageWidth = image.Width,
            PageHeight = image.Height,
            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
            SmoothingMode = Aspose.Imaging.SmoothingMode.None
        };
        return vectorOptions;
    }
}