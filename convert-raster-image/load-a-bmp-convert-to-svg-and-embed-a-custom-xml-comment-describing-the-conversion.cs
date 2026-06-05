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
                // Set up rasterization options for SVG conversion
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed a custom XML comment describing the conversion
            // Read the generated SVG content
            string[] lines = File.ReadAllLines(outputPath);
            using (var writer = new StreamWriter(outputPath, false))
            {
                bool commentInserted = false;
                foreach (string line in lines)
                {
                    // Write the XML declaration first, then insert comment
                    if (!commentInserted && line.StartsWith("<?xml"))
                    {
                        writer.WriteLine(line);
                        writer.WriteLine("<!-- Converted from BMP to SVG using Aspose.Imaging -->");
                        commentInserted = true;
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }

                // If the file didn't start with an XML declaration, prepend the comment
                if (!commentInserted)
                {
                    writer.WriteLine("<!-- Converted from BMP to SVG using Aspose.Imaging -->");
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}