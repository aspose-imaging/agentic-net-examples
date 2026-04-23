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
            // Hard‑coded input and output locations
            string inputPath = @"C:\Images\multi_page.tif";
            string outputDir = @"C:\Images\WebPPages";

            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set batch processing action – executed before each page is saved
                tiffImage.PageExportingAction = (int index, Image page) =>
                {
                    // Cast to RasterImage to access Save
                    if (page is RasterImage rasterPage)
                    {
                        // Build per‑page output path
                        string outPath = Path.Combine(outputDir, $"page_{index}.webp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                        // Save the current page as WebP
                        var webpOptions = new WebPOptions();
                        rasterPage.Save(outPath, webpOptions);
                    }
                };

                // Trigger the batch export by saving the source image.
                // The actual saved file is not needed; the action handles per‑page output.
                tiffImage.Save(Path.Combine(outputDir, "placeholder.tif"));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}