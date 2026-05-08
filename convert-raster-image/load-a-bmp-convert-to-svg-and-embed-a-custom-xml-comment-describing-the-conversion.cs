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

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set up SVG rasterization options based on source image size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed a custom XML comment describing the conversion
            string svgContent = File.ReadAllText(outputPath);
            string comment = "<!-- Converted from BMP to SVG using Aspose.Imaging -->";

            int insertPos = svgContent.IndexOf("?>");
            if (insertPos != -1)
            {
                insertPos += 2; // Move past the XML declaration
            }
            else
            {
                insertPos = 0; // No XML declaration, insert at start
            }

            string newContent = svgContent.Insert(insertPos, "\n" + comment + "\n");
            File.WriteAllText(outputPath, newContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}