using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\Images\large_input.tif";
        string outputDirectory = @"C:\Images\WebP_Output";

        // Path‑safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Define the action executed before each page is saved.
                // Here we convert the current page to WebP and write it to disk.
                tiffImage.PageExportingAction = (int index, Image page) =>
                {
                    // Build a file name for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{index}.webp");

                    // Ensure the directory for this page exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as WebP using default options
                    page.Save(outputPath, new WebPOptions());

                    // Release memory used by the previous page
                    GC.Collect();
                };

                // Trigger processing of all pages.
                // Saving to a dummy stream forces the PageExportingAction to run for each page.
                using (var dummyStream = new MemoryStream())
                {
                    tiffImage.Save(dummyStream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}