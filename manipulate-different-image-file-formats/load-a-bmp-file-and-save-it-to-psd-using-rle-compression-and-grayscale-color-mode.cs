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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options: RLE compression and grayscale color mode
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
                };

                // Save the image as PSD with the specified options
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
 * 1. When a developer needs to convert legacy BMP assets into Photoshop‑compatible PSD files with lossless RLE compression and a grayscale color mode for use in print‑ready designs.
 * 2. When an automated image‑processing pipeline must ingest BMP scans and output compact PSD files that preserve only luminance data for archival in a digital asset management system.
 * 3. When a C# application integrates Aspose.Imaging to batch‑convert user‑uploaded BMP screenshots into PSD layers while reducing file size with RLE and simplifying colors to grayscale for faster editing.
 * 4. When a software tool prepares grayscale mock‑ups by loading BMP prototypes and saving them as PSD files with RLE compression to maintain quality while meeting Photoshop’s format requirements.
 * 5. When a developer implements a file‑conversion utility that validates the existence of a BMP source, creates the target directory, and saves the image as a PSD using Aspose.Imaging’s PsdOptions for RLE compression and grayscale mode.
 */