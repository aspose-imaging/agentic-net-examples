using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\preview.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                using (Image preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No TIFF preview available in the EPS file.");
                        return;
                    }

                    preview.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When a web application needs to generate quick thumbnail previews of uploaded EPS artwork for a product catalog, a developer can extract the low‑resolution TIFF preview using Aspose.Imaging for .NET.
 * 2. When a document management system must index vector graphics by creating searchable raster images, developers can load an EPS file, retrieve its embedded TIFF preview, and store it as a low‑resolution image for fast lookup.
 * 3. When a print‑ready workflow requires validating EPS files without rendering the full vector data, extracting the preview TIFF allows a developer to display a lightweight representation in a C# UI.
 * 4. When an automated batch process converts a large collection of EPS files to archival TIFF images, using GetPreviewImage provides a fast way to generate low‑resolution copies without full rasterization.
 * 5. When a mobile app synchronizes design assets and needs to show a quick preview of EPS files on low‑bandwidth connections, developers can extract the embedded TIFF preview and serve it as a compact image.
 */