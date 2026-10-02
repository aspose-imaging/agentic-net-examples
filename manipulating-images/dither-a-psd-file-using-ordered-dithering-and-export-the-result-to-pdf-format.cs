// HOW-TO: Apply Ordered Dithering to PSD and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.Dither(DitheringMethod.ThresholdDithering, 8);
                }

                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to convert a layered Photoshop PSD file into a printable PDF while reducing color banding with ordered dithering.
 * 2. When generating low‑size PDF previews of PSD artwork for web galleries and you want consistent dithering across devices.
 * 3. When automating a batch process that archives design assets by applying threshold dithering to preserve visual fidelity in PDF reports.
 * 4. When creating PDF documents from PSD files for e‑learning materials and require a deterministic dithering method to ensure uniform appearance.
 * 5. When integrating Aspose.Imaging into a C# application to transform PSD images into PDF format with controlled dithering for consistent print output.
 */
