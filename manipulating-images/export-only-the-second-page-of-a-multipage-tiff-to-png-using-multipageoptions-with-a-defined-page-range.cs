using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\multipage.tif";
        string outputPath = @"C:\Images\page2.png";

        try
        {
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
                // Prepare PNG save options with MultiPageOptions to export only the second page (index 1)
                var pngOptions = new PngOptions
                {
                    // Define the pages to export; only page index 1 will be saved
                    MultiPageOptions = new MultiPageOptions(new int[] { 1 })
                };

                // Save the selected page as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract a single page from a multi‑page TIFF document and save it as a PNG for web preview, they can use Aspose.Imaging with MultiPageOptions to select page index 1.
 * 2. When integrating a document scanning workflow that stores scanned pages as a TIFF stack, the code can be used to convert a specific scanned page (e.g., the second page) to a PNG thumbnail for display in a UI.
 * 3. When generating printable assets from a multi‑page medical imaging file, a developer may need to isolate the second frame and export it to PNG for inclusion in a report.
 * 4. When automating archival processes that require converting individual pages of a multi‑page TIFF into lossless PNG files, this snippet shows how to target only the desired page using C# and Aspose.Imaging.
 * 5. When building a batch conversion tool that processes large TIFF files but only needs to extract a particular page (such as a cover page) to PNG, the MultiPageOptions page‑range feature enables selective saving without loading all pages into memory.
 */