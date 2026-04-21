using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the multipage TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set page exporting action to release resources after each page is saved
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Example operation: rotate each page 90 degrees (optional)
                    ((RasterImage)page).Rotate(90);
                    // Force garbage collection to free memory of previous pages
                    GC.Collect();
                };

                // Save the processed image using default TIFF options
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}