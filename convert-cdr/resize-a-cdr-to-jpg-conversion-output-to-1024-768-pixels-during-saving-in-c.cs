using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output/output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CDR image, resize, and save as JPEG
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Resize to 1024x768 pixels
            cdr.Resize(1024, 768);

            // JPEG save options
            JpegOptions jpegOptions = new JpegOptions();

            // Save the resized image as JPEG
            cdr.Save(outputPath, jpegOptions);
        }
    }
}