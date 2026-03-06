using System;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Path to the source PNG file
        string pngPath = "input.png";

        // Desired path for the resulting PDF file
        string pdfPath = "output.pdf";

        // Load the PNG image using the PngImage constructor (load rule)
        using (PngImage pngImage = new PngImage(pngPath))
        {
            // Save the image as PDF. The Save(string) overload determines the format
            // from the file extension, so providing a .pdf path converts the image.
            pngImage.Save(pdfPath); // save rule
        }

        Console.WriteLine("Conversion completed: " + pdfPath);
    }
}