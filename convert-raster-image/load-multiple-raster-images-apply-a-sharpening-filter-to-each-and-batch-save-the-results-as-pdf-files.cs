using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input files
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.png",
                @"C:\Images\sample2.jpg",
                @"C:\Images\sample3.tif"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (will be called for each file)
            Directory.CreateDirectory(outputDirectory);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpening filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the processed image as PDF
                    rasterImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}