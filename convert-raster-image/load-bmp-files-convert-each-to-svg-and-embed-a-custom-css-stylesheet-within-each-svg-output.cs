using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    // Do not compress to keep SVG readable for CSS injection
                    Compress = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed custom CSS stylesheet into the generated SVG
            const string customCss = @"
    <style type=""text/css"">
        /* Custom CSS */
        .customClass { fill: #ff0000; stroke: #0000ff; stroke-width: 2; }
    </style>
";

            // Read the SVG content
            string svgContent = File.ReadAllText(outputPath);

            // Find the position after the opening <svg> tag
            int insertPos = svgContent.IndexOf('>') + 1;
            if (insertPos > 0 && insertPos < svgContent.Length)
            {
                // Insert the CSS after the <svg> tag
                svgContent = svgContent.Insert(insertPos, customCss);
                // Write back the modified SVG
                File.WriteAllText(outputPath, svgContent);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}