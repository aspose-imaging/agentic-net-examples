using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\multi_page.tif";
        string outputPath = @"C:\Images\single.webp";

        // Path‑safety checks as required
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // If the source is a multipage image, limit export to the first page
                if (image is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    // Export only the first page to keep memory usage low
                    var exportOptions = new WebPOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(0, 1))
                    };
                    image.Save(outputPath, exportOptions);
                }
                else
                {
                    // For single‑page images just save directly
                    var exportOptions = new WebPOptions();
                    image.Save(outputPath, exportOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}