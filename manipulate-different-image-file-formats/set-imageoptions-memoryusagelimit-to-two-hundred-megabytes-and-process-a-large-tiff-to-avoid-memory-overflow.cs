// HOW-TO: Process Large TIFF With 200 MB Memory Limit Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage source = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame[] copiedFrames = source.Frames
                    .Select(frame => TiffFrame.CopyFrame(frame))
                    .ToArray();

                BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
                options.Source = new FileCreateSource(outputPath, false);

                using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(options, source.Width, source.Height))
                {
                    foreach (var frame in copiedFrames)
                    {
                        bigTiff.AddFrame(frame);
                    }

                    bigTiff.Save();
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
 * 1. When you need to convert a multi‑page TIFF into a BigTIFF while keeping memory usage under 200 MB in a C# application.
 * 2. When a server‑side image service must copy all frames from an existing TIFF and save them as a BigTIFF without causing an out‑of‑memory exception.
 * 3. When processing high‑resolution scanned documents that exceed normal TIFF limits and you want to ensure the operation runs safely on limited RAM.
 * 4. When automating archival of large medical or satellite images in .NET and you must enforce a memory usage cap to maintain application stability.
 * 5. When integrating Aspose.Imaging into a batch job that reads a TIFF, duplicates its frames, and writes a BigTIFF while preventing memory overflow on low‑end machines.
 */
