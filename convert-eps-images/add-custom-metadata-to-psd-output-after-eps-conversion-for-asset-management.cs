// HOW-TO: Convert EPS to PSD with Correct Size and White Background in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string inputPath = Path.Combine(inputDirectory, "sample.eps");
            string outputPath = Path.Combine(outputDirectory, "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                using (var psdOptions = new PsdOptions())
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height
                    };
                    epsImage.Save(outputPath, psdOptions);
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
 * 1. When a design pipeline needs to turn vector EPS artwork into layered PSD files for Photoshop editing while preserving the original dimensions.
 * 2. When an e‑commerce platform must generate PSD previews from EPS logos and ensure a white background for consistent display.
 * 3. When a digital asset management system requires batch conversion of EPS assets to PSD format with exact page size for cataloging.
 * 4. When a printing workflow converts EPS illustrations to PSD to apply raster effects in Photoshop, needing the original width and height.
 * 5. When a C# application automates conversion of client‑provided EPS files to PSD with a solid background to avoid transparency issues.
 */
