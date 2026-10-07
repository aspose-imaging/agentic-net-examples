// HOW-TO: Convert EMF Metafile to SVG with Embedded Base64 Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                image.Save(outputPath, svgOptions);
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
 * 1. When you need to display vector graphics from a Windows Metafile on a web page without external image files, you can convert the EMF to an SVG that embeds all raster content as Base64 strings.
 * 2. When preparing assets for a responsive UI that requires scalable SVG icons but the source files are EMF, this code lets you generate SVGs that retain the original appearance.
 * 3. When automating a batch process that migrates legacy EMF diagrams to a modern SVG format for inclusion in documentation, the snippet ensures each image is self‑contained.
 * 4. When integrating with a third‑party service that only accepts SVG input, you can transform incoming EMF files on the fly while preserving embedded bitmap data.
 * 5. When creating an offline report generator that embeds charts saved as EMF into an SVG‑based template, this approach embeds the chart images directly, avoiding separate file handling.
 */
