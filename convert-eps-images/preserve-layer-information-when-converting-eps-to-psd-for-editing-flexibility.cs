// HOW-TO: Convert EPS to PSD with Separate Layers Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();

                var vectorRasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                psdOptions.VectorRasterizationOptions = vectorRasterOptions;

                var vectorizationOptions = new PsdVectorizationOptions
                {
                    VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                };
                psdOptions.VectorizationOptions = vectorizationOptions;

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
 * 1. When you need to import a vector EPS artwork into Photoshop while keeping each element on its own editable layer.
 * 2. When a printing workflow requires converting EPS logos to PSD files so designers can adjust colors and effects without losing vector quality.
 * 3. When automating batch processing of EPS files to PSD format for a web service that offers layer‑by‑layer image editing.
 * 4. When integrating Aspose.Imaging into a C# application to preserve layer structure while rasterizing EPS for further composition in Photoshop.
 * 5. When migrating legacy EPS assets to PSD for a digital asset management system that relies on separate layers for metadata tagging.
 */
