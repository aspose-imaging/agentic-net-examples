// HOW-TO: Convert ODG to SVG and Minify XML in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }

            string xml = File.ReadAllText(outputPath);
            string minified = xml.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("  ", " ");
            File.WriteAllText(outputPath, minified);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display OpenDocument graphics on a web page, converting ODG files to lightweight SVG format with Aspose.Imaging in C# simplifies the workflow.
 * 2. When bandwidth is limited, minifying the generated SVG XML reduces file size, speeding up page loads for mobile users.
 * 3. When integrating a document management system that stores drawings as ODG, you can automatically export them to SVG for compatibility with browsers and vector editors.
 * 4. When building a batch processing tool that prepares design assets for responsive websites, this code converts and compresses each ODG file in a single C# routine.
 * 5. When creating an automated pipeline that archives vector drawings, the minified SVG ensures smaller storage requirements while preserving the original visual fidelity.
 */
