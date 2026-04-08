using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.gif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Determine canvas size
            int width = image.Width;
            int height = image.Height;
            if (image is EmfImage emf)
            {
                width = emf.Width;
                height = emf.Height;
            }

            // Set up vector rasterization options for conversion
            var vectorOptions = new VectorRasterizationOptions
            {
                PageSize = new Size(width, height),
                BackgroundColor = Color.White
            };

            // Configure GIF options with a limited 256‑color palette
            var gifOptions = new GifOptions
            {
                VectorRasterizationOptions = vectorOptions,
                DoPaletteCorrection = true,   // Enable palette analysis
                ColorResolution = 7           // 2^(7+1) = 256 colors per channel
            };

            // Save as GIF
            image.Save(outputPath, gifOptions);
        }
    }
}