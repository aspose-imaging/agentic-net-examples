using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image dicomImage = Image.Load(inputPath))
            {
                // Convert and save as PNG
                var pngOptions = new PngOptions();
                dicomImage.Save(outputPath, pngOptions);
            }

            // Compare file sizes of the original DICOM and the generated PNG
            long dicomSize = new FileInfo(inputPath).Length;
            long pngSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"DICOM size: {dicomSize} bytes");
            Console.WriteLine($"PNG size: {pngSize} bytes");

            if (pngSize < dicomSize)
                Console.WriteLine("PNG is smaller than DICOM.");
            else if (pngSize > dicomSize)
                Console.WriteLine("PNG is larger than DICOM.");
            else
                Console.WriteLine("PNG size equals DICOM size.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}