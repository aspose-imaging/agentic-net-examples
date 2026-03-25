using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Prepare JPEG save options (default settings)
            JpegOptions jpegOptions = new JpegOptions();

            // Save as JPEG; ExifData (including orientation) is preserved automatically
            cmxImage.Save(outputPath, jpegOptions);
        }
    }
}