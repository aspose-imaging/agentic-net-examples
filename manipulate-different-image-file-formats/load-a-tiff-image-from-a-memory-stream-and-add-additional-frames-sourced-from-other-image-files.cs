using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputTiffPath = "input.tif";
        string[] additionalFramePaths = new[] { "frame1.png", "frame2.png" };
        string outputPath = "output.tif";

        try
        {
            // Verify base TIFF exists
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Verify each additional frame file exists
            foreach (string path in additionalFramePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the original TIFF image from a memory stream
            using (MemoryStream tiffStream = new MemoryStream(File.ReadAllBytes(inputTiffPath)))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Add each external image as a new frame
                foreach (string framePath in additionalFramePaths)
                {
                    using (MemoryStream frameStream = new MemoryStream(File.ReadAllBytes(framePath)))
                    using (RasterImage raster = (RasterImage)Image.Load(frameStream))
                    {
                        // Create a TiffFrame from the raster image and add it
                        TiffFrame frame = new TiffFrame(raster);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the resulting multi‑frame TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}