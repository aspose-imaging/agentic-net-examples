using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputTiffPath = "input.tif";
            string[] additionalImagePaths = new[] { "frame1.png", "frame2.png" };
            string outputPath = "output.tif";

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the base TIFF image from a memory stream
            byte[] tiffBytes = File.ReadAllBytes(inputTiffPath);
            using (var memoryStream = new MemoryStream(tiffBytes))
            using (TiffImage tiffImage = (TiffImage)Image.Load(memoryStream))
            {
                // Add each additional frame to the TIFF image
                foreach (var imgPath in additionalImagePaths)
                {
                    using (RasterImage raster = (RasterImage)Image.Load(imgPath))
                    {
                        // Create a TiffFrame from the raster image and add it
                        TiffFrame frame = new TiffFrame(raster);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the resulting multi-frame TIFF
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
 * 1. When a medical imaging application needs to combine a base DICOM‑converted TIFF scan loaded from a memory stream with additional PNG annotation overlays into a single multi‑frame TIFF for archival.
 * 2. When a document management system must merge a scanned PDF page saved as a TIFF with extra signature images, adding each as a new frame to create a compliant multi‑page TIFF file.
 * 3. When a printing workflow wants to assemble a multi‑page TIFF brochure by loading the first page from a memory stream and appending product photos stored as PNG files as separate frames.
 * 4. When a GIS tool creates a composite satellite image by reading a base TIFF tile from a byte array and adding supplemental raster layers from PNG files as additional frames.
 * 5. When an e‑commerce platform generates a multi‑frame TIFF catalog by loading the main catalog cover from a stream and appending individual product thumbnail images saved as PNG files.
 */