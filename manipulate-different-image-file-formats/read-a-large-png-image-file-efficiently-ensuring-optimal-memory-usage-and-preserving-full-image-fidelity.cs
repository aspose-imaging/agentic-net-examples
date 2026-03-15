using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as command‑line arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <inputPngPath> <outputPngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Define a memory limit (in megabytes) for internal buffers.
        const int memoryLimitMb = 100;

        // Load the PNG image with a buffer size hint to limit memory usage.
        var loadOptions = new LoadOptions { BufferSizeHint = memoryLimitMb };
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Cache the image data to avoid repeated disk reads during processing.
            if (!image.IsCached)
                image.CacheData();

            // Configure PNG save options to preserve fidelity and stay within the memory limit.
            var saveOptions = new PngOptions
            {
                BufferSizeHint = memoryLimitMb, // Apply the same memory constraint on save.
                Progressive = true,            // Enable progressive PNG for efficient loading.
                CompressionLevel = 9           // Use maximum compression without quality loss.
                // No changes to ColorType, BitDepth, etc., so original fidelity is retained.
            };

            // Save the image to the specified output path using the configured options.
            image.Save(outputPath, saveOptions);
        }
    }
}