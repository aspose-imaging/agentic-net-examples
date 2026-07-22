using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.cdr";
            string outputPath = "C:\\temp\\sample.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Cache the whole image data
                cdrImage.CacheData();

                // Get the first (single) page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];
                page.CacheData();

                // Configure PSD export options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                };

                // Save the page as PSD, preserving layers
                page.Save(outputPath, psdOptions);
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
 * 1. When a graphic design workflow requires converting a CorelDRAW (CDR) illustration to an Adobe Photoshop (PSD) file while keeping the original layers intact for further editing in Photoshop.
 * 2. When an automated batch‑processing service needs to read single‑page CDR files from a directory and export them as layered PSD files using C# and Aspose.Imaging for downstream compositing.
 * 3. When a web application allows users to upload CDR artwork and instantly provides a downloadable PSD version with RLE compression and RGB color mode for seamless integration with Photoshop plugins.
 * 4. When a digital asset management system must preserve layer information while migrating legacy CorelDRAW assets to PSD format to maintain editability across design teams.
 * 5. When a CI/CD pipeline for a publishing platform includes a step that validates CDR files and converts them to layered PSD files using Aspose.Imaging to ensure compatibility with Photoshop‑based proofing tools.
 */