// HOW-TO: Convert ODG To SVG And Minify XML In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    // No compression; we'll minify manually
                    Compress = false,
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Minify the resulting SVG XML
            string xmlContent = File.ReadAllText(outputPath);
            // Remove whitespace between tags
            string minified = Regex.Replace(xmlContent, @">\s+<", "><").Trim();
            File.WriteAllText(outputPath, minified);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed LibreOffice Draw graphics in a web page, converting ODG to SVG and minifying the XML reduces load time.
 * 2. When an automated build pipeline must transform design assets from ODG to scalable SVG files for responsive UI, this code provides a quick C# solution.
 * 3. When you want to store vector drawings in a database with minimal storage footprint, minifying the exported SVG helps shrink file size.
 * 4. When a SaaS platform generates custom diagrams in ODG format and serves them as SVG to browsers, the code ensures fast delivery by removing unnecessary whitespace.
 * 5. When integrating Aspose.Imaging into a C# application to batch‑process ODG files into clean SVGs for further editing or printing, this snippet handles conversion and XML cleanup.
 */
