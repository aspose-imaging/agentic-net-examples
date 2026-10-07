// HOW-TO: Convert EPS to JPEG with sRGB Color Profile in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string iccProfilePath = "Input/sRGB.icc";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            using (FileStream iccStream = File.OpenRead(iccProfilePath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    RgbColorProfile = new StreamSource(iccStream)
                };

                epsImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑ready JPEG thumbnails from EPS artwork while ensuring the colors match the sRGB standard.
 * 2. When a printing workflow requires converting vector EPS files to raster JPEGs with an embedded sRGB ICC profile for consistent display on screens.
 * 3. When migrating legacy EPS assets to a JPEG gallery and you must replace the original color profile to avoid color shifts on different devices.
 * 4. When building an automated image‑processing pipeline that reads EPS logos, applies the sRGB profile, and saves them as JPEGs for use in mobile apps.
 * 5. When a client requests JPEG versions of EPS designs with a standardized color space to guarantee accurate color reproduction across browsers.
 */
