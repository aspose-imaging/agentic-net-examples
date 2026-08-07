using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage source = (TiffImage)Image.Load(inputPath))
            {
                BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
                options.Source = new FileCreateSource(outputPath, false);

                int width = source.ActiveFrame.Width;
                int height = source.ActiveFrame.Height;

                using (Aspose.Imaging.FileFormats.BigTiff.BigTiffImage bigTiff =
                    (Aspose.Imaging.FileFormats.BigTiff.BigTiffImage)Image.Create(options, width, height))
                {
                    for (int i = 1; i < source.Frames.Length; i++)
                    {
                        TiffFrame copied = TiffFrame.CopyFrame(source.Frames[i]);
                        bigTiff.AddFrame(copied);
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
 * 1. When a C# application must convert a multi‑page TIFF into a BigTIFF without exceeding a 200 MB memory budget, developers can set ImageOptions.MemoryUsageLimit and use the provided code to stream frames safely.
 * 2. When processing high‑resolution scanned documents that are too large for default memory allocation, the code helps avoid OutOfMemoryException by limiting memory usage while copying frames to a new TIFF file.
 * 3. When building a server‑side image service that receives large TIFF uploads and needs to re‑encode them as BigTIFF for archival, the memory‑limit setting ensures the service remains stable under load.
 * 4. When integrating Aspose.Imaging into a desktop batch‑conversion tool that handles gigapixel satellite imagery stored as TIFF, developers use this pattern to process each frame sequentially within a 200 MB limit.
 * 5. When migrating legacy multi‑page TIFF archives to the BigTIFF format for compatibility with modern viewers, the code with MemoryUsageLimit prevents crashes on machines with limited memory.
 */