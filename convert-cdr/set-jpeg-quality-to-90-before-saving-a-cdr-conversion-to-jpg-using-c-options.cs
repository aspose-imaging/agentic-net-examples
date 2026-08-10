// HOW-TO: Convert CorelDRAW CDR to JPEG with Quality 90 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                cdr.Save(outputPath, jpegOptions);
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
 * 1. When a design team needs to generate web‑ready JPEG previews of CorelDRAW (.cdr) files with a specific compression quality of 90.
 * 2. When an automated build pipeline must batch‑convert CDR assets to JPEGs while preserving the original dimensions and a white background.
 * 3. When a desktop application requires exporting vector drawings to JPEG for email attachment, ensuring consistent visual quality across different devices.
 * 4. When a content management system stores user‑uploaded CorelDRAW files and needs to create thumbnail JPEGs with controlled quality for faster loading.
 * 5. When a reporting tool extracts pages from CDR documents and saves them as high‑quality JPEG images for inclusion in PDF reports.
 */
