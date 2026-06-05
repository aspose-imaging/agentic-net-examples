using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Dng;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (DngImage dng = (DngImage)Image.Load(inputPath))
                {
                    dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a photographer needs to convert a batch of RAW DNG files to 1024×768 TIFF images for faster web preview or archival storage using C# and Aspose.Imaging.
 * 2. When a digital asset management system must automatically resize and reformat incoming DNG files to a uniform TIFF size before indexing them in a database.
 * 3. When a printing workflow requires converting high‑resolution DNG captures to standard‑size TIFF files to ensure compatibility with legacy RIP software.
 * 4. When a mobile app backend processes user‑uploaded DNG photos, resizing them to 1024×768 and saving as TIFF to reduce bandwidth while preserving lossless quality.
 * 5. When an e‑commerce platform batch‑processes product shoot DNG images, resizing them to a consistent thumbnail size and storing them as TIFF for consistent color rendering across browsers.
 */