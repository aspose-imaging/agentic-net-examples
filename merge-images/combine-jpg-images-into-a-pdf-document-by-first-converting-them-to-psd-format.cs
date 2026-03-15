using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files (replace with actual paths or pass via args)
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // List to hold generated PSD file paths
        List<string> psdPaths = new List<string>();

        // Convert each JPG to PSD
        foreach (string jpgPath in jpgPaths)
        {
            using (Image jpgImage = Image.Load(jpgPath))
            {
                string psdPath = Path.ChangeExtension(jpgPath, ".psd");

                // Set up PSD options with a file source
                PsdOptions psdOptions = new PsdOptions
                {
                    Source = new FileCreateSource(psdPath, false),
                    ColorMode = ColorModes.Rgb // Use RGB color mode
                };

                // Create a blank PSD canvas matching the JPG dimensions
                using (Image psdImage = Image.Create(psdOptions, jpgImage.Width, jpgImage.Height))
                {
                    // Draw the JPG onto the PSD canvas
                    Graphics graphics = new Graphics(psdImage);
                    graphics.DrawImage(jpgImage, 0, 0);

                    // Save the PSD (source is already bound)
                    psdImage.Save();
                }

                psdPaths.Add(psdPath);
            }
        }

        // Combine all PSD files into a single PDF document
        using (Image pdfDocument = Image.Create(psdPaths.ToArray()))
        {
            PdfOptions pdfOptions = new PdfOptions();
            pdfDocument.Save("CombinedOutput.pdf", pdfOptions);
        }

        // Optional: clean up temporary PSD files
        // foreach (string psdPath in psdPaths)
        // {
        //     File.Delete(psdPath);
        // }
    }
}