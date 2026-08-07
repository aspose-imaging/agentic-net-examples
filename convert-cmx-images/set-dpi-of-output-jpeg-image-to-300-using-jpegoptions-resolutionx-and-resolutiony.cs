using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_300dpi.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with 300 DPI resolution
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set desired resolution (horizontal and vertical) to 300 DPI
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    // Optional: set quality to maximum
                    Quality = 100
                };

                // Save the image as JPEG with the specified DPI
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
 * 1. When preparing product photos for high‑resolution print catalogs, a developer can use this code to convert source JPEGs to 300 DPI images so the printed pages maintain sharp detail.
 * 2. When generating printable marketing flyers from web‑uploaded images, the code ensures the saved JPEG meets the 300 DPI requirement of most commercial printers.
 * 3. When integrating a document‑generation workflow that embeds JPEG graphics into PDF/A files, the developer sets the DPI to 300 to comply with archival standards.
 * 4. When building a batch‑processing tool that normalizes scanned documents to a consistent 300 DPI resolution for OCR accuracy, this snippet handles the conversion for each file.
 * 5. When creating a C# application that resizes and re‑exports user‑provided photos for a photo‑book service, the code guarantees the final JPEGs are saved at 300 DPI for high‑quality printing.
 */