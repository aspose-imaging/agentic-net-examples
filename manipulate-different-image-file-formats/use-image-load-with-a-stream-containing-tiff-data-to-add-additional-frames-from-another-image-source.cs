// HOW-TO: Add PNG Frame to Existing TIFF Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        string frameImagePath = "frame.png";
        string outputPath = "output.tif";

        try
        {
            // Validate input files
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }
            if (!File.Exists(frameImagePath))
            {
                Console.Error.WriteLine($"File not found: {frameImagePath}");
                return;
            }

            // Load the existing TIFF image from a stream
            using (FileStream tiffFileStream = new FileStream(inputTiffPath, FileMode.Open, FileAccess.Read))
            {
                // Image.Load returns a generic Image; cast to TiffImage
                using (TiffImage tiffImage = (TiffImage)Image.Load(tiffFileStream))
                {
                    // Load the additional frame (e.g., a PNG) from a stream
                    using (FileStream frameFileStream = new FileStream(frameImagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (Image frameImage = Image.Load(frameFileStream))
                        {
                            // Create a TiffFrame from the loaded raster image
                            TiffFrame newFrame = new TiffFrame((RasterImage)frameImage);
                            // Add the new frame to the TIFF image
                            tiffImage.AddFrame(newFrame);
                        }
                    }

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the modified TIFF image
                    tiffImage.Save(outputPath);
                }
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
 * 1. When you need to combine a scanned document (TIFF) with a logo or watermark stored as a PNG into a multi‑page TIFF file.
 * 2. When you want to programmatically append additional pages to an existing TIFF archive without loading the whole file into memory.
 * 3. When you must merge image assets from different formats into a single TIFF for printing or archival purposes.
 * 4. When a web service receives TIFF data as a stream and you need to insert a dynamically generated PNG frame before returning the updated file.
 * 5. When you are building a document processing pipeline that adds preview thumbnails (PNG) as extra frames to a multi‑page TIFF.
 */
