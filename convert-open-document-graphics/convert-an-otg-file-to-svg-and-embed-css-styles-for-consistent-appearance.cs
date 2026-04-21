using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG → SVG conversion
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = otgRasterOptions,
                TextAsShapes = true // render text as shapes for consistent appearance
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }

        // Embed CSS styles into the generated SVG
        try
        {
            string svgContent = File.ReadAllText(outputPath);
            const string css = @"
    <style type=""text/css"">
        /* Embedded CSS for consistent appearance */
        .myClass { fill:#0000FF; stroke:#000000; stroke-width:1; }
    </style>";

            // Insert the CSS right after the opening <svg> tag
            int insertPos = svgContent.IndexOf('>') + 1;
            if (insertPos > 0 && insertPos < svgContent.Length)
            {
                svgContent = svgContent.Insert(insertPos, css);
                File.WriteAllText(outputPath, svgContent);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to embed CSS: {ex.Message}");
        }
    }
}