using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all TIFF files in the input directory
        string[] files = Directory.GetFiles(inputDir, "*.tif");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output PDF path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as PDF
                tiffImage.Save(outputPath, pdfOptions);
            }
        }
    }
}