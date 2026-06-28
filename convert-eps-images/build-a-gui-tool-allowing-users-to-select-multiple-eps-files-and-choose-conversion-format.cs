using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            if (epsFiles.Length == 0)
            {
                Console.WriteLine("No EPS files found in the Input directory.");
                return;
            }

            // Ask user for desired output format
            Console.WriteLine("Select output format (png/jpg/bmp/gif/tiff/pdf/webp):");
            string format = Console.ReadLine()?.Trim().ToLowerInvariant();

            foreach (string inputPath in epsFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputExtension;
                ImageOptionsBase options;

                switch (format)
                {
                    case "png":
                        outputExtension = "png";
                        options = new PngOptions();
                        break;
                    case "jpg":
                    case "jpeg":
                        outputExtension = "jpg";
                        options = new JpegOptions();
                        break;
                    case "bmp":
                        outputExtension = "bmp";
                        options = new BmpOptions();
                        break;
                    case "gif":
                        outputExtension = "gif";
                        options = new GifOptions();
                        break;
                    case "tiff":
                        outputExtension = "tiff";
                        options = new TiffOptions(TiffExpectedFormat.Default);
                        break;
                    case "pdf":
                        outputExtension = "pdf";
                        options = new PdfOptions();
                        break;
                    case "webp":
                        outputExtension = "webp";
                        options = new WebPOptions();
                        break;
                    default:
                        Console.WriteLine($"Unsupported format '{format}'. Skipping file {inputPath}.");
                        continue;
                }

                string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}.{outputExtension}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image and save in chosen format
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When a developer needs to build a Windows desktop tool that lets graphic designers batch‑convert EPS artwork into PNG, JPEG, BMP, GIF, TIFF, PDF, or WebP for web publishing or print workflows.
 * 2. When a developer wants to integrate Aspose.Imaging into a C# utility that automatically scans a folder, reads multiple EPS files and outputs them in a user‑selected raster format for inclusion in a content‑management system.
 * 3. When a developer must provide a simple UI for marketing teams to select several EPS logos and export them as high‑resolution TIFF or PDF files for brand‑compliant collateral.
 * 4. When a developer is creating a file‑conversion service that receives EPS uploads, lets end‑users pick the desired output format, and uses Aspose.Imaging to generate the corresponding PNG, JPG or WebP images for responsive web design.
 * 5. When a developer needs to implement batch image processing in a .NET application that validates EPS file existence, applies Aspose.Imaging options, and saves the results with appropriate extensions for downstream automation scripts.
 */