using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var dngFiles = Directory.GetFiles(inputDir, "*.dng");
            foreach (var file in dngFiles)
            {
                string inputPath = file;
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(file) + ".tif");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DngImage dng = (DngImage)Image.Load(inputPath))
                {
                    dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    dng.Save(outputPath, tiffOptions);
                }
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
 * 1. When a photography studio needs to convert a large collection of raw DNG files into web‑ready TIFF images sized to 1024×768 for client previews, they can use this C# batch resize code with Aspose.Imaging.
 * 2. When an archival system must standardize incoming DNG scans by resizing them and storing them as lossless TIFFs for long‑term preservation, the example provides the required workflow.
 * 3. When a mobile app backend processes user‑uploaded raw DNG photos and needs to generate smaller TIFF thumbnails for faster download, developers can apply this code to automate the conversion.
 * 4. When a scientific imaging pipeline receives raw DNG data from microscopes and requires uniformly sized TIFF files for downstream analysis, the snippet shows how to batch resize and save them in .NET.
 * 5. When an e‑commerce platform wants to bulk convert product raw images in DNG format to 1024×768 TIFF files for catalog publishing, this C# solution using Aspose.Imaging handles the task efficiently.
 */