using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

public class Program
{
    public static void Main(string[] args)
    {
        // Expected arguments: <inputWebP> <outputWebP> [newWidth newHeight]
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputWebP> <outputWebP> [width height]");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        int? newWidth = null;
        int? newHeight = null;

        // Optional resizing parameters
        if (args.Length >= 4 && int.TryParse(args[2], out int w) && int.TryParse(args[3], out int h))
        {
            newWidth = w;
            newHeight = h;
        }

        // Configure LoadOptions with a modest buffer to limit memory allocations
        var loadOptions = new LoadOptions
        {
            BufferSizeHint = 4 * 1024 * 1024 // 4 MiB buffer
        };

        // Load the WebP image via a stream to avoid locking the file and to enable buffering
        using (var stream = File.OpenRead(inputPath))
        using (WebPImage webp = new WebPImage(stream, loadOptions))
        {
            // Perform resizing only if dimensions were supplied; use NearestNeighbour for low memory overhead
            if (newWidth.HasValue && newHeight.HasValue)
            {
                webp.Resize(newWidth.Value, newHeight.Value, ResizeType.NearestNeighbourResample);
            }

            // Prepare save options with matching buffer size and moderate quality
            var saveOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 80,
                BufferSizeHint = 4 * 1024 * 1024 // align with load buffer
            };

            // Save directly to the target file; no intermediate bitmap or pixel array is created
            webp.Save(outputPath, saveOptions);
        }
    }
}