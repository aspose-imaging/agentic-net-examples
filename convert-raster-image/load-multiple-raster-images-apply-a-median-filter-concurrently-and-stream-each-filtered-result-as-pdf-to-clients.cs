using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input files
        var inputFiles = new List<string>
        {
            @"C:\Images\image1.png",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.bmp"
        };

        // Hardcoded output directory
        var outputDir = @"C:\Output\Pdf\";

        Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output PDF path
            var outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image with concurrent processing enabled
            var loadOptions = new LoadOptions { ConcurrentImageProcessing = true };
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var rasterImage = (RasterImage)image;

                // Apply median filter (size 5) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save filtered image as PDF
                var pdfOptions = new PdfOptions();
                rasterImage.Save(outputPath, pdfOptions);
            }
        });
    }
}