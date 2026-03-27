using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.eps";
        string outputPath = @"C:\Temp\sample_converted.psd";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image epsImage = Image.Load(inputPath))
        {
            // Prepare PSD saving options (default settings are sufficient for size comparison)
            var psdOptions = new PsdOptions();

            // Save the image as PSD
            epsImage.Save(outputPath, psdOptions);
        }

        // Retrieve file sizes
        long epsSize = new FileInfo(inputPath).Length;
        long psdSize = new FileInfo(outputPath).Length;

        // Output the sizes for storage assessment
        Console.WriteLine($"Original EPS size: {epsSize} bytes");
        Console.WriteLine($"Converted PSD size: {psdSize} bytes");
    }
}