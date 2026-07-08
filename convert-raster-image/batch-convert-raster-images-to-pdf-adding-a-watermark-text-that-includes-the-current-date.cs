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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to generate PDF reports from a folder of scanned JPEG or TIFF documents and embed the current date as a watermark to prove the report’s issuance time.
 * 2. When an e‑commerce platform must automatically convert product photos (PNG, BMP) into PDF catalogs each night while stamping the generation date for version control using Aspose.Imaging for .NET.
 * 3. When a legal firm wants to archive client‑submitted images as PDF evidence files, adding a date watermark to satisfy chain‑of‑custody requirements.
 * 4. When a medical imaging system needs to batch export radiology images (converted to PNG) to PDF for patient records, with the service date displayed as a watermark.
 * 5. When a marketing team creates printable PDFs from campaign graphics and wants the current date watermarked to track the latest design version during iterative reviews.
 */