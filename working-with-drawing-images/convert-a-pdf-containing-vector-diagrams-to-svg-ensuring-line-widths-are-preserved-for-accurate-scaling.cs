using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.pdf";
        string outputPath = @"C:\Temp\output.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document (vector image)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options with the original page size
                VectorRasterizationOptions vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    // Preserve line widths by disabling smoothing (optional but helps accuracy)
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                };

                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    // Keep original metadata if needed
                    KeepMetadata = true
                };

                // Save the PDF as SVG
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to embed engineering schematics from a PDF into a responsive web page, they can convert the vector diagrams to SVG while preserving line widths for crisp scaling on any device.
 * 2. When a design team wants to export architectural floor plans from PDF to SVG for use in interactive CAD viewers, this code ensures the original line thicknesses remain accurate after conversion.
 * 3. When an e‑learning platform requires high‑quality vector illustrations from PDF textbooks to be displayed as scalable SVG assets, the conversion maintains line fidelity for clear zooming.
 * 4. When a marketing automation script generates SVG logos from PDF brand guidelines, preserving line widths guarantees that the logos retain their intended visual weight across different media.
 * 5. When a data‑visualization tool imports PDF charts and needs to transform them into SVG for dynamic manipulation, this code keeps the chart’s line strokes consistent during scaling.
 */