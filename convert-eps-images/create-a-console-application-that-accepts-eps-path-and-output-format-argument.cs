// HOW-TO: Convert EPS to PNG, JPEG, BMP, GIF, or TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.eps";
            string format = args[0]; // No args length validation as per requirements
            string outputPath = $"output.{format.ToLower()}";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Common rasterization options for vector-to-raster formats
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                // Save based on requested format
                switch (format.ToUpper())
                {
                    case "PNG":
                        image.Save(outputPath, new PngOptions { VectorRasterizationOptions = rasterOptions });
                        break;
                    case "JPG":
                    case "JPEG":
                        image.Save(outputPath, new JpegOptions { VectorRasterizationOptions = rasterOptions });
                        break;
                    case "BMP":
                        image.Save(outputPath, new BmpOptions { VectorRasterizationOptions = rasterOptions });
                        break;
                    case "GIF":
                        image.Save(outputPath, new GifOptions { VectorRasterizationOptions = rasterOptions });
                        break;
                    case "TIFF":
                    case "TIF":
                        image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default) { VectorRasterizationOptions = rasterOptions });
                        break;
                    case "PDF":
                        image.Save(outputPath, new PdfOptions());
                        break;
                    case "WEBP":
                        image.Save(outputPath, new WebPOptions { VectorRasterizationOptions = rasterOptions });
                        break;
                    default:
                        // Fallback to PNG if format is unsupported
                        image.Save(outputPath, new PngOptions { VectorRasterizationOptions = rasterOptions });
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert EPS vector files to raster images for web thumbnails.
 * 2. When an application must dynamically generate PNG, JPEG, BMP, GIF, or TIFF from user‑uploaded EPS artwork.
 * 3. When integrating a command‑line tool that transforms EPS logos into printable raster formats in a CI pipeline.
 * 4. When converting EPS files to different image formats to ensure compatibility with legacy systems that only read raster images.
 * 5. When creating a simple utility to preview EPS graphics by exporting them to common image types in a Windows desktop app.
 */
