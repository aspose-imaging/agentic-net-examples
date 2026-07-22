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
        // Hardcoded input and output paths
        string inputTiffPath = "input.tif";
        string[] additionalImagePaths = { "frame1.png", "frame2.png" };
        string outputPath = "output.tif";

        try
        {
            // Verify existence of the base TIFF file
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Verify existence of each additional image file
            foreach (var path in additionalImagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the base TIFF image from a memory stream
            using (MemoryStream tiffStream = new MemoryStream(File.ReadAllBytes(inputTiffPath)))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Add each additional image as a new frame
                foreach (var framePath in additionalImagePaths)
                {
                    // Load the source image (any raster format supported by Aspose.Imaging)
                    using (RasterImage raster = (RasterImage)Image.Load(framePath))
                    {
                        // Create a TiffFrame from the raster image and add it to the TIFF
                        TiffFrame frame = new TiffFrame(raster);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the updated multi‑frame TIFF
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
 * 1. When a developer needs to merge several scanned pages stored as PNG or JPEG files into a single multi‑page TIFF for archival or printing, they can load the base TIFF from a memory stream and append the additional image frames.
 * 2. When building a medical imaging workflow that converts DICOM slices to PNG and then combines them into a multi‑frame TIFF for efficient storage and transmission, this code shows how to load the existing TIFF and add new raster frames.
 * 3. When creating a digital invoice batch where each page is generated as a separate PNG file, a developer can merge them into one multi‑page TIFF using a memory stream to avoid temporary files on disk.
 * 4. When implementing a document management system that receives scanned images via a web API as byte arrays, the code demonstrates loading the base TIFF from a MemoryStream and programmatically adding the incoming image frames.
 * 5. When developing a photo‑book export feature that consolidates selected PNG photos into a single high‑resolution multi‑page TIFF for printing, this snippet illustrates how to load the original TIFF and append each photo as a new frame.
 */