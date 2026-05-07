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
        // Hard‑coded input EPS, output JPEG and sRGB ICC profile paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";
        string iccProfilePath = "sRGB.icc";

        // Verify input EPS exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify ICC profile exists
        if (!File.Exists(iccProfilePath))
        {
            Console.Error.WriteLine($"File not found: {iccProfilePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Open the sRGB ICC profile stream
                using (Stream iccStream = File.OpenRead(iccProfilePath))
                {
                    // Prepare JPEG save options with the sRGB profile
                    var jpegOptions = new JpegOptions
                    {
                        // Assign the RGB color profile for correct color conversion
                        RgbColorProfile = new StreamSource(iccStream)
                    };

                    // Save the image as JPEG using the specified options
                    epsImage.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}