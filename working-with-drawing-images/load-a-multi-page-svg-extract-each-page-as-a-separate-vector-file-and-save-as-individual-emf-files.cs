// HOW-TO: Extract Each Page from Multi‑Page SVG and Save as EMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                int pageCount = 1;
                if (image is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = $"output\\page_{i + 1}.emf";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    EmfOptions options = new EmfOptions();
                    options.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

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
 * 1. When you need to convert a multi‑page SVG diagram into separate EMF files for use in Windows vector‑based reports.
 * 2. When a CAD application exports designs as a single SVG and you must split them into individual EMF pages for legacy engineering tools.
 * 3. When generating printable vector assets for each slide of an SVG presentation and require separate EMF files for Office integration.
 * 4. When automating a batch process that extracts each layer of a multi‑page SVG and saves them as EMF to preserve scalability in .NET applications.
 * 5. When preparing vector graphics for high‑resolution rendering in a C# workflow, converting each SVG page to EMF to maintain quality in downstream processing.
 */
