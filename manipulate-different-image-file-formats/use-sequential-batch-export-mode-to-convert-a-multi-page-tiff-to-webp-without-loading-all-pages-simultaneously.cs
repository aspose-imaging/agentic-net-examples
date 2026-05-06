using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\multi_page.tif";
            string outputDirectory = @"C:\Images\WebPOutput";
            string outputBaseName = Path.Combine(outputDirectory, "page");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputBaseName));

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set batch processing action for each page
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Optional: force garbage collection to free previous page resources
                    GC.Collect();

                    // Build output file name for the current page
                    string outputPath = $"{outputBaseName}_{index}.webp";

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as a WebP image
                    page.Save(outputPath, new WebPOptions());
                };

                // Trigger the batch processing by invoking Save on the TIFF.
                // The actual TIFF output is not needed; we save to a temporary file.
                string tempTiffPath = Path.Combine(outputDirectory, "temp.tif");
                Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));
                tiffImage.Save(tempTiffPath);
                // Optionally delete the temporary file
                try { File.Delete(tempTiffPath); } catch { /* ignore */ }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}