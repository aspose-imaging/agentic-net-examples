// HOW-TO: Convert CMX Image Stream to TIFF in C# Without Temp Files (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string inputPath = "input.cmx";
        string outputPath = "output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                using (Image image = Image.Load(memoryStream))
                {
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a desktop application receives a CMX drawing from a network service and must generate a TIFF preview without writing intermediate files to disk.
 * 2. When an automated document processing pipeline needs to transform legacy CorelDRAW CMX files into TIFF for archival while keeping the conversion entirely in memory.
 * 3. When a cloud‑based image conversion microservice must handle CMX uploads and return TIFF responses without consuming temporary storage.
 * 4. When a batch job processes large numbers of CMX files and wants to reduce I/O overhead by loading each file into a MemoryStream before saving as TIFF.
 * 5. When a mobile or embedded C# application must convert CMX graphics to TIFF for printing, using only in‑memory operations to preserve limited storage.
 */
