// HOW-TO: Batch Convert EPS Files to PNG, JPG, PDF or TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add EPS files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
            if (epsFiles.Length == 0)
            {
                Console.WriteLine("No EPS files found in the Input directory.");
                return;
            }

            Console.WriteLine("Enter target format (png, jpg, pdf, tiff):");
            string format = Console.ReadLine()?.Trim().ToLower();

            foreach (string epsPath in epsFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epsPath);
                string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}.{format}");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EpsImage image = (EpsImage)Image.Load(epsPath))
                {
                    switch (format)
                    {
                        case "png":
                            using (var options = new PngOptions())
                            {
                                image.Save(outputPath, options);
                            }
                            break;
                        case "jpg":
                        case "jpeg":
                            using (var options = new JpegOptions())
                            {
                                image.Save(outputPath, options);
                            }
                            break;
                        case "pdf":
                            using (var options = new PdfOptions())
                            {
                                image.Save(outputPath, options);
                            }
                            break;
                        case "tiff":
                            using (var options = new TiffOptions(TiffExpectedFormat.Default))
                            {
                                image.Save(outputPath, options);
                            }
                            break;
                        default:
                            Console.WriteLine($"Unsupported format: {format}");
                            return;
                    }
                }

                Console.WriteLine($"Converted '{epsPath}' to '{outputPath}'.");
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
 * 1. When you need to let users select a folder of EPS artwork and automatically generate PNG, JPEG, PDF, or TIFF versions for web publishing.
 * 2. When a desktop application must convert multiple vector EPS logos into raster images for inclusion in a product catalog.
 * 3. When an automated build script has to transform EPS design files into PDF for print‑ready distribution without manual intervention.
 * 4. When a migration tool has to batch‑process legacy EPS diagrams into TIFF files for archival in a document management system.
 * 5. When a reporting service requires on‑the‑fly conversion of EPS charts to JPEG images for embedding in email summaries.
 */
