// HOW-TO: Convert EPS to CMYK PSD for Print Workflow in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\Converted\sample_cmyk.psd";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options with CMYK color mode
                var psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Cmyk
                };

                // Save the image as a CMYK PSD file
                image.Save(outputPath, psdOptions);
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
 * 1. When a prepress system receives vector EPS artwork and must generate a CMYK PSD file for downstream printing pipelines using C#.
 * 2. When an automated branding tool needs to batch‑convert EPS logos to CMYK PSDs to ensure color accuracy in commercial print jobs.
 * 3. When a web service processes user‑uploaded EPS files and must store them as CMYK PSDs for integration with Adobe Photoshop workflows.
 * 4. When a digital asset management solution must normalize mixed‑mode images by converting EPS to CMYK PSD to maintain consistent color profiles.
 * 5. When a C# application prepares print‑ready files by changing the color mode of EPS graphics to CMYK before saving them as PSD for proofing.
 */
