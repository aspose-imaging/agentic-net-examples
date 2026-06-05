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
                @"C:\Images\image1.bmp",
                @"C:\Images\image2.bmp"
            };

            // Custom CSS to embed in each SVG
            string customCss = @"
                /* Custom CSS */
                .myClass { fill: red; }
            ";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path (same folder, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG options with rasterization settings
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }

                // Embed custom CSS into the generated SVG
                string svgContent = File.ReadAllText(outputPath);
                int insertPos = svgContent.IndexOf('>'); // after the opening <svg ...> tag
                if (insertPos != -1)
                {
                    string styleElement = $"\n<style type=\"text/css\">\n{customCss}\n</style>\n";
                    svgContent = svgContent.Insert(insertPos + 1, styleElement);
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