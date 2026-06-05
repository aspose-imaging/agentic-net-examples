using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.tif";

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

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access RotateFlip
                CdrImage cdrImage = image as CdrImage;
                if (cdrImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a CDR image.");
                    return;
                }

                // Apply a horizontal flip (you can change the type as needed)
                cdrImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Prepare TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw
                };

                // Save the flipped image as TIFF
                cdrImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphics workflow requires converting CorelDRAW (.cdr) artwork to a loss‑less TIFF file for archival, while mirroring the design horizontally.
 * 2. When an automated batch process must read CDR files, apply a flip transformation, and output compressed LZW TIFFs for printing pipelines.
 * 3. When a document management system needs to preview CDR drawings as TIFF images with reduced file size using LZW compression after flipping them for correct orientation.
 * 4. When a .NET application integrates Aspose.Imaging to transform legacy CDR assets into TIFF format with LZW compression for compatibility with GIS or CAD tools that expect flipped images.
 * 5. When a server‑side service must validate the existence of a CDR file, perform a horizontal flip, and store the result as a compressed TIFF to meet regulatory image‑storage standards.
 */