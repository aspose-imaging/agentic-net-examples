using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input SVG (multi‑page) and output directory
        string inputPath = @"C:\Images\multi_page.svg";
        string outputDir = @"C:\Images\output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Determine the number of pages (fallback to 1 if not a multipage image)
            int pageCount = 1;
            if (image is IMultipageImage multipage && multipage.PageCount > 0)
            {
                pageCount = multipage.PageCount;
            }

            // Process each page separately
            for (int i = 0; i < pageCount; i++)
            {
                // Build the output EMF file path for the current page
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure EMF export options
                var exportOptions = new EmfOptions
                {
                    // Restrict saving to the current page only
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1)),
                    // Set rasterization options (page size taken from the source image)
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the current page as an EMF file
                image.Save(outputPath, exportOptions);
            }
        }
    }
}