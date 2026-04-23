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
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multipage TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access PageExportingAction (inherited from RasterCachedMultipageImage)
                if (image is TiffImage tiffImage)
                {
                    // Set page exporting action to release resources after each page is saved
                    tiffImage.PageExportingAction = delegate (int index, Image page)
                    {
                        // Force garbage collection to free memory from previous pages
                        GC.Collect();

                        // Optional per-page processing can be added here
                        // Example: ((RasterImage)page).Rotate(90);
                    };

                    // Save the image using sequential export (pages are released after each save)
                    tiffImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}