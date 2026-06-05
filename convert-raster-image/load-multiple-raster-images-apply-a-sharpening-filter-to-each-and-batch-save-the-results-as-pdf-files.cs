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
            // Hardcoded input and output file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.png",
                @"C:\Images\image2.jpg",
                @"C:\Images\image3.tif"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Output\image1.pdf",
                @"C:\Output\image2.pdf",
                @"C:\Output\image3.pdf"
            };

            // Process each image
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Set up PDF save options
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