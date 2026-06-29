using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access cropping functionality
                RasterImage rasterImage = (RasterImage)image;

                // Define the top‑right quadrant rectangle
                int halfWidth = rasterImage.Width / 2;
                int halfHeight = rasterImage.Height / 2;
                Rectangle topRight = new Rectangle(halfWidth, 0, halfWidth, halfHeight);

                // Crop the image to the defined rectangle
                rasterImage.Crop(topRight);

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the cropped image as a PDF document
                rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When generating a PDF report that only needs the top‑right portion of a scanned PNG diagram, a developer can load the raster image, crop the quadrant, and save it as a PDF using Aspose.Imaging for .NET.
 * 2. When creating thumbnails for a web portal that display only the upper‑right corner of product photos, the code can crop the PNG and output a PDF for consistent document rendering.
 * 3. When extracting a specific region from a large satellite PNG image for inclusion in a GIS PDF map, a developer can use this snippet to isolate the top‑right quadrant and save it directly as a PDF.
 * 4. When automating the conversion of user‑uploaded PNG signatures to PDF files that contain only the signature area located in the top‑right corner, the code provides a quick C# solution.
 * 5. When preparing printable PDF handouts that require only the top‑right section of a scanned form to be shown, the developer can employ this routine to crop the raster image and generate the PDF in one step.
 */