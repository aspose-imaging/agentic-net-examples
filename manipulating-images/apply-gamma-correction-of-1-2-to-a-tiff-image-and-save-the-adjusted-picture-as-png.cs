using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.tif";
            string outputPath = @"c:\temp\sample.AdjustGamma.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AdjustGamma
                TiffImage tiffImage = (TiffImage)image;

                // Apply gamma correction with coefficient 1.2
                tiffImage.AdjustGamma(1.2f);

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to enhance the visual contrast of high‑resolution scanned TIFF files before embedding them in a web portal, they can apply a gamma correction of 1.2 and save the result as a lightweight PNG using Aspose.Imaging for .NET.
 * 2. When an automated document‑processing pipeline must normalize the brightness of incoming TIFF images from a scanner and produce PNG thumbnails for preview, the code can adjust gamma and perform the format conversion in C#.
 * 3. When a medical‑imaging application requires subtle brightening of DICOM‑derived TIFF scans to improve readability for clinicians, developers can use the AdjustGamma method and export the adjusted image as PNG for integration with UI components.
 * 4. When a batch‑processing script has to prepare archival TIFF photographs for an online gallery by applying consistent gamma correction and converting them to PNG for browser compatibility, this C# snippet provides a concise solution.
 * 5. When a desktop utility needs to correct underexposed TIFF screenshots from legacy software and output them as PNG files for sharing, developers can leverage Aspose.Imaging’s AdjustGamma function with a 1.2 factor.
 */