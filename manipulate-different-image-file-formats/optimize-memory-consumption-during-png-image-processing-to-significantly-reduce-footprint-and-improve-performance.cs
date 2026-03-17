using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class PngMemoryOptimization
{
    // Optimizes memory usage while processing a PNG image.
    // Loads the source image, applies memory‑friendly PNG save options,
    // and writes the result to the specified output path.
    public static void OptimizePng(string inputPath, string outputPath)
    {
        // Load the PNG image. The using block ensures the image is disposed promptly,
        // releasing native resources and reducing the overall memory footprint.
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options for low memory consumption and high compression.
            PngOptions options = new PngOptions
            {
                // Highest compression (0‑9). Reduces file size at the cost of CPU, but does not increase memory.
                CompressionLevel = 9,

                // Sub filter offers a good trade‑off between speed and compression.
                FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Sub,

                // Progressive PNG can be rendered incrementally, useful for large images.
                Progressive = true,

                // BufferSizeHint limits the size of internal buffers (e.g., 1 MB) to keep memory usage bounded.
                BufferSizeHint = 1024 * 1024
            };

            // Save the image directly to the output file using the optimized options.
            image.Save(outputPath, options);
        }
    }

    static void Main()
    {
        // Example usage.
        string inputFile = @"C:\temp\large_input.png";
        string outputFile = @"C:\temp\optimized_output.png";

        OptimizePng(inputFile, outputFile);
    }
}