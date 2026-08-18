// HOW-TO: Extract a Rectangular Area from DjVu and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.djvu";
        string outputPath = "Output\\sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                Rectangle area = new Rectangle(50, 50, 300, 300);
                djvu.Crop(area);
                PngOptions options = new PngOptions();
                djvu.Save(outputPath, options);
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
 * 1. When you need to generate a thumbnail of a specific region from a DjVu document for a web preview.
 * 2. When extracting a diagram or chart from a large DjVu file to embed it as a PNG in a report.
 * 3. When isolating a confidential section of a scanned DjVu file before sharing only the cropped PNG with stakeholders.
 * 4. When converting a selected area of a DjVu map into a high‑resolution PNG for use in a GIS application.
 * 5. When preprocessing DjVu pages by cropping and saving them as PNGs for batch image analysis in C#.
 */
