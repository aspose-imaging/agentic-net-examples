using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD specific options
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
                };

                // Attempt to save the image as PSD and handle save‑related exceptions
                try
                {
                    image.Save(outputPath, psdOptions);
                }
                catch (ImageSaveException ise)
                {
                    Console.Error.WriteLine($"Image save error: {ise.Message}");
                }
                catch (PsdImageException psi)
                {
                    Console.Error.WriteLine($"PSD image error: {psi.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any other unexpected exceptions
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}