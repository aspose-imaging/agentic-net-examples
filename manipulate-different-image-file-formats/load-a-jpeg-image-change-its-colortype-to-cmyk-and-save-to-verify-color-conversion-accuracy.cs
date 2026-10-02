// HOW-TO: Convert JPEG to CMYK Color Space in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\sample.jpg";
                string outputPath = "Output\\sample_cmyk.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions options = new JpegOptions())
                    {
                        options.ColorType = JpegCompressionColorMode.Cmyk;
                        image.Save(outputPath, options);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When preparing images for professional printing, you may need to convert RGB JPEG files to CMYK to ensure accurate color reproduction.
 * 2. When integrating a C# web service that generates print‑ready assets, you can use this code to change the JPEG color mode to CMYK before delivering the file.
 * 3. When migrating a legacy catalog of JPEG photos to a workflow that requires CMYK color profiles, the snippet automates the batch conversion.
 * 4. When validating that a JPEG image meets a printer’s CMYK specifications, you can load the file, set the color type, and save it to verify the conversion.
 * 5. When building a desktop application that lets users export their photos for offset printing, this example shows how to switch the JPEG’s color space using Aspose.Imaging in .NET.
 */
