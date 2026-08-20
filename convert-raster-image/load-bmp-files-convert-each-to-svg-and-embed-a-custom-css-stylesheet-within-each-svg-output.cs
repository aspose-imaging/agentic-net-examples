// HOW-TO: Convert BMP Images to SVG with Embedded Custom CSS in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input BMP files
            string[] inputPaths = new[]
            {
                "C:\\Images\\sample1.bmp",
                "C:\\Images\\sample2.bmp"
            };

            // Corresponding output SVG files
            string[] outputPaths = new[]
            {
                "C:\\Output\\sample1.svg",
                "C:\\Output\\sample2.svg"
            };

            // Custom CSS to embed in each SVG
            string customCss = "svg { background-color: #f0f0f0; }";

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

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
                    // Prepare rasterization options for SVG conversion
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save as SVG using SvgOptions
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    };

                    image.Save(outputPath, svgOptions);
                }

                // Embed custom CSS into the generated SVG
                string svgContent = File.ReadAllText(outputPath);
                int insertPos = svgContent.IndexOf('>'); // after the opening <svg ...> tag
                if (insertPos != -1)
                {
                    insertPos++; // move past '>'
                    string styleElement = $"<style type=\"text/css\"><![CDATA[{customCss}]]></style>";
                    svgContent = svgContent.Insert(insertPos, styleElement);
                    File.WriteAllText(outputPath, svgContent);
                }
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
 * 1. When you need to generate scalable vector graphics from legacy BMP assets while applying a consistent background style via CSS.
 * 2. When a web application must serve SVG versions of uploaded BMP files with a predefined stylesheet for branding.
 * 3. When automating batch conversion of product catalog images from BMP to SVG and embedding company‑wide CSS rules.
 * 4. When creating printable SVG diagrams from BMP drawings and ensuring the SVG includes custom styling for PDF rendering.
 * 5. When migrating a desktop imaging workflow to vector format and want each SVG to contain a custom CSS block for responsive design.
 */
