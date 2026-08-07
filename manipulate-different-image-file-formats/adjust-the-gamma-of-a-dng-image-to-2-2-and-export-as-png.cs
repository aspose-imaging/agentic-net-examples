using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.dng";
            string outputPath = "c:\\temp\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image, adjust gamma, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;
                dngImage.AdjustGamma(2.2f);
                dngImage.Save(outputPath, new PngOptions());
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
 * 1. When a photographer needs to convert raw DNG files to web‑ready PNGs with a standard 2.2 gamma for accurate color display on browsers, they can use this C# code with Aspose.Imaging.
 * 2. When a digital asset management system must batch‑process raw camera images to apply gamma correction and store them as lossless PNGs for archival, the code provides a straightforward solution.
 * 3. When a mobile app backend receives raw DNG uploads and must generate display‑ready PNG thumbnails with proper gamma for consistent visual quality, developers can employ this snippet.
 * 4. When an e‑commerce platform wants to showcase product photos captured in raw format by adjusting gamma to 2.2 and converting them to PNG for fast loading, the code handles the transformation.
 * 5. When a scientific imaging workflow requires correcting the gamma of raw DNG microscope images before exporting them as PNGs for analysis and reporting, this C# example fulfills the need.
 */