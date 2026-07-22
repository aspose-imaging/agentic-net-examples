using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF);
                if (preview == null)
                {
                    Console.Error.WriteLine("No TIFF preview available.");
                    return;
                }

                using (preview)
                {
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
 * 1. When a web application needs to generate quick thumbnail previews of uploaded EPS vector files for display in a gallery, a developer can extract the low‑resolution TIFF preview using Aspose.Imaging for .NET.
 * 2. When an automated document processing pipeline must convert EPS artwork into a TIFF format for legacy printing systems that only accept raster images, this code provides a simple C# solution.
 * 3. When a desktop publishing tool wants to show a low‑resolution preview of an EPS logo before the user decides to embed the full vector, the developer can use the GetPreviewImage method to create a TIFF snapshot.
 * 4. When a content management system indexes graphic assets and stores a small TIFF preview of each EPS file for faster search result rendering, this snippet demonstrates how to generate and save that preview.
 * 5. When a batch conversion utility processes a folder of EPS files and needs to create low‑resolution TIFF versions for email attachments or quick previews, the code shows the required C# operations with Aspose.Imaging.
 */