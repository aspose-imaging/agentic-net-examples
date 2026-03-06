using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        const string sourcePath = "input.apng";

        // Path for the resulting PDF file
        const string outputPath = "output.pdf";

        // Load the APNG image (raster image with animation frames)
        using (Image apngImage = Image.Load(sourcePath))
        {
            // Save the loaded image as PDF.
            // PdfOptions is used to specify PDF-specific saving parameters.
            // If you need to customize options (e.g., compression, page size), configure them here.
            apngImage.Save(outputPath, new PdfOptions());
        }
    }
}