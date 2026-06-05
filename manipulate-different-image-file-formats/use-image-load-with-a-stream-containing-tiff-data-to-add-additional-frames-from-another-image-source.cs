using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputTiffPath = "input.tif";
        string additionalImagePath = "additional.png";
        string outputTiffPath = "output.tif";

        try
        {
            // Validate input TIFF file
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Validate additional image file
            if (!File.Exists(additionalImagePath))
            {
                Console.Error.WriteLine($"File not found: {additionalImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Load the existing TIFF image from a stream
            using (FileStream tiffStream = new FileStream(inputTiffPath, FileMode.Open, FileAccess.Read))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Load the additional image (e.g., PNG) to be added as a new frame
                using (RasterImage additionalImage = (RasterImage)Image.Load(additionalImagePath))
                {
                    // Create a new TiffFrame from the additional image
                    TiffFrame newFrame = new TiffFrame(additionalImage);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);
                }

                // Save the updated TIFF image to the output path
                tiffImage.Save(outputTiffPath);
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
 * 1. When a developer needs to merge a scanned multi‑page TIFF document with a newly generated PNG chart into a single TIFF file for archival or printing.
 * 2. When an application must programmatically append a watermark PNG image as an additional frame to an existing TIFF loaded from a network stream.
 * 3. When a medical imaging system wants to add a supplementary radiology JPEG image as a new frame to a patient’s multi‑frame TIFF study stored in a memory stream.
 * 4. When a batch processing tool combines a background BMP texture with an existing multi‑page TIFF template read from a file stream to create a composite document.
 * 5. When a document management workflow inserts a signature PNG image as an extra page into a TIFF file that is being read from a database BLOB stream.
 */