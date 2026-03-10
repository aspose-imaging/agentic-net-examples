using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToPdfConverter
{
    static void Main()
    {
        // Path to the source TIFF file
        string sourcePath = @"C:\temp\input.tif";

        // Path for the output PDF file
        string outputPath = @"C:\temp\output.pdf";

        // Load the TIFF image using the Aspose.Imaging load rule
        using (Image tiffImage = Image.Load(sourcePath))
        {
            // Save the loaded image as PDF using the Aspose.Imaging save rule
            // PdfOptions can be instantiated with default settings
            tiffImage.Save(outputPath, new PdfOptions());
        }

        Console.WriteLine("TIFF has been successfully converted to PDF.");
    }
}