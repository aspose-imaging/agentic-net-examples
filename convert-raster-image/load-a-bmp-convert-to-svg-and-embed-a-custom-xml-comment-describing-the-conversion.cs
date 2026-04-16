using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

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
            // Prepare rasterization options for SVG conversion
            var vectorRasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the image as SVG
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorRasterizationOptions
            };
            image.Save(outputPath, svgOptions);
        }

        // Embed a custom XML comment describing the conversion
        const string comment = "<!-- Converted from BMP to SVG using Aspose.Imaging -->";

        string svgContent = File.ReadAllText(outputPath);
        string updatedContent;

        // Preserve XML declaration if present
        if (svgContent.StartsWith("<?xml"))
        {
            int endOfDeclaration = svgContent.IndexOf("?>", StringComparison.Ordinal);
            if (endOfDeclaration != -1)
            {
                int insertPos = endOfDeclaration + 2;
                updatedContent = svgContent.Insert(insertPos, Environment.NewLine + comment);
            }
            else
            {
                // Fallback: prepend comment
                updatedContent = comment + Environment.NewLine + svgContent;
            }
        }
        else
        {
            // No XML declaration, prepend comment
            updatedContent = comment + Environment.NewLine + svgContent;
        }

        File.WriteAllText(outputPath, updatedContent);
    }
}