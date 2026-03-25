using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.cdr";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Configure PNG options with vector rasterization settings to preserve transparency
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = cdr.Width,               // Set canvas width to match CDR page
                    PageHeight = cdr.Height,             // Set canvas height to match CDR page
                    BackgroundColor = Aspose.Imaging.Color.Transparent // Preserve transparency
                }
            };

            // Save the rasterized image as PNG
            cdr.Save(outputPath, pngOptions);
        }
    }
}