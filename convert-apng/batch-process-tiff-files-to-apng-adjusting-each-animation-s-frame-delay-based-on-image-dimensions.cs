using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Setup input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in files)
        {
            // Ensure the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Compute frame delay based on image dimensions
                uint frameDelay = (uint)((raster.Width + raster.Height) / 10);
                if (frameDelay == 0) frameDelay = 1; // Minimum delay

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".apng";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = frameDelay
                };

                // Create APNG image and add the raster frame
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, raster.Width, raster.Height))
                {
                    apngImage.RemoveAllFrames(); // Remove default frame
                    apngImage.AddFrame(raster);  // Add the TIFF frame
                    apngImage.Save();            // Save the APNG file
                }
            }
        }
    }
}