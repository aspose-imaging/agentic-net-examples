using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Input\sample.pdf";
            string outputPath = @"C:\Output\sample.svg";

            // Verify that the input PDF exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document (vector image)
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options – page size matches source image
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    // Preserve selectable text (do NOT render as shapes)
                    TextAsShapes = false,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the PDF as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}