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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path
        string inputPath = "input.eps";

        // Desired output file path (change extension to select format)
        string outputPath = "output.png";

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Determine output format based on file extension
            string ext = Path.GetExtension(outputPath).ToLowerInvariant();

            switch (ext)
            {
                case ".png":
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, pngOptions);
                    break;

                case ".jpg":
                case ".jpeg":
                    var jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, jpegOptions);
                    break;

                case ".bmp":
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, bmpOptions);
                    break;

                case ".gif":
                    var gifOptions = new GifOptions
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, gifOptions);
                    break;

                case ".tif":
                case ".tiff":
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, tiffOptions);
                    break;

                case ".webp":
                    var webpOptions = new WebPOptions
                    {
                        VectorRasterizationOptions = new EpsRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, webpOptions);
                    break;

                case ".pdf":
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                    break;

                default:
                    throw new NotSupportedException($"The output format '{ext}' is not supported.");
            }
        }
    }
}