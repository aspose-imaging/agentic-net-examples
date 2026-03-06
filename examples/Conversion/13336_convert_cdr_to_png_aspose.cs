using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class CdrToPngConverter
{
    static void Main()
    {
        // Path to the source CDR file
        string inputCdrPath = @"C:\Images\sample.cdr";

        // Desired output PNG file path
        string outputPngPath = @"C:\Images\sample.png";

        // Load the CDR file using Aspose.Imaging
        using (Image image = Image.Load(inputCdrPath))
        {
            // Cast the loaded image to CdrImage to access CDR‑specific features
            CdrImage cdrImage = (CdrImage)image;

            // If the CDR document contains multiple pages, you can choose which page to export.
            // Here we export the first page (index 0).
            var page = (Aspose.Imaging.FileFormats.Cdr.CdrImagePage)cdrImage.Pages[0];

            // Define PNG saving options (default options are sufficient for basic conversion)
            PngOptions pngOptions = new PngOptions();

            // Save the selected page as a PNG image
            page.Save(outputPngPath, pngOptions);
        }

        Console.WriteLine("Conversion completed: " + outputPngPath);
    }
}