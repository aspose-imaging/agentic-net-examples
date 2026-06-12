using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Create PSD export options
                PsdOptions psdOptions = new PsdOptions();

                // Export all pages as layers (preserves layer groups)
                // Leaving MultiPageOptions null means all pages are included
                // Configure vector rasterization for proper rendering of vector content
                if (image is VectorImage)
                {
                    var rasterOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                        new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });
                    rasterOptions.TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel;
                    rasterOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.None;
                    psdOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Save the image as PSD with layers preserved
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
 * 1. When a graphic designer needs to convert a CorelDRAW (CDR) illustration into an Adobe Photoshop (PSD) file while keeping the original layer groups intact for further editing in Photoshop.
 * 2. When an automated build pipeline processes batch CDR assets and must export them to PSD format with preserved layers to enable downstream compositing or color‑correction tasks.
 * 3. When a web application allows users to upload CDR files and provides a preview or download of a PSD version that retains the vector layers for seamless integration into existing Photoshop workflows.
 * 4. When a digital asset management system migrates legacy CDR artwork to PSD files and requires layer preservation to maintain the hierarchy for cataloging and version control.
 * 5. When a C#‑based reporting tool generates marketing collateral from CDR templates and needs to export them as layered PSD files for designers to apply brand guidelines without flattening the artwork.
 */