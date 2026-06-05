using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            var allFiles = tiffFiles.Concat(tiffFilesAlt).ToArray();

            foreach (var inputPath in allFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;
                    tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
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
 * 1. When a developer needs to automatically soften scanned documents stored as TIFF files and deliver them as searchable PDF reports.
 * 2. When a batch processing pipeline must apply a Gaussian blur filter to multiple TIFF images before converting them to PDF for archival purposes.
 * 3. When an application has to convert a folder of high‑resolution TIFF scans into PDF while reducing visual noise with a 5‑pixel radius blur.
 * 4. When a document management system requires a C# routine that reads *.tif and *.tiff files, blurs them, and saves each result as a PDF in an output directory.
 * 5. When a developer wants to streamline the workflow of preparing scanned forms by applying Gaussian blur to each TIFF and exporting the softened images as PDFs for easy distribution.
 */