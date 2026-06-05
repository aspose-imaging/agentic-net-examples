using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded directories for input WebP files and output PDF files
            string inputDir = @"C:\Images\WebP";
            string outputDir = @"C:\Images\Pdf";

            // List of WebP files to process (hardcoded)
            string[] files = new string[]
            {
                "image1.webp",
                "image2.webp",
                "image3.webp"
                // Add more file names as needed
            };

            foreach (var fileName in files)
            {
                // Build full input path and verify existence
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build full output path (PDF) and ensure its directory exists
                string outputFileName = Path.ChangeExtension(fileName, ".pdf");
                string outputPath = Path.Combine(outputDir, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Record memory usage before conversion
                long memoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;

                // Load WebP image and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }

                // Record memory usage after conversion
                long memoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;
                long diffKB = (memoryAfter - memoryBefore) / 1024;

                Console.WriteLine($"Converted {fileName}: Memory before={memoryBefore / 1024}KB, after={memoryAfter / 1024}KB, diff={diffKB}KB");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}