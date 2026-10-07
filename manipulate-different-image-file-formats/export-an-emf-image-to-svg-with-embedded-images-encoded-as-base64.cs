// HOW-TO: Convert EMF to SVG with Embedded Base64 Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.svg";

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

                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                vectorOptions.PageWidth = image.Width;
                vectorOptions.PageHeight = image.Height;
                vectorOptions.BackgroundColor = Color.White;

                options.VectorRasterizationOptions = vectorOptions;

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
 * 1. When you need to embed a Windows Metafile (EMF) into a web page as a scalable SVG without external image files.
 * 2. When generating printable reports that require vector graphics from EMF sources to be converted to SVG for cross‑platform compatibility.
 * 3. When migrating legacy diagram assets stored as EMF into an SVG asset library while preserving embedded raster images as Base64 strings.
 * 4. When creating an automated pipeline that transforms EMF icons into SVG icons for responsive UI designs in a C# application.
 * 5. When exporting EMF charts to SVG for use in email newsletters, ensuring all images are self‑contained via Base64 encoding.
 */
