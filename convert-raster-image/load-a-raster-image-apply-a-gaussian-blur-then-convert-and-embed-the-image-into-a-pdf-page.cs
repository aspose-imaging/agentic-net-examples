using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities.
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image.
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PDF export options.
                PdfOptions pdfOptions = new PdfOptions();

                // Save the blurred image directly as a PDF page.
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime exception message without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}