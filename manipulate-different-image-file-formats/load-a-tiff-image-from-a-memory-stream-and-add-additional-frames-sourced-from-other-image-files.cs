using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputTiffPath = "input.tif";
        string[] additionalImagePaths = new[] { "frame1.png", "frame2.jpg" };
        string outputPath = "output.tif";

        try
        {
            // Verify input TIFF exists
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Load the base TIFF image from a memory stream
            byte[] tiffBytes = File.ReadAllBytes(inputTiffPath);
            using (var tiffStream = new MemoryStream(tiffBytes))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Add additional frames from other image files
                foreach (string imgPath in additionalImagePaths)
                {
                    if (!File.Exists(imgPath))
                    {
                        Console.Error.WriteLine($"File not found: {imgPath}");
                        return;
                    }

                    using (Image img = Image.Load(imgPath))
                    {
                        // Create a TiffFrame from the loaded raster image
                        TiffFrame frame = new TiffFrame((RasterImage)img);
                        tiffImage.AddFrame(frame);
                        // No need to dispose 'frame' explicitly; it will be disposed with the TiffImage
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When creating a multi‑page document such as a scanned contract, a developer can load the base TIFF from a database blob via a memory stream and append additional pages stored as PNG or JPEG files as new frames.
 * 2. When generating a multi‑resolution TIFF for GIS or medical imaging, the original high‑resolution TIFF can be read from a memory stream and lower‑resolution preview images (e.g., PNG, JPG) added as extra frames.
 * 3. When building a digital archive that stores scanned photos in a single TIFF file, a developer may load the existing TIFF from a network stream and append newly uploaded PNG or JPG images as additional frames.
 * 4. When implementing a server‑side report generator that combines a base TIFF template with dynamically created chart images (PNG, JPEG), each chart can be added as a new frame before saving the final multi‑page TIFF.
 * 5. When developing a batch conversion tool that reads a TIFF stored in a byte array, merges it with other image files, and outputs a multi‑frame TIFF suitable for printing or fax transmission.
 */