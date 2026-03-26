using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path for the EMF file (simulating a network stream source)
        string inputPath = "input.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the EMF file as a stream (could be replaced with a real network stream)
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // Load the EMF image from the stream
            using (Image emfImage = Image.Load(inputStream))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Configure vector rasterization options required for converting vector EMF to raster PNG
                var vectorOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height
                };
                pngOptions.VectorRasterizationOptions = vectorOptions;

                // Write the PNG output directly to the response stream (here, standard output)
                using (Stream responseStream = Console.OpenStandardOutput())
                {
                    emfImage.Save(responseStream, pngOptions);
                }
            }
        }
    }
}