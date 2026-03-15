using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source DICOM file.
        string inputPath = "input.dcm";

        // Desired output raster file path (PNG format in this example).
        string outputPath = "output.png";

        // Load the DICOM image.
        using (Image image = Image.Load(inputPath))
        {
            // Convert and save the image to the raster format.
            image.Save(outputPath, new PngOptions());
        }
    }
}