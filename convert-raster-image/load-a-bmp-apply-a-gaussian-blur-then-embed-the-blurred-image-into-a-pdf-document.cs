using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "blurred.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Cast to raster image for processing
                RasterImage raster = (RasterImage)bmpImage;

                // Apply Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PDF options with file creation source
                PdfOptions pdfOptions = new PdfOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create PDF canvas matching blurred image size
                using (Image pdfImage = Image.Create(pdfOptions, raster.Width, raster.Height))
                {
                    // Draw the blurred raster image onto the PDF page
                    Graphics graphics = new Graphics(pdfImage);
                    graphics.DrawImage(raster, new Rectangle(0, 0, raster.Width, raster.Height));

                    // Save the PDF document
                    pdfImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}