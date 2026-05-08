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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output format arguments
            string inputPath = args[0];
            string outputFormat = args[1];

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output file path
            string outputFileName = $"Result.{outputFormat.ToLower()}";
            string outputPath = Path.Combine("Output", outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                switch (outputFormat.ToLower())
                {
                    case "png":
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                BackgroundColor = Color.White
                            }
                        };
                        image.Save(outputPath, pngOptions);
                        break;

                    case "jpg":
                    case "jpeg":
                        var jpegOptions = new JpegOptions
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                BackgroundColor = Color.White
                            }
                        };
                        image.Save(outputPath, jpegOptions);
                        break;

                    case "bmp":
                        var bmpOptions = new BmpOptions
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                BackgroundColor = Color.White
                            }
                        };
                        image.Save(outputPath, bmpOptions);
                        break;

                    case "gif":
                        var gifOptions = new GifOptions
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                BackgroundColor = Color.White
                            }
                        };
                        image.Save(outputPath, gifOptions);
                        break;

                    case "tiff":
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                BackgroundColor = Color.White
                            }
                        };
                        image.Save(outputPath, tiffOptions);
                        break;

                    case "pdf":
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                        break;

                    case "webp":
                        var webpOptions = new WebPOptions
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                BackgroundColor = Color.White
                            }
                        };
                        image.Save(outputPath, webpOptions);
                        break;

                    default:
                        Console.Error.WriteLine($"Unsupported format: {outputFormat}");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}