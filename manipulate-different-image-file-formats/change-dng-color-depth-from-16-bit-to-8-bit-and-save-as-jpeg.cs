using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "c:\\temp\\input.dng";
        string outputPath = "c:\\temp\\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            DngImage dngImage = (DngImage)image;

            // Configure JPEG options for 8‑bit per channel output
            JpegOptions jpegOptions = new JpegOptions
            {
                BitsPerChannel = 8,      // target 8‑bit depth
                Quality = 100,           // maximum quality
                ColorType = JpegCompressionColorMode.YCbCr // standard JPEG color mode
            };

            // Save as JPEG
            dngImage.Save(outputPath, jpegOptions);
        }
    }
}