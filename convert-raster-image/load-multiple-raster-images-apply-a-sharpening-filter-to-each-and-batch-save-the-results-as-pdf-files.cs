using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image paths
        string[] inputFiles = new string[]
        {
            @"C:\Images\image1.png",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.bmp"
        };

        foreach (var inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PDF path (same folder, same name with .pdf extension)
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply sharpen filter to the whole image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Set up PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as PDF
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}