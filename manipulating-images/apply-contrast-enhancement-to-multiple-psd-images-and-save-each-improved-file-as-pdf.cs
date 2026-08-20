// HOW-TO: Batch Adjust Contrast of PSD Files and Save as PDFs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.psd");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Adjust contrast using dynamic to accommodate PSD images
                    dynamic dynImage = image;
                    dynImage.AdjustContrast(30f);

                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to improve the visual clarity of a collection of Photoshop PSD files before distributing them as printable PDFs.
 * 2. When an automated workflow must process dozens of layered PSD assets, increase their contrast, and generate PDF versions for client review.
 * 3. When a web service converts user‑uploaded PSD designs to high‑contrast PDFs for faster preview loading in browsers.
 * 4. When a desktop application prepares marketing materials by batch‑enhancing PSD images and exporting them to PDF for easy sharing.
 * 5. When a migration script updates legacy PSD artwork, applies contrast correction, and stores the results in PDF format for archival purposes.
 */
