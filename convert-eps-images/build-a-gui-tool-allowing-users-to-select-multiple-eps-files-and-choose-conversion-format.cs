// HOW-TO: Batch Convert EPS Files to PNG JPG or PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            if (epsFiles.Length == 0)
            {
                Console.WriteLine("No EPS files found in the Input directory.");
                return;
            }

            // Prompt user for target format
            Console.WriteLine("Enter target format (png, jpg, pdf):");
            string format = Console.ReadLine()?.Trim().ToLower();

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path based on selected format
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string extension = format == "jpg" ? "jpg" : format;
                string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}.{extension}");

                // Ensure output directory exists
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
                        default:
                            Console.WriteLine($"Unsupported format: {format}");
                            return;
                    }
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
 * 1. When a developer needs a desktop tool that lets users pick multiple EPS files and export them as PNG, JPEG, or PDF for web or print distribution.
 * 2. When an automated build process must batch‑convert a directory of EPS graphics into raster images to embed them in a reporting dashboard.
 * 3. When a branding workflow requires converting EPS logos into various image formats to satisfy client specifications across different platforms.
 * 4. When a migration utility has to transform legacy EPS artwork into PDF documents for long‑term archival and compliance.
 * 5. When a C# application must generate preview thumbnails from EPS files in several formats for a file‑management user interface.
 */
