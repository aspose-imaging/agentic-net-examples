using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpgToPdfViaPsd
{
    static void Main()
    {
        // Input JPG file path
        string jpgPath = @"C:\Images\sample.jpg";

        // Temporary PSD file path
        string psdPath = @"C:\Images\sample.psd";

        // Output PDF file path
        string pdfPath = @"C:\Images\sample.pdf";

        // Load the JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Create PSD save options
            PsdOptions psdOptions = new PsdOptions
            {
                // Example: use RLE compression (optional)
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                // Example: set color mode to RGB (optional)
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
            };

            // Save the JPG as a PSD file
            jpgImage.Save(psdPath, psdOptions);
        }

        // Load the generated PSD image
        using (Image psdImage = Image.Load(psdPath))
        {
            // Save the PSD directly as PDF.
            // Aspose.Imaging can infer the format from the file extension.
            // No special PDF options are required for a simple conversion.
            psdImage.Save(pdfPath);
        }

        // Optional: clean up the intermediate PSD file
        if (File.Exists(psdPath))
        {
            File.Delete(psdPath);
        }

        Console.WriteLine("JPG has been merged into PDF via PSD format successfully.");
    }
}