// HOW-TO: Add PNG Frames to Existing TIFF from Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputTiffPath = "input.tif";
        string[] additionalImagePaths = new string[] { "frame1.png", "frame2.png" };
        string outputPath = "output.tif";

        try
        {
            // Verify input TIFF exists
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Verify each additional image exists
            foreach (var path in additionalImagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load the original TIFF from a memory stream
            using (var tiffStream = new MemoryStream(File.ReadAllBytes(inputTiffPath)))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
                {
                    // Add each additional image as a new frame
                    foreach (var imgPath in additionalImagePaths)
                    {
                        // Load the image (any raster format supported by Aspose.Imaging)
                        using (RasterImage raster = (RasterImage)Image.Load(imgPath))
                        {
                            // Create a TiffFrame from the raster image
                            TiffFrame frame = new TiffFrame(raster);
                            // Add the frame to the TIFF image
                            tiffImage.AddFrame(frame);
                            // No explicit disposal needed for the frame; it will be disposed with the TiffImage
                        }
                    }

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    // Save the updated TIFF
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
 * 1. When you need to combine multiple images into a multi‑page TIFF for archival or printing without writing temporary files.
 * 2. When a base TIFF is stored in a database or received over a network and you must append additional pages from PNG or JPEG files.
 * 3. When you want to create a multi‑frame TIFF for fax or document‑scanning workflows by programmatically adding frames from user‑uploaded images.
 * 4. When you must merge scanned documents with supplementary graphics while keeping the original TIFF in memory to avoid extra disk I/O.
 * 5. When building a server‑side service that receives a TIFF stream and needs to enrich it with extra pages before returning the final file.
 */
