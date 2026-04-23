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
        string additionalImagePath = "additional.png";
        string outputPath = "output\\result.tif";

        try
        {
            // Verify input files exist
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }
            if (!File.Exists(additionalImagePath))
            {
                Console.Error.WriteLine($"File not found: {additionalImagePath}");
                return;
            }

            // Load the existing TIFF image from a stream
            using (FileStream tiffStream = File.OpenRead(inputTiffPath))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Load the additional image (e.g., PNG) from a stream
                using (FileStream addStream = File.OpenRead(additionalImagePath))
                using (RasterImage addRaster = (RasterImage)Image.Load(addStream))
                {
                    // Create a new TiffFrame from the raster image
                    TiffFrame newFrame = new TiffFrame(addRaster);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);
                    // The frame will be disposed automatically when tiffImage is disposed
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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