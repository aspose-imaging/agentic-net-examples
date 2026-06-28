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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Resize to 200x200 pixels
                raster.Resize(200, 200);

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as PDF
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
 * 1. When generating thumbnail previews of uploaded PNG images for a web portal, a developer can load the raster image, apply a Gaussian blur for a soft focus effect, resize it to 200 × 200 pixels, and export it as a PDF to embed in reports.
 * 2. When creating PDF catalogs that include small preview images of product photos, a developer can use this code to read the original PNG, blur it slightly to reduce visual noise, resize it to a uniform 200 × 200 size, and save it as a PDF page.
 * 3. When automating the conversion of scanned documents stored as PNG files into searchable PDF thumbnails, a developer can apply a Gaussian blur to smooth edges, resize the image, and output a PDF for quick preview in document management systems.
 * 4. When building a C# desktop application that generates PDF receipts with a blurred logo thumbnail, a developer can load the logo PNG, apply a Gaussian blur, resize it to 200 × 200, and embed it directly as a PDF image.
 * 5. When preparing image assets for an e‑learning platform that requires 200 × 200 pixel PDF thumbnails with a subtle blur effect, a developer can use this code to process each PNG and export the result as a PDF file.
 */