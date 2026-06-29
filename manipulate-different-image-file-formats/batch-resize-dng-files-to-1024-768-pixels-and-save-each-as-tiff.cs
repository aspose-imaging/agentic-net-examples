using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dng");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var dng = (Aspose.Imaging.FileFormats.Dng.DngImage)image;
                    dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                    dng.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When a photographer needs to convert a large collection of raw DNG images into smaller 1024×768 TIFF files for quick preview or web publishing, this C# batch‑resize code using Aspose.Imaging can automate the process.
 * 2. When a digital asset management system must ingest raw camera files and store them as standardized TIFF thumbnails for cataloging, developers can use this example to resize and save each DNG in a single operation.
 * 3. When an e‑commerce platform wants to generate uniform product image previews from raw DNG files supplied by vendors, the code provides a fast way to batch resize and convert them to TIFF with Aspose.Imaging in .NET.
 * 4. When a scientific imaging workflow requires converting high‑resolution DNG microscopy images to lower‑resolution TIFFs for analysis software that only accepts TIFF input, this snippet handles the batch conversion and resizing automatically.
 * 5. When a mobile app backend needs to preprocess uploaded DNG photos by creating 1024×768 TIFF versions for storage efficiency, developers can integrate this C# routine to process all files in a folder using Aspose.Imaging’s Resize and TiffOptions features.
 */