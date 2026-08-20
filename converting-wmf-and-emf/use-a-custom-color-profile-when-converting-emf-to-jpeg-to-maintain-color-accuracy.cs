// HOW-TO: Convert EMF to JPEG with Custom ICC Profiles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded paths
            string inputPath = @"C:\Temp\sample.emf";
            string outputPath = @"C:\Temp\output.jpg";
            string rgbProfilePath = @"C:\Temp\eciRGB_v2.icc";
            string cmykProfilePath = @"C:\Temp\ISOcoated_v2_FullGamut4.icc";

            // Validate input files
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(rgbProfilePath))
            {
                Console.Error.WriteLine($"File not found: {rgbProfilePath}");
                return;
            }
            if (!File.Exists(cmykProfilePath))
            {
                Console.Error.WriteLine($"File not found: {cmykProfilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare JPEG options with custom ICC profiles
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Use CMYK color mode to match the profiles
                    ColorType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionColorMode.Cmyk
                };

                // Open ICC profile streams
                using (FileStream rgbStream = File.OpenRead(rgbProfilePath))
                using (FileStream cmykStream = File.OpenRead(cmykProfilePath))
                {
                    jpegOptions.RgbColorProfile = new StreamSource(rgbStream);
                    jpegOptions.CmykColorProfile = new StreamSource(cmykStream);

                    // Save as JPEG with the custom profiles
                    emfImage.Save(outputPath, jpegOptions);
                }
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
 * 1. When you need to preserve exact brand colors while converting vector EMF graphics to JPEG for web publishing, you can embed custom RGB and CMYK ICC profiles using Aspose.Imaging in C#.
 * 2. When preparing print‑ready JPEG files from EMF artwork and must match a specific printing press color space, applying a CMYK ICC profile ensures color fidelity.
 * 3. When automating a batch conversion pipeline that processes legacy EMF files and requires consistent color management across different devices, you can load custom ICC profiles programmatically.
 * 4. When integrating image conversion into a C# desktop application that must comply with corporate color standards, using Aspose.Imaging’s JpegOptions with custom profiles guarantees compliance.
 * 5. When converting EMF diagrams to JPEG thumbnails for a digital asset management system while retaining accurate colors for scientific or medical illustrations, custom ICC profiles prevent color shifts.
 */
