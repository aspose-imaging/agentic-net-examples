// HOW-TO: Embed Custom ICC Profile into JPEG2000 and Verify with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.jp2";
            string iccPath = "profile.icc";
            string outputPath = "output.jp2";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(iccPath))
            {
                Console.Error.WriteLine($"File not found: {iccPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG2000 image
            using (Jpeg2000Image jpeg2000Image = (Jpeg2000Image)Image.Load(inputPath))
            {
                // Open the ICC profile stream
                using (FileStream iccStream = File.OpenRead(iccPath))
                {
                    // Attempt to embed the ICC profile via reflection (if the property exists)
                    var rgbProp = jpeg2000Image.GetType().GetProperty("RgbColorProfile");
                    if (rgbProp != null && rgbProp.CanWrite)
                    {
                        rgbProp.SetValue(jpeg2000Image, new StreamSource(iccStream));
                    }
                }

                // Save the image with the embedded profile
                jpeg2000Image.Save(outputPath);
            }

            // Reload the saved image to confirm the ICC profile is retained
            using (Jpeg2000Image savedImage = (Jpeg2000Image)Image.Load(outputPath))
            {
                var rgbProp = savedImage.GetType().GetProperty("RgbColorProfile");
                if (rgbProp != null && rgbProp.CanRead)
                {
                    var profile = rgbProp.GetValue(savedImage) as StreamSource;
                    Console.WriteLine(profile != null ? "ICC profile retained." : "ICC profile not found.");
                }
                else
                {
                    Console.WriteLine("RgbColorProfile property not available on JPEG2000 image.");
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
 * 1. When you need to preserve accurate color management by embedding an ICC profile into a JPEG2000 file before distribution.
 * 2. When converting existing JPEG2000 assets to include a specific printer or display profile for consistent color across devices.
 * 3. When building a workflow that validates that the embedded ICC profile remains intact after saving or transmitting the image.
 * 4. When integrating Aspose.Imaging into a C# application that must attach custom color profiles to medical or archival JPEG2000 images.
 * 5. When automating batch processing of JPEG2000 images to ensure each file contains the required ICC profile for compliance with publishing standards.
 */
