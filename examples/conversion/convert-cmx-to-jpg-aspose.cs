using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class CmxToJpgConverter
{
    static void Main()
    {
        // Path to the source CMX file
        string inputFile = @"C:\Images\sample.cmx";

        // Desired output JPG file path
        string outputFile = @"C:\Images\sample.jpg";

        // Load the CMX image using Aspose.Imaging's unified loader
        using (Image cmxImage = Image.Load(inputFile))
        {
            // Configure JPEG saving options (optional: set quality, etc.)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90 // Set JPEG quality (0-100)
            };

            // Save the loaded CMX image as a JPEG file
            cmxImage.Save(outputFile, jpegOptions);
        }

        Console.WriteLine("Conversion completed: " + outputFile);
    }
}