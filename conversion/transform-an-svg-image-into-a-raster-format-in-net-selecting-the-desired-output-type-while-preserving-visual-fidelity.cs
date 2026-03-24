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
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();
            ImageOptionsBase saveOptions;

            switch (ext)
            {
                case ".png":
                    var pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    saveOptions = pngOptions;
                    break;
                case ".jpg":
                case ".jpeg":
                    var jpegOptions = new JpegOptions();
                    jpegOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    saveOptions = jpegOptions;
                    break;
                case ".bmp":
                    var bmpOptions = new BmpOptions();
                    bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    saveOptions = bmpOptions;
                    break;
                case ".tif":
                case ".tiff":
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    saveOptions = tiffOptions;
                    break;
                case ".gif":
                    var gifOptions = new GifOptions();
                    gifOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    saveOptions = gifOptions;
                    break;
                case ".webp":
                    var webpOptions = new WebPOptions();
                    webpOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    saveOptions = webpOptions;
                    break;
                default:
                    Console.Error.WriteLine($"Unsupported output format: {ext}");
                    return;
            }

            image.Save(outputPath, saveOptions);
        }
    }
}