// HOW-TO: Export CorelDRAW CDR to PSD with Layer Groups Preserved in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
                {
                    options.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    options.VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    };

                    image.Save(outputPath, options);
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
 * 1. When you need to convert a CorelDRAW design to Photoshop while keeping each vector group as a separate PSD layer for further editing.
 * 2. When automating a batch workflow that transforms CDR files into PSDs so designers can continue work in Photoshop without losing layer structure.
 * 3. When building a server‑side service that receives CDR uploads and returns editable PSD files with original groups intact.
 * 4. When integrating CorelDRAW assets into a .NET application that generates PSD mockups while preserving the original layer hierarchy.
 * 5. When migrating legacy CDR artwork to a Photoshop‑based pipeline and require the layers to remain editable for color correction or compositing.
 */
