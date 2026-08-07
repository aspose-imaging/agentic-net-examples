using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputTiffPath = "input.tif";
        string additionalImagePath = "frame.png";
        string outputPath = "output.tif";

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

            // Load the existing TIFF image from a stream
            using (FileStream tiffStream = new FileStream(inputTiffPath, FileMode.Open, FileAccess.Read))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Load the additional image (e.g., PNG) from a stream
                using (FileStream imgStream = new FileStream(additionalImagePath, FileMode.Open, FileAccess.Read))
                using (RasterImage rasterImage = (RasterImage)Image.Load(imgStream))
                {
                    // Create a TiffFrame from the raster image
                    TiffFrame newFrame = new TiffFrame(rasterImage);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the modified TIFF image
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
 * 1. When a developer needs to merge a scanned TIFF document with a PNG logo to create a multi‑page TIFF archive for long‑term storage.
 * 2. When an application must programmatically append a dynamically generated PNG chart to an existing TIFF image without creating temporary files.
 * 3. When a batch‑processing service reads TIFF files from a network stream and adds watermark PNG frames before saving the final TIFF.
 * 4. When a document management system receives TIFF attachments via a web API and needs to attach a signature PNG as an additional frame using C# and Aspose.Imaging.
 * 5. When a photo‑editing tool loads a multi‑page TIFF from a memory stream and inserts a thumbnail PNG as a new frame to produce a composite TIFF for printing.
 */