// HOW-TO: Convert WMF File To SVG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var wmfImage = (WmfImage)image;
                var svgOptions = new SvgOptions();
                wmfImage.Save(outputPath, svgOptions);
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
 * 1. When you need to display legacy Windows Metafile diagrams on modern browsers, you can convert the WMF to SVG with Aspose.Imaging in C#.
 * 2. When a reporting tool generates charts as WMF files and you want to embed them in responsive HTML pages, you can programmatically transform them to SVG.
 * 3. When migrating a desktop application’s assets to a cross‑platform UI, you can use this code to batch‑convert WMF icons to scalable SVG vectors.
 * 4. When automating a build pipeline that bundles vector graphics, you can convert WMF resources to SVG to reduce file size and improve scalability.
 * 5. When integrating with a third‑party service that only accepts SVG input, you can load the WMF, convert it to SVG, and send the result using C#.
 */
