using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Input\sample.cdr";
        string outputPath = @"C:\Output\sample.tif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Flip the image horizontally
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a graphic design workflow requires converting a CorelDRAW (CDR) illustration into a high‑resolution TIFF for print production while mirroring the artwork horizontally.
 * 2. When an e‑commerce platform needs to generate mirrored product mockups by loading CDR files, flipping them, and saving as TIFF for compatibility with legacy catalog systems.
 * 3. When a document archival system must preserve vector drawings from CorelDRAW as lossless TIFF images with a horizontal flip to meet specific layout standards.
 * 4. When a batch‑processing script automates the preparation of marketing assets by reading CDR files, applying a horizontal flip, and exporting them to TIFF for use in Adobe Photoshop.
 * 5. When a mobile app backend processes user‑uploaded CorelDRAW designs, flips them horizontally for a mirror‑image effect, and stores the result as a TIFF file for further analysis.
 */