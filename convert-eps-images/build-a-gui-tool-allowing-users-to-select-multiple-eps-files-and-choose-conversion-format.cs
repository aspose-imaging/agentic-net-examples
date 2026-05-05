using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add EPS files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
            if (epsFiles.Length == 0)
            {
                Console.WriteLine("No EPS files found in the Input directory.");
                return;
            }

            // Prompt user for target format
            Console.WriteLine("Enter target format (png, jpg, pdf, bmp, gif, webp, tiff):");
            string format = Console.ReadLine()?.Trim().ToLower();

            foreach (string inputPath in epsFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + GetExtension(format));

                // Ensure output directory exists for this file
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image and save in the chosen format
                using (Image image = Image.Load(inputPath))
                {
                    switch (format)
                    {
                        case "png":
                            image.Save(outputPath, new PngOptions());
                            break;
                        case "jpg":
                        case "jpeg":
                            image.Save(outputPath, new JpegOptions());
                            break;
                        case "pdf":
                            image.Save(outputPath, new PdfOptions());
                            break;
                        case "bmp":
                            image.Save(outputPath, new BmpOptions());
                            break;
                        case "gif":
                            image.Save(outputPath, new GifOptions());
                            break;
                        case "webp":
                            image.Save(outputPath, new WebPOptions());
                            break;
                        case "tiff":
                            image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                            break;
                        default:
                            Console.WriteLine($"Unsupported format: {format}");
                            return;
                    }
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper to map format string to file extension
    static string GetExtension(string format)
    {
        switch (format)
        {
            case "png": return ".png";
            case "jpg":
            case "jpeg": return ".jpg";
            case "pdf": return ".pdf";
            case "bmp": return ".bmp";
            case "gif": return ".gif";
            case "webp": return ".webp";
            case "tiff": return ".tiff";
            default: return "";
        }
    }
}