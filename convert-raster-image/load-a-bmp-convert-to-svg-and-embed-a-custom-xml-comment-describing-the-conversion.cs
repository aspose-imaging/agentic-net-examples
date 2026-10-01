// HOW-TO: Convert BMP to SVG and Add Custom XML Comment in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    image.Save(outputPath, svgOptions);
                }
            }

            string svgContent = File.ReadAllText(outputPath);
            string comment = "<!-- Converted from BMP to SVG using Aspose.Imaging -->";

            if (svgContent.StartsWith("<?xml"))
            {
                int idx = svgContent.IndexOf("?>");
                if (idx != -1)
                {
                    idx += 2;
                    svgContent = svgContent.Insert(idx, "\n" + comment);
                }
                else
                {
                    svgContent = comment + "\n" + svgContent;
                }
            }
            else
            {
                svgContent = comment + "\n" + svgContent;
            }

            File.WriteAllText(outputPath, svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to transform legacy BMP graphics into scalable SVG files for web display while preserving conversion details in the SVG header.
 * 2. When generating SVG assets from BMP sources for a reporting system and want to embed a comment that records the conversion method for audit trails.
 * 3. When automating a batch process that converts BMP icons to SVG vectors and requires an XML comment to identify the tool used, such as Aspose.Imaging.
 * 4. When creating an export feature in a C# application that outputs SVG diagrams from BMP inputs and includes a custom comment for downstream processing scripts.
 * 5. When integrating image conversion into a CI pipeline and need to add a recognizable comment to the resulting SVG to verify that the BMP-to-SVG step succeeded.
 */
