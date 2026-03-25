using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of input raster images
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.png",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.bmp"
        };

        // Hardcoded output directory for PDF files
        string outputDir = @"C:\Images\Output";

        // Ensure the output directory exists (unconditional as required)
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputPaths)
        {
            // Verify that the input file exists; report and exit on missing file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the corresponding PDF output path
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter to the entire image bounds
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Prepare PDF save options (default settings)
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as a PDF file
                rasterImage.Save(outputPath, pdfOptions);
            }
        }
    }
}