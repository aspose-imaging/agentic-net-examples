// HOW-TO: Scale CMX Drawing by Factor Two While Preserving Line Thickness in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                image.Resize(newWidth, newHeight);
                image.Save(outputPath);
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
 * 1. When a CAD application needs to double the size of a CMX vector drawing for high‑resolution printing without distorting line weights.
 * 2. When an engineering workflow requires converting legacy CMX files to larger dimensions for integration into a larger‑scale layout.
 * 3. When a developer must programmatically enlarge CMX schematics for a touchscreen display while keeping the original line thickness ratios.
 * 4. When automating batch processing of CMX drawings to create zoomed‑in versions for detailed review in a .NET application.
 * 5. When preparing CMX artwork for a poster print, scaling it uniformly by two while ensuring the line strokes remain proportionally consistent.
 */
