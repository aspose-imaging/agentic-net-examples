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
            string inputPath = @"C:\Input\sample.odg";
            string outputPath = @"C:\Output\sample.svg";

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
                // Set up SVG rasterization options
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed simple CSS into the generated SVG for consistent appearance
            string svgContent = File.ReadAllText(outputPath);
            int insertPos = svgContent.IndexOf('>');
            if (insertPos != -1)
            {
                string css = "\n<style type=\"text/css\">\n    svg { font-family: Arial, sans-serif; }\n</style>\n";
                svgContent = svgContent.Insert(insertPos + 1, css);
                File.WriteAllText(outputPath, svgContent);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}