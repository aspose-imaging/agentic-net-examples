using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input CMX file path
        string inputPath = @"C:\Images\sample.cmx";
        // Desired output file path (PNG format in this example)
        string outputPath = @"C:\Images\sample_converted.png";

        // Load the CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Save the image in the target format using appropriate options
            cmxImage.Save(outputPath, new PngOptions());
        }
    }
}