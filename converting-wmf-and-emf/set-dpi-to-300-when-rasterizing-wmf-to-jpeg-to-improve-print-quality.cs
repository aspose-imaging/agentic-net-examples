using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample_300dpi.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up WMF rasterization options (page size matches the source image)
                var wmfRasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure JPEG save options with 300 DPI resolution
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = wmfRasterOptions,
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating high‑resolution printable PDFs from legacy WMF vector graphics, a developer can rasterize the WMF to a 300 DPI JPEG to ensure crisp output on laser printers.
 * 2. When converting WMF icons for inclusion in marketing brochures, setting the JPEG resolution to 300 DPI guarantees that the images retain sharpness after scaling.
 * 3. When automating a batch job that prepares WMF diagrams for archival in a document management system, using Aspose.Imaging to rasterize them to 300 DPI JPEGs preserves detail for future printing.
 * 4. When building a C# web service that serves WMF‑based charts as JPEG thumbnails for high‑quality reports, configuring the DPI to 300 ensures the thumbnails look professional on printed pages.
 * 5. When integrating legacy WMF assets into a desktop publishing workflow, developers need to rasterize them to 300 DPI JPEG files so that the final printed catalog meets industry print standards.
 */