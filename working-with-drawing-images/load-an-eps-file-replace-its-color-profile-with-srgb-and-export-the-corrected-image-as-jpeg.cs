using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input EPS file path
        string inputPath = @"C:\Images\sample.eps";

        // Hard‑coded output JPEG file path
        string outputPath = @"C:\Images\sample_converted.jpg";

        // Path to the sRGB ICC profile file
        string iccProfilePath = @"C:\Images\sRGB.icc";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify that the ICC profile file exists
        if (!File.Exists(iccProfilePath))
        {
            Console.Error.WriteLine($"ICC profile not found: {iccProfilePath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Prepare JPEG save options with the sRGB color profile
            var jpegOptions = new JpegOptions();

            // Assign the sRGB ICC profile as the destination RGB profile
            using (FileStream iccStream = File.OpenRead(iccProfilePath))
            {
                jpegOptions.RgbColorProfile = new StreamSource(iccStream);
            }

            // Save the image as JPEG using the specified options
            epsImage.Save(outputPath, jpegOptions);
        }
    }
}