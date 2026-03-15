using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Expect two arguments: input CDR file path and output image file path.
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: <program> <input.cdr> <output.[jpg|png|bmp|gif|tif|pdf|webp]>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        string ext = Path.GetExtension(outputPath).ToLowerInvariant();

        // Load the CDR file.
        using (Image image = Image.Load(inputPath))
        {
            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    using (JpegOptions options = new JpegOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".png":
                    using (PngOptions options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".bmp":
                    using (BmpOptions options = new BmpOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".gif":
                    using (GifOptions options = new GifOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".tif":
                case ".tiff":
                    using (TiffOptions options = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                case ".pdf":
                    using (PdfOptions options = new PdfOptions())
                    {
                        options.PdfDocumentInfo = new PdfDocumentInfo();
                        image.Save(outputPath, options);
                    }
                    break;

                case ".webp":
                    using (WebPOptions options = new WebPOptions())
                    {
                        image.Save(outputPath, options);
                    }
                    break;

                default:
                    throw new NotSupportedException($"The output format '{ext}' is not supported.");
            }
        }
    }
}