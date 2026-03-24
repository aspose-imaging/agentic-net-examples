using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions; // for CmxLoadOptions
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image with default load options
        var loadOptions = new CmxLoadOptions();
        using (CmxImage image = (CmxImage)Image.Load(inputPath, loadOptions))
        {
            // Prepare JPEG save options (default quality)
            var jpegOptions = new JpegOptions();

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}