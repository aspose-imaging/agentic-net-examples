using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\sample.cmyk.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options for CMYK color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Cmyk
                };

                // Save the image with CMYK conversion
                image.Save(outputPath, saveOptions);
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
 * 1. When a printing workflow requires converting RGB JPEG files to CMYK before sending them to a commercial press, a developer can use this code to load the JPEG, change its ColorType to CMYK, and save the result for accurate color reproduction.
 * 2. When validating that a third‑party design tool correctly exports images in CMYK color space, a developer can run this snippet to load the exported JPEG, force a CMYK conversion with Aspose.Imaging, and compare the saved file against the original.
 * 3. When building a batch‑processing service that prepares web‑ready images for color‑managed PDF generation, a developer can employ this code to convert each JPEG to CMYK and verify the conversion before embedding the image.
 * 4. When troubleshooting color shift issues in a digital asset management system, a developer can use this example to reload a problematic JPEG, apply a CMYK color mode via JpegOptions, and save it to confirm whether the conversion resolves the problem.
 * 5. When creating an automated test suite for a graphics pipeline that must ensure CMYK output compliance, a developer can leverage this snippet to programmatically load a sample JPEG, convert it to CMYK, and save it for comparison with expected results.
 */