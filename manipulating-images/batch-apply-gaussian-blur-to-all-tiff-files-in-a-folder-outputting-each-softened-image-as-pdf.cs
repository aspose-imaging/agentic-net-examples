// HOW-TO: Batch Apply Gaussian Blur to TIFF Files and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            foreach (string inputPath in tiffFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;
                    tiffImage.Filter(tiffImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    tiffImage.Save(outputPath, new PdfOptions());
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
 * 1. When you need to soften a large collection of scanned TIFF documents before archiving them as searchable PDFs.
 * 2. When a printing workflow requires applying a uniform blur effect to all TIFF pages and delivering the result in PDF format for distribution.
 * 3. When automating the preparation of medical imaging TIFF files with a Gaussian blur to protect patient details before converting them to PDF reports.
 * 4. When a digital asset management system must batch‑process high‑resolution TIFF photographs, add a subtle blur, and store them as PDFs for web preview.
 * 5. When a compliance process mandates obscuring sensitive information in TIFF files by blurring and then converting them to PDF for secure storage.
 */
