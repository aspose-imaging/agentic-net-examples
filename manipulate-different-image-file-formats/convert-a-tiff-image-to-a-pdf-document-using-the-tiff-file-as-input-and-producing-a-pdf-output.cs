using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source TIFF file
        string inputPath = "input.tif";

        // Desired path for the resulting PDF file
        string outputPath = "output.pdf";

        // Load the TIFF image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Save the loaded image as a PDF document using the save rule
            image.Save(outputPath, new PdfOptions());
        }
    }
}