using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.tif";
            string outputPath = "C:\\temp\\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the existing multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Define options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.Compression = TiffCompressions.None;

                // Create a blank 100x100 frame
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Insert the new frame at index 2 (third position)
                tiffImage.InsertFrame(2, newFrame);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified TIFF
                tiffImage.Save(outputPath);
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
 * 1. When generating a multi‑page scanned document and need to add a blank cover page as the third page of an existing TIFF file.
 * 2. When creating a multi‑page TIFF for a medical imaging report and must insert a new 100×100 annotation frame between the second and third image slices.
 * 3. When building a digital archive of engineering drawings and want to insert a placeholder frame at position two to reserve space for future revisions.
 * 4. When processing satellite imagery stored as a multi‑page TIFF and need to add a calibration frame after the second band without re‑encoding the whole file.
 * 5. When developing a C# application that merges PDF pages converted to TIFF and must insert an extra page at index two to comply with a regulatory page‑order requirement.
 */