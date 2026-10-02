// HOW-TO: Convert TIFF to PNG and Return MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            try
            {
                MemoryStream pngStream = ConvertToPngStream(inputPath);
                if (pngStream == null)
                {
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pngStream.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static MemoryStream ConvertToPngStream(string inputPath)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return null;
            }

            using (Image image = Image.Load(inputPath))
            {
                MemoryStream memoryStream = new MemoryStream();
                PngOptions pngOptions = new PngOptions();
                image.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a TIFF file to PNG and send the image directly through a web API without creating a temporary file on disk.
 * 2. When you want to display a high‑resolution TIFF image in a browser that only supports PNG by loading the image from an in‑memory stream.
 * 3. When you are processing large batches of TIFF documents and need to store the resulting PNG data as BLOBs in a database using a MemoryStream.
 * 4. When you generate thumbnails for a document viewer that requires PNG format and you prefer to keep the conversion result in memory for fast rendering.
 * 5. When you integrate with a third‑party image‑analysis service that accepts PNG streams, allowing you to convert TIFF files on the fly and pass the MemoryStream directly.
 */
