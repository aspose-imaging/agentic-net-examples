// HOW-TO: Replace Black Strokes With Blue In WMF And Save As SVG Using C# (Aspose.Imaging for .NET)
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
            string inputPath = "./input.wmf";
            string outputPath = "./output.svg";
            string tempSvgPath = "./temp.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));

            using (Image wmfImage = Image.Load(inputPath))
            {
                SvgOptions svgOptions = new SvgOptions();
                wmfImage.Save(tempSvgPath, svgOptions);
            }

            string svgContent = File.ReadAllText(tempSvgPath);
            svgContent = svgContent.Replace("stroke=\"black\"", "stroke=\"blue\"");
            svgContent = svgContent.Replace("#000000", "#0000FF");
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
 * 1. When you need to convert legacy WMF diagrams to modern SVG format while changing black lines to blue for brand‑consistent graphics in a C# application.
 * 2. When generating printable vector assets from Windows Metafile files and you must recolor strokes to match a corporate color palette using Aspose.Imaging.
 * 3. When automating batch processing of WMF icons to SVG for web use and need to replace default black outlines with a custom color programmatically.
 * 4. When integrating vector image conversion into a .NET service that requires updating stroke colors before storing the SVG in a content management system.
 * 5. When creating a migration tool that transforms old WMF assets to scalable SVG files and applies color adjustments to improve accessibility or visual design.
 */
