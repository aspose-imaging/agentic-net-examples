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

            // Load the PDF (vector image) using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG rasterization options (page size matches source)
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Render text as shapes to keep editability
                    TextAsShapes = true,
                    // Preserve original metadata (including layer information)
                    KeepMetadata = true
                };

                // Save the PDF as SVG, preserving layer hierarchy
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}