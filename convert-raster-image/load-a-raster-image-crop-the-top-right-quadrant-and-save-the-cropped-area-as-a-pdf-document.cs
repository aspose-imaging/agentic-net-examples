// HOW-TO: Crop Top Right Quadrant of Image and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
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
                RasterImage raster = (RasterImage)image;

                // Define the top‑right quadrant rectangle
                int rectX = raster.Width / 2;          // start at middle of width
                int rectY = 0;                         // top edge
                int rectWidth = raster.Width / 2;      // half the width
                int rectHeight = raster.Height / 2;    // half the height
                Rectangle cropArea = new Rectangle(rectX, rectY, rectWidth, rectHeight);

                // Crop the image to the defined rectangle
                raster.Crop(cropArea);

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the cropped image as a PDF document
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
 * 1. When you need to extract the top‑right quarter of a PNG screenshot and embed it in a PDF report.
 * 2. When generating a PDF preview of a specific region of a scanned raster image for a document management system.
 * 3. When creating printable PDF handouts that contain only the upper‑right portion of a large product photo.
 * 4. When automating the conversion of a selected image quadrant into a PDF for use in e‑learning slide decks.
 * 5. When developing a web service that returns a PDF containing a cropped area of an uploaded raster image for client‑side display.
 */
