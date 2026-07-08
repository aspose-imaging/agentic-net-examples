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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_converted.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG conversion
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    // Example: render text as shapes (optional)
                    TextAsShapes = true
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed a custom XML comment describing the conversion
            const string comment = "<!-- Converted from BMP to SVG using Aspose.Imaging -->";

            string svgContent = File.ReadAllText(outputPath);
            string newContent;

            if (svgContent.StartsWith("<?xml"))
            {
                // Insert comment after the XML declaration line
                int firstLineEnd = svgContent.IndexOf('>') + 1;
                newContent = svgContent.Insert(firstLineEnd, Environment.NewLine + comment);
            }
            else
            {
                // Prepend comment if no XML declaration
                newContent = comment + Environment.NewLine + svgContent;
            }

            File.WriteAllText(outputPath, newContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP assets into scalable SVG graphics for responsive web design while preserving image dimensions.
 * 2. When an automated build pipeline must generate vector versions of bitmap icons and add a traceable XML comment for audit compliance.
 * 3. When a desktop application processes user‑uploaded BMP screenshots and saves them as SVG files to reduce file size for cloud storage.
 * 4. When a reporting tool requires embedding conversion metadata inside SVG files so downstream systems can identify the source format.
 * 5. When a C# service migrates graphic resources from a Windows‑only BMP library to cross‑platform SVG format and needs to ensure the conversion step is documented within the SVG markup.
 */