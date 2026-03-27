using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multipage TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Set the page exporting action to release resources after each page is saved
            tiffImage.PageExportingAction = (index, page) =>
            {
                // Perform any per‑page processing here (e.g., GC to free memory)
                GC.Collect();
            };

            // Save the image; pages are processed sequentially due to the PageExportingAction
            tiffImage.Save(outputPath);
        }
    }
}