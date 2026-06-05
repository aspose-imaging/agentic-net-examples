using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "result.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Prepare PSD saving options (default settings preserve layers where possible)
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example: keep original metadata
                    KeepMetadata = true,
                    // Use default PSD version (6) and compression (RAW)
                    Version = 6,
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw
                };

                // Save the EPS as a PSD file
                epsImage.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}