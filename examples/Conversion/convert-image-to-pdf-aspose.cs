using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class RasterToPdfConverter
{
    static void Main()
    {
        // Path to the source raster image (JPEG, PNG, BMP, etc.)
        string inputPath = "input.jpg";

        // Desired output PDF file path
        string outputPath = "output.pdf";

        // Load the raster image using Aspose.Imaging's built‑in Load method
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF save options – default settings are sufficient for a simple conversion
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed: " + outputPath);
    }
}