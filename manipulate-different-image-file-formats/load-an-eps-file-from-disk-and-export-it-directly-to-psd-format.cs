using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                };

                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to batch‑convert legacy EPS artwork to Photoshop‑compatible PSD files using C# and Aspose.Imaging for .NET, this code provides a fast, automated solution.
 * 2. When a web publishing pipeline requires migration of vector‑based EPS logos into layered PSD files with RLE compression and RGB color mode, the example handles the conversion seamlessly.
 * 3. When a Windows service must generate PSD mockups from incoming EPS design assets for downstream raster editing, the code demonstrates the necessary file‑loading and saving steps.
 * 4. When a desktop application allows users to import EPS illustrations and export them as PSD files for further editing, this snippet shows the core C# operations with Aspose.Imaging.
 * 5. When building a server‑side API that receives EPS uploads and returns PSD files optimized with RLE compression, the example illustrates the essential conversion logic.
 */