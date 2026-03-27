using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options (affects rendering quality)
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };

            // Set EMF save options, including compression and buffer size hint
            var emfOptions = new EmfOptions
            {
                VectorRasterizationOptions = vectorOptions,
                Compress = true,               // enable compression for smaller file size
                BufferSizeHint = 1024 * 1024   // 1 MB buffer hint for internal processing
            };

            // Save the image using the specified EMF options
            image.Save(outputPath, emfOptions);
        }
    }
}