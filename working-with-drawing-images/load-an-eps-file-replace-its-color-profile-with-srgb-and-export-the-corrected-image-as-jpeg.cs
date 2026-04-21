using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS, output JPEG, and sRGB ICC profile paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";
        string srgbProfilePath = "sRGB.icc";

        // Verify input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify sRGB ICC profile file exists
        if (!File.Exists(srgbProfilePath))
        {
            Console.Error.WriteLine($"File not found: {srgbProfilePath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the sRGB ICC profile stream
        using (var rgbProfileStream = File.OpenRead(srgbProfilePath))
        {
            // Prepare JPEG save options with the sRGB profile
            var jpegOptions = new JpegOptions
            {
                RgbColorProfile = new StreamSource(rgbProfileStream)
            };

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Save the image as JPEG using the specified options
                epsImage.Save(outputPath, jpegOptions);
            }
        }
    }
}