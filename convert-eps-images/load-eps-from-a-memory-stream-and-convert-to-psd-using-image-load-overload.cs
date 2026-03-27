using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Read the EPS file into a memory stream
        byte[] epsData = File.ReadAllBytes(inputPath);
        using (var inputStream = new MemoryStream(epsData))
        {
            // Load the EPS image from the memory stream using load options
            using (var image = Image.Load(inputStream, new EpsLoadOptions()))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Prepare PSD save options (default settings)
                var psdOptions = new PsdOptions();

                // Save the image as a PSD file
                image.Save(outputPath, psdOptions);
            }
        }
    }
}