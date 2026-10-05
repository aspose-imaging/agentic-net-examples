// HOW-TO: Convert WMF to PNG with Metadata Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.wmf";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
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
 * 1. When a developer needs to convert legacy WMF vector graphics to PNG for web display while keeping the original author and creation date information.
 * 2. When an application must batch‑process engineering diagrams stored as WMF files and output PNG thumbnails that retain embedded metadata for audit trails.
 * 3. When a reporting tool generates charts in WMF format and the final PDF requires PNG images with preserved metadata for compliance documentation.
 * 4. When migrating a digital asset library from Windows Metafile to a cross‑platform PNG format without losing attribution data such as author name.
 * 5. When automating the import of WMF icons into a C# desktop application and the PNG assets must carry the original creation timestamps for version control.
 */
