using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "C:\\InputPngs";
        string outputDirectory = "C:\\OutputPdfs";

        // Validate input directory existence
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory does not exist: {inputDirectory}");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string filePath in files)
        {
            // Process only PNG files (case‑insensitive)
            if (!filePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify the input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Determine output PDF path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

            // Ensure the output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image, apply median filter, and save as PDF
            using (Image image = Image.Load(filePath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply median filter with a kernel size of 5
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                // Save the filtered image as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}