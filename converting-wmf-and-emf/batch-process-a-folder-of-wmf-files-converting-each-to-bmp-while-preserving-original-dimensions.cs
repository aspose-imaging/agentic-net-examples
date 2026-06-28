using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputBmp";

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output BMP path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image and save it as BMP
                using (Image image = Image.Load(inputPath))
                {
                    // Save using BMP options (preserves original dimensions)
                    image.Save(outputPath, new BmpOptions());
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
 * 1. When a Windows desktop application must convert a legacy collection of vector WMF icons into raster BMP files for a printing system that only accepts BMP images.
 * 2. When an automated build pipeline needs to generate thumbnail previews of WMF diagrams by batch‑converting each file to BMP while preserving the original dimensions.
 * 3. When a migration script has to bulk‑export WMF assets from an old documentation repository to BMP format so they can be displayed in a web portal that does not support WMF.
 * 4. When a C# service processes user‑uploaded WMF graphics and stores them as BMP files on disk, ensuring the saved images retain their original size for downstream image analysis.
 * 5. When a nightly batch job synchronizes a folder of WMF drawings with a legacy CAD system that requires BMP inputs, using Aspose.Imaging to load each WMF and save it as a dimension‑preserving BMP.
 */