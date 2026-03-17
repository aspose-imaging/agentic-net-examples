using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: <inputSvgPath> <outputImagePath> <width> <height>");
            return;
        }

        string inputSvgPath = args[0];
        string outputImagePath = args[1];
        int targetWidth = int.Parse(args[2]);
        int targetHeight = int.Parse(args[3]);

        string ext = Path.GetExtension(outputImagePath).ToLowerInvariant();

        using (Image image = Image.Load(inputSvgPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = new SizeF(targetWidth, targetHeight);
            rasterOptions.BackgroundColor = Color.White;

            if (ext == ".png")
            {
                var options = new PngOptions { VectorRasterizationOptions = rasterOptions };
                image.Save(outputImagePath, options);
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                var options = new JpegOptions { VectorRasterizationOptions = rasterOptions };
                image.Save(outputImagePath, options);
            }
            else if (ext == ".bmp")
            {
                var options = new BmpOptions { VectorRasterizationOptions = rasterOptions };
                image.Save(outputImagePath, options);
            }
            else if (ext == ".gif")
            {
                var options = new GifOptions { VectorRasterizationOptions = rasterOptions };
                image.Save(outputImagePath, options);
            }
            else if (ext == ".webp")
            {
                var options = new WebPOptions { VectorRasterizationOptions = rasterOptions };
                image.Save(outputImagePath, options);
            }
            else if (ext == ".tif" || ext == ".tiff")
            {
                var options = new TiffOptions(TiffExpectedFormat.Default) { VectorRasterizationOptions = rasterOptions };
                image.Save(outputImagePath, options);
            }
            else
            {
                throw new NotSupportedException($"Unsupported output format: {ext}");
            }
        }
    }
}
