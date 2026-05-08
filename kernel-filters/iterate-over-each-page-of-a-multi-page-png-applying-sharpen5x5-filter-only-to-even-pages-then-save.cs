using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\multi.png";
        string outputPath = @"C:\temp\multi_processed.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the multi‑page PNG (APNG)
            using (Image image = Image.Load(inputPath))
            {
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multi‑page PNG (APNG).");
                    return;
                }

                // Iterate over pages
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Apply filter only to even pages (2,4,6,...). Pages are 1‑based for this rule.
                    if ((i + 1) % 2 == 0)
                    {
                        // Each page is a RasterImage
                        var rasterPage = apng.Pages[i] as RasterImage;
                        if (rasterPage != null)
                        {
                            // Apply Sharpen filter with kernel size 5 (sigma value 4.0 as example)
                            rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions(5, 4.0));
                        }
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified APNG using default PNG options
                var saveOptions = new PngOptions();
                apng.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}