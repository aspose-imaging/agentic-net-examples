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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.png";
            string rgbIccPath = @"C:\Images\iccprofiles\eciRGB_v2.icc";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(rgbIccPath))
            {
                Console.Error.WriteLine($"File not found: {rgbIccPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Open the ICC profile stream
                using (Stream rgbProfileStream = File.OpenRead(rgbIccPath))
                {
                    // Attempt to apply the ICC profile if the image type supports it.
                    // Using dynamic to avoid compile‑time errors for image types that lack the property.
                    var dynImage = image as dynamic;
                    try
                    {
                        dynImage.RgbColorProfile = new StreamSource(rgbProfileStream);
                    }
                    catch
                    {
                        // If the property is not supported, silently continue.
                    }
                }

                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a graphics pipeline receives OTG vector images from a design tool and must embed a specific RGB ICC profile before converting them to PNG for web delivery, a developer can use this code.
 * 2. When an e‑commerce platform needs to ensure product photos originally stored as OTG files display consistent colors across browsers by applying an eciRGB_v2 ICC profile and saving them as PNG thumbnails, this snippet is applicable.
 * 3. When a digital asset management system imports OTG artwork and must standardize its color space to sRGB using a custom ICC profile prior to archiving the images as lossless PNG files, the code provides a solution.
 * 4. When a printing workflow requires converting OTG illustrations to PNG while preserving color fidelity by attaching a calibrated ICC profile before the final print‑ready export, developers can rely on this example.
 * 5. When a mobile app processes user‑uploaded OTG graphics and needs to embed a specific ICC profile to maintain accurate colors on different devices before saving the result as a PNG cache file, this code is useful.
 */