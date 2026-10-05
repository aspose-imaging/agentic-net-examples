// HOW-TO: Convert WMF to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
            using (Image wmfImage = Image.Load(inputPath))
            {
                SvgOptions svgOptions = new SvgOptions();
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
 * 1. When a developer needs to transform legacy Windows Metafile (WMF) icons into scalable SVG graphics for responsive web pages.
 * 2. When an application must batch‑convert WMF diagrams to SVG to enable editing in vector‑graphics editors without losing quality.
 * 3. When a reporting tool generates charts as WMF and the developer wants to embed them as SVG in PDF or HTML outputs.
 * 4. When a migration project replaces old Windows‑based UI assets stored as WMF with modern SVG assets for cross‑platform compatibility.
 * 5. When a C# service processes user‑uploaded WMF files and needs to store them as SVG to reduce file size and improve rendering speed.
 */
