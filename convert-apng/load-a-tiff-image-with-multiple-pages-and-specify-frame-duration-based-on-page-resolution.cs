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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame (page)
                foreach (var frame in tiff.Frames)
                {
                    // Example: calculate a frame duration based on the page resolution
                    double hRes = frame.HorizontalResolution; // pixels per inch
                    double vRes = frame.VerticalResolution;   // pixels per inch

                    // Simple formula – you can replace it with any logic you need
                    int duration = (int)(1000 / (hRes * vRes));

                    // If you need to store the duration in the TIFF metadata, you could set a custom tag here.
                    // The actual tag name/value depends on the TIFF specification and Aspose.Imaging support.
                    // Example (commented out because the exact API may differ):
                    // frame.Metadata.SetTagValue(Aspose.Imaging.FileFormats.Tiff.Enums.TiffTag.FrameDelay, duration);
                }

                // Save the modified TIFF
                tiff.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}