using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Flip the image horizontally
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the flipped image as TIFF
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
 * 1. When a printing workflow requires converting legacy CorelDRAW (.cdr) artwork into a high‑resolution TIFF image with a mirrored layout for double‑sided printing, a developer can use this code.
 * 2. When an e‑commerce platform needs to generate product catalog pages by flipping source CDR designs horizontally before saving them as TIFF files for consistent DPI and color fidelity, this snippet is applicable.
 * 3. When a document management system must archive engineering diagrams stored as CorelDRAW files, but the archive standard mandates TIFF format and a horizontal flip to match legacy viewing conventions, the code provides the needed conversion.
 * 4. When a marketing automation tool prepares promotional banners that must be mirrored for right‑to‑left languages, loading the .cdr file, applying a horizontal RotateFlip, and exporting to TIFF ensures correct orientation and lossless quality.
 * 5. When a desktop application automates batch processing of CDR assets, applying a horizontal flip and saving them as TIFF files for downstream OCR or image analysis pipelines, this C# example handles the transformation.
 */