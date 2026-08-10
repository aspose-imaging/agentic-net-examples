// HOW-TO: Apply ICC Color Profile to OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.otg";
            string iccProfilePath = "Input/profile.icc";
            string tempJpegPath = "Output/temp.jpg";
            string outputPath = "Output/output.png";

            // Validate input OTG file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Validate ICC profile file
            if (!File.Exists(iccProfilePath))
            {
                Console.Error.WriteLine($"File not found: {iccProfilePath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare JPEG options with the ICC profile
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Use the ICC profile for RGB conversion
                    RgbColorProfile = new StreamSource(File.OpenRead(iccProfilePath))
                };

                // Save as a temporary JPEG to embed the ICC profile
                otgImage.Save(tempJpegPath, jpegOptions);
            }

            // Load the temporary JPEG (now containing the ICC profile)
            using (Image jpegImage = Image.Load(tempJpegPath))
            {
                // Prepare PNG options
                PngOptions pngOptions = new PngOptions
                {
                    // No specific ICC handling for PNG; the color data is already transformed
                };

                // Save the final PNG image
                jpegImage.Save(outputPath, pngOptions);
            }

            // Optionally delete the temporary JPEG file
            if (File.Exists(tempJpegPath))
            {
                File.Delete(tempJpegPath);
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
 * 1. When you need to embed a specific ICC color profile into an OTG graphic before converting it to a PNG for accurate color reproduction on the web.
 * 2. When a workflow requires converting proprietary OTG files to PNG while preserving the source color space using a custom ICC profile.
 * 3. When you must generate PNG thumbnails from OTG images that match a brand’s color standards defined in an ICC profile.
 * 4. When automating batch processing of OTG assets, you need to apply a corporate ICC profile and output PNG files for cross‑platform compatibility.
 * 5. When integrating Aspose.Imaging into a C# application to ensure OTG images retain correct color when saved as PNG for printing or publishing.
 */
