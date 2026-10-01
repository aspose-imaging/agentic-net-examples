// HOW-TO: Convert OTG Vector Image to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.otg";
            string outputPath = "output/output.svg";

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
 * 1. When you need to display OTG drawings on a website, you can convert them to scalable SVG files using C#.
 * 2. When integrating legacy OTG assets into a modern UI, converting them to SVG retains crisp vector quality across devices.
 * 3. When automating batch processing of engineering diagrams stored as OTG, you can generate SVG outputs for cross‑platform compatibility.
 * 4. When preparing print‑ready artwork that originates as OTG, converting to SVG allows further editing in vector editors without losing detail.
 * 5. When building a C# service that receives OTG uploads and returns SVG for downstream processing, this code handles the conversion while preserving vector data.
 */
