using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP files
        string[] inputPaths = {
            @"C:\Images\sample1.bmp",
            @"C:\Images\sample2.bmp"
        };

        // Corresponding output SVG files (ensure they contain a directory)
        string[] outputPaths = {
            @"C:\Converted\sample1.svg",
            @"C:\Converted\sample2.svg"
        };

        // Custom CSS to embed into each SVG
        string customCss = @"
            svg { background-color:#f0f0f0; }
            .myClass { fill:red; }
        ";

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
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Embed custom CSS into the generated SVG
            string svgContent = File.ReadAllText(outputPath);
            int insertPos = svgContent.IndexOf('>');
            if (insertPos != -1)
            {
                string styleBlock = $"\n<style type=\"text/css\"><![CDATA[{customCss}]]></style>\n";
                string newSvgContent = svgContent.Insert(insertPos + 1, styleBlock);
                File.WriteAllText(outputPath, newSvgContent);
            }
        }
    }
}