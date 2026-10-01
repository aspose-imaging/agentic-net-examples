// HOW-TO: Convert ODG to SVG with Embedded CSS Styles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "sample.odg");
            string outputPath = Path.Combine(outputDir, "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display OpenDocument graphics on a website, you can convert ODG files to SVG with CSS styling to ensure consistent rendering across browsers.
 * 2. When integrating vector assets from LibreOffice Draw into a C# application, this code lets you transform them into scalable SVG files that retain their original appearance.
 * 3. When preparing marketing materials that require editable vector graphics, you can automate the ODG‑to‑SVG conversion and embed CSS to maintain brand colors.
 * 4. When building a document‑to‑web pipeline, the snippet enables batch conversion of ODG diagrams to web‑ready SVGs with embedded styles for seamless inclusion in HTML pages.
 * 5. When a client supplies design files in ODG format but your front‑end framework only accepts SVG, this code provides a quick way to convert and style the images programmatically.
 */
