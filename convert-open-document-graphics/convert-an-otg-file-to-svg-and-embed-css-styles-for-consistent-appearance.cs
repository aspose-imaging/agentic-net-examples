// HOW-TO: Convert OTG File to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions options = new SvgOptions())
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to display an OTG vector diagram on a web page, converting it to SVG ensures browser compatibility.
 * 2. When a design workflow requires exporting CAD‑like OTG drawings to a scalable format for responsive UI components, this code automates the conversion.
 * 3. When generating printable assets from OTG files, converting to SVG allows you to apply CSS styling for consistent colors across different devices.
 * 4. When integrating legacy OTG assets into a modern .NET application, the snippet loads the file and saves it as SVG for further processing.
 * 5. When automating batch processing of multiple OTG files into web‑ready SVGs, this approach can be incorporated into a file‑system loop.
 */
