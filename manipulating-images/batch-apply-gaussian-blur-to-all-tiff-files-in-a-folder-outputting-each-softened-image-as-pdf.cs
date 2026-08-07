using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.tif");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    tiffImage.Filter(tiffImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

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
 * 1. When a developer needs to automatically soften scanned document pages stored as TIFF files and deliver them as searchable PDF reports for an archival system.
 * 2. When a medical imaging application must apply a Gaussian blur to a batch of high‑resolution TIFF X‑ray images before converting them to PDF for secure transmission.
 * 3. When an e‑commerce platform wants to generate PDF catalogs from product photography saved as TIFF, applying a subtle blur to hide background details.
 * 4. When a legal firm requires a script that processes all TIFF evidence files in a folder, blurs sensitive information with a Gaussian filter, and saves each file as a PDF for courtroom presentation.
 * 5. When a GIS tool needs to batch convert geospatial TIFF layers into PDF maps while applying a Gaussian blur to reduce noise in the final documents.
 */