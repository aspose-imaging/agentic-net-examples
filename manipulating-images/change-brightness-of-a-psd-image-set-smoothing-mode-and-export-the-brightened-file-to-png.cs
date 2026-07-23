using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                // Adjust brightness (+50)
                RasterImage raster = (RasterImage)image;
                raster.AdjustBrightness(50);

                // Prepare PNG save options with smoothing mode
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                // Save the brightened image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to increase the brightness of a Photoshop PSD file and deliver a high‑quality PNG preview for a web gallery, they can use Aspose.Imaging for .NET to adjust brightness, apply anti‑alias smoothing, and save the result.
 * 2. When an e‑commerce platform must generate product thumbnails from layered PSD assets with consistent lighting, the code can brighten the image by 50 units, set SmoothingMode.AntiAlias, and export to PNG for fast loading.
 * 3. When a digital publishing workflow requires converting edited PSD designs into PNGs with smoother edges for print‑ready PDFs, developers can use the AdjustBrightness method and VectorRasterizationOptions to ensure the output looks bright and crisp.
 * 4. When a mobile app needs to preprocess user‑uploaded PSD files by enhancing visibility and reducing jagged edges before displaying them as PNGs, this C# snippet provides a straightforward solution.
 * 5. When an automated batch process must standardize the appearance of PSD assets by applying a uniform brightness boost and anti‑alias smoothing before archiving them as PNG files, the Aspose.Imaging code handles the conversion efficiently.
 */