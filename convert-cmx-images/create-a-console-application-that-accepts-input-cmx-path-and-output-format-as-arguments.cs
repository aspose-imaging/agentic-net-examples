using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cmx";
            string outputPath = $"Output/output.{args[1]}";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Determine output format
                string format = args[1].ToLowerInvariant();

                switch (format)
                {
                    case "jpg":
                    case "jpeg":
                        using (var options = new JpegOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "png":
                        using (var options = new PngOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "bmp":
                        using (var options = new BmpOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "gif":
                        using (var options = new GifOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "tif":
                    case "tiff":
                        using (var options = new TiffOptions(TiffExpectedFormat.Default))
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "pdf":
                        using (var options = new PdfOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "wmf":
                        using (var options = new WmfOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    case "emf":
                        using (var options = new EmfOptions())
                        {
                            options.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = cmx.Width,
                                PageHeight = cmx.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            cmx.Save(outputPath, options);
                        }
                        break;

                    default:
                        Console.Error.WriteLine($"Unsupported output format: {format}");
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