using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP files
        string[] inputPaths = new[]
        {
            @"C:\Images\sample1.bmp",
            @"C:\Images\sample2.bmp"
        };

        // Hardcoded output directory for SVG files
        string outputDir = @"C:\Images\SvgOutput";

        // Custom CSS to embed into each SVG
        string cssContent = @"
svg { background-color: #f0f0f0; }
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

            // Build output SVG path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image and save as SVG
            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                image.Save(outputPath, svgOptions);
            }

            // Inject custom CSS into the generated SVG file
            string svgContent = File.ReadAllText(outputPath);
            int insertPos = svgContent.IndexOf('>');
            if (insertPos != -1)
            {
                string styleTag = $"\n<style type=\"text/css\"><![CDATA[{cssContent}]]></style>\n";
                svgContent = svgContent.Insert(insertPos + 1, styleTag);
                File.WriteAllText(outputPath, svgContent);
            }
        }
    }
}