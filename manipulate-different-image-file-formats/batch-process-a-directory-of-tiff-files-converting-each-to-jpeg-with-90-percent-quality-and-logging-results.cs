// HOW-TO: Batch Convert TIFF Files to JPEG with 90% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                {
                    continue;
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Quality = 90;
                        image.Save(outputPath, jpegOptions);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically shrink a folder of high‑resolution TIFF scans into web‑friendly JPEGs for faster page loads.
 * 2. When a document‑management system must archive incoming TIFF images as compressed JPEGs while preserving filenames.
 * 3. When a photo‑processing pipeline has to convert multi‑page TIFFs to single‑page JPEGs with a specific quality setting for consistent output.
 * 4. When you want to generate JPEG previews of TIFF assets in a batch job and log each conversion for audit purposes.
 * 5. When a Windows service processes scanned invoices stored as TIFF and creates lower‑size JPEG copies for email attachment.
 */
