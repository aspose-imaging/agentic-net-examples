using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.psd";
        string outputPsdPath = "output.psd";
        string outputPngPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPsdPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Save as PSD with RLE compression (maintains layers)
            using (PsdOptions psdOptions = new PsdOptions())
            {
                psdOptions.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE;
                image.Save(outputPsdPath, psdOptions);
            }

            // Convert the PSD to PNG (layers are flattened in the PNG)
            using (PngOptions pngOptions = new PngOptions())
            {
                image.Save(outputPngPath, pngOptions);
            }
        }
    }
}