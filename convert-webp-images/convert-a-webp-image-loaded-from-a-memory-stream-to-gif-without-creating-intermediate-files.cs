// HOW-TO: Convert WebP Image to GIF from Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                using (Image image = Image.Load(memoryStream))
                {
                    var gifOptions = new GifOptions();
                    image.Save(outputPath, gifOptions);
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
 * 1. When you need to display a WebP graphic in a legacy browser that only supports GIF, you can convert the image in memory without writing temporary files.
 * 2. When processing user‑uploaded WebP avatars on a server and storing them as animated GIFs for email newsletters, this code performs the conversion directly from the uploaded byte array.
 * 3. When building a cloud function that receives WebP data via an API and must return a GIF response, the memory‑stream approach avoids disk I/O and speeds up the service.
 * 4. When generating GIF previews of WebP thumbnails in a Windows service that runs with limited file‑system permissions, you can load the image from a byte array and save it as GIF.
 * 5. When creating a batch job that reads WebP files from a database BLOB column and writes GIF files to a network share, this snippet handles the conversion without creating intermediate files on the local disk.
 */
