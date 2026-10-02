// HOW-TO: Export EMF to SVG with External Images Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output/output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions options = new SvgOptions();
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
 * 1. When you need to convert Windows Metafile (EMF) graphics to scalable SVG files for web display while keeping linked raster images separate.
 * 2. When a reporting system generates charts as EMF and you must embed them in an HTML page as SVG without embedding large bitmap data.
 * 3. When a desktop application exports vector drawings to a format that can be edited in vector editors, preserving external image references.
 * 4. When you are building a batch conversion tool that processes legacy EMF assets and stores them as SVG files alongside their original bitmap resources.
 * 5. When you want to reduce the size of the SVG output by storing embedded pictures as external files, making it easier to cache or replace them later.
 */
