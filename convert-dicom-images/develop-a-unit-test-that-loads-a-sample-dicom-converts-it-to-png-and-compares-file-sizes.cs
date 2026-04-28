using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dcm";
        string outputPath = "output/sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DICOM image and convert to PNG
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
            }

            // Compare file sizes
            long dicomSize = new FileInfo(inputPath).Length;
            long pngSize = new FileInfo(outputPath).Length;

            // Simple verification: PNG file must have non‑zero size
            if (pngSize == 0)
            {
                Console.Error.WriteLine("Conversion failed: PNG file size is zero.");
                return;
            }

            Console.WriteLine($"DICOM size: {dicomSize} bytes");
            Console.WriteLine($"PNG size:   {pngSize} bytes");
            Console.WriteLine("Test passed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}