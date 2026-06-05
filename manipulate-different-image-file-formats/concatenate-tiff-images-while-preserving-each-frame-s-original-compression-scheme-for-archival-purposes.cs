using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.tif", "input2.tif", "input3.tif" };
            string outputPath = "output.tif";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            TiffImage outputImage = null;

            foreach (var inputPath in inputPaths)
            {
                // Load source TIFF image
                var srcImage = (TiffImage)Image.Load(inputPath);

                if (outputImage == null)
                {
                    // First image becomes the base output image
                    outputImage = srcImage;
                }
                else
                {
                    // Append all frames from the current source image
                    outputImage.Add(srcImage);
                    srcImage.Dispose(); // Dispose source after its frames are added
                }
            }

            // Save the concatenated TIFF preserving original compression per frame
            outputImage.Save(outputPath);
            outputImage.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to merge multiple scanned legal documents stored as separate TIFF files into a single multi‑page TIFF for long‑term archiving while keeping each page’s original LZW or CCITT compression.
 * 2. When a medical imaging system must combine individual DICOM‑exported TIFF slices into one multi‑frame TIFF for patient records without re‑encoding the lossless compression of each slice.
 * 3. When a GIS application has several satellite image tiles saved as compressed TIFFs and wants to create a single archival TIFF that preserves the original JPEG or LZW compression of each tile.
 * 4. When a publishing workflow requires concatenating high‑resolution magazine page scans, each saved with different TIFF compression, into one searchable PDF‑compatible TIFF while retaining the original compression to reduce storage costs.
 * 5. When an e‑discovery tool needs to bundle thousands of court‑submitted TIFF exhibits into a single archive file, ensuring each exhibit’s original compression (e.g., CCITT Group 4) remains unchanged for evidentiary integrity.
 */