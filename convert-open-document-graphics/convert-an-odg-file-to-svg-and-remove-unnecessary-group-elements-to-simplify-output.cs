using System;
using System.IO;
using System.Text.RegularExpressions;
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
            string inputPath = @"C:\Temp\input.odg";
            string outputPath = @"C:\Temp\output.svg";

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
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save to a temporary SVG file
                string tempSvgPath = outputPath + ".tmp";
                image.Save(tempSvgPath, svgOptions);

                // Load SVG content for cleanup
                string svgContent = File.ReadAllText(tempSvgPath);

                // Remove empty group elements
                while (svgContent.Contains("<g></g>"))
                {
                    svgContent = svgContent.Replace("<g></g>", string.Empty);
                }

                // Collapse groups that only wrap a single child without attributes
                Regex groupRegex = new Regex(@"<g>(.*?)</g>", RegexOptions.Singleline);
                svgContent = groupRegex.Replace(svgContent, "$1");

                // Write cleaned SVG to final output
                File.WriteAllText(outputPath, svgContent);

                // Delete temporary file
                File.Delete(tempSvgPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}