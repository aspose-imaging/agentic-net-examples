using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.tif");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    // Apply Gaussian blur with radius 5 and sigma 4.0
                    tiffImage.Filter(tiffImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        tiffImage.Save(outputPath, pdfOptions);
                    }
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
 * 1. When a developer must automatically soften the edges of scanned TIFF documents using a Gaussian blur filter and convert each file to a PDF for secure archival in a corporate records system.
 * 2. When an imaging workflow requires batch processing of high‑resolution TIFF images to reduce visual noise before generating PDF reports for a medical imaging department.
 * 3. When a software solution needs to apply a consistent blur radius to a folder of TIFF maps and output them as PDFs for easy distribution to field engineers.
 * 4. When a document management application must programmatically convert a batch of TIFF invoices into PDF format while applying a Gaussian blur to protect sensitive details.
 * 5. When a C# utility is needed to streamline the preparation of TIFF‑based marketing assets by applying a blur effect and saving the results as PDFs for client review.
 */