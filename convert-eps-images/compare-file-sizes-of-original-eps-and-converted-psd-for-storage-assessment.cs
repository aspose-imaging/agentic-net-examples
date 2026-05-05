using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.eps";
        string outputPath = @"C:\Temp\sample_converted.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options (default settings)
                var psdOptions = new PsdOptions();

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            // Retrieve file sizes
            long epsSize = new FileInfo(inputPath).Length;
            long psdSize = new FileInfo(outputPath).Length;

            // Output size comparison
            Console.WriteLine($"Original EPS size: {epsSize} bytes");
            Console.WriteLine($"Converted PSD size: {psdSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}