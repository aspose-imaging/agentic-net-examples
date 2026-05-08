using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.bmp",
                @"C:\Images\image2.bmp",
                @"C:\Images\image3.bmp"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Output";

            // Ensure the output directory exists (rule 3)
            Directory.CreateDirectory(outputDirectory);

            // Process each BMP file concurrently
            Parallel.ForEach(inputPaths, inputPath =>
            {
                // Verify input file exists (rule 2)
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply median filter with size 5 to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare PDF output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists (rule 3)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                    // Set PDF options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the filtered image as PDF
                    image.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}