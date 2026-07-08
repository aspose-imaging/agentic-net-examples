using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX path and output format argument
            string inputPath = args[0];               // CMX file path
            string outputFormat = args[1];            // e.g., "jpg", "png", "pdf", etc.

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output file path
            string outputDirectory = Path.Combine("Output");
            string outputFileName = $"output.{outputFormat.ToLower()}";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options common to raster formats
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Choose appropriate save options based on requested format
                switch (outputFormat.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                        var jpegOptions = new JpegOptions();
                        jpegOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, jpegOptions);
                        break;

                    case "png":
                        var pngOptions = new PngOptions();
                        pngOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, pngOptions);
                        break;

                    case "bmp":
                        var bmpOptions = new BmpOptions();
                        bmpOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, bmpOptions);
                        break;

                    case "gif":
                        var gifOptions = new GifOptions();
                        gifOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, gifOptions);
                        break;

                    case "tif":
                    case "tiff":
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, tiffOptions);
                        break;

                    case "webp":
                        var webpOptions = new WebPOptions();
                        webpOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, webpOptions);
                        break;

                    case "pdf":
                        var pdfOptions = new PdfOptions();
                        pdfOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, pdfOptions);
                        break;

                    default:
                        // Fallback to JPEG for unsupported formats
                        var fallbackOptions = new JpegOptions();
                        fallbackOptions.VectorRasterizationOptions = vectorOptions;
                        image.Save(outputPath, fallbackOptions);
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
 * 1. When a printing company needs to batch‑convert legacy CorelDRAW CMX artwork into JPEG or PNG files for web preview, they can run this C# console utility with the CMX path and desired output format as arguments.
 * 2. When an automated build pipeline must generate PDF documentation from CMX source files to embed in reports, the program can be invoked to rasterize the vector image and save it as a PDF using Aspose.Imaging.
 * 3. When a digital asset management system receives CMX uploads and must store thumbnails in BMP or GIF format for quick browsing, developers can call this console app to produce the required raster images on the fly.
 * 4. When a Windows service processes incoming CMX files and needs to convert them to WebP for optimized delivery over the internet, the code provides a simple C# command‑line interface to perform the conversion.
 * 5. When a QA test script validates that CMX files render correctly across multiple raster formats, the utility can be scripted to convert each CMX to TIFF, JPEG, PNG, etc., and compare the output images programmatically.
 */