using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options (default settings)
                var psdOptions = new PsdOptions();

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            // Compare file sizes
            long epsSize = new FileInfo(inputPath).Length;
            long psdSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"EPS file size: {epsSize} bytes");
            Console.WriteLine($"PSD file size: {psdSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}