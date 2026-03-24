using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG and output DICOM paths
        string inputPath = "input.jpg";
        string outputPath = "output.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare DICOM options (store as RGB 24‑bit, no compression)
            var dicomOptions = new DicomOptions
            {
                ColorType = ColorType.Rgb24Bit
            };

            // Save the image inside a DICOM container
            image.Save(outputPath, dicomOptions);
        }
    }
}