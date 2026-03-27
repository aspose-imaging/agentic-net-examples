using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png"; // Change extension to desired format (png, jpg, pdf, bmp, gif, tif, webp)

        // Verify input file exists
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
            // Determine output format by file extension
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();

            if (ext == ".png")
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                var options = new JpegOptions();
                image.Save(outputPath, options);
            }
            else if (ext == ".pdf")
            {
                var options = new PdfOptions();
                image.Save(outputPath, options);
            }
            else if (ext == ".bmp")
            {
                var options = new BmpOptions();
                image.Save(outputPath, options);
            }
            else if (ext == ".gif")
            {
                var options = new GifOptions();
                image.Save(outputPath, options);
            }
            else if (ext == ".tif" || ext == ".tiff")
            {
                var options = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, options);
            }
            else if (ext == ".webp")
            {
                var options = new WebPOptions();
                image.Save(outputPath, options);
            }
            else
            {
                Console.Error.WriteLine($"Unsupported output format: {ext}");
            }
        }
    }
}