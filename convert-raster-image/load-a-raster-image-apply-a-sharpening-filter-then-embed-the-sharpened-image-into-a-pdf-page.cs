using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.pdf";

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
                // Cast to RasterImage to access filtering
                RasterImage raster = (RasterImage)image;

                // Apply sharpening filter to the whole image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Prepare PDF options
                var pdfOptions = new PdfOptions();

                // Save the sharpened image as a PDF page
                raster.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enhance the visual clarity of a PNG photograph by applying a sharpening filter and then embed the result directly into a PDF report using C# and Aspose.Imaging.
 * 2. When an application must automatically convert scanned raster images (e.g., JPEG or BMP) into searchable PDF pages after improving edge definition with a SharpenFilterOptions.
 * 3. When a document generation workflow requires preprocessing of product catalog images to sharpen details before packaging them as a single‑page PDF for printing.
 * 4. When a web service processes user‑uploaded screenshots, applies a high‑radius sharpen effect, and returns the edited image as a PDF attachment without intermediate file formats.
 * 5. When a desktop utility needs to batch‑process PNG assets, enhance their sharpness, and archive the results in PDF format for compliance or archival purposes.
 */