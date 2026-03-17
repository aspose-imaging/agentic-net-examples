using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToPdfConverter
{
    static void Main()
    {
        // Path to the source TIFF file
        string tiffPath = @"C:\Temp\input.tif";

        // Desired output PDF file path
        string pdfPath = @"C:\Temp\output.pdf";

        // Load the TIFF image using Aspose.Imaging's load rule
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Save the loaded image as PDF using the save rule with PdfOptions
            tiffImage.Save(pdfPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}