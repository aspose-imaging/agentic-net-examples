using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            string[] files = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_processed.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to automatically remove backgrounds from a large collection of product photos stored as PNG files, they can batch‑process the folder using Aspose.Imaging’s Graph Cut auto‑masking with custom strokes to generate clean transparent images.
 * 2. When a web application must prepare user‑uploaded PNG icons for a mobile app by applying consistent edge‑preserving masks across all files, the code can iterate through the input directory and apply Graph Cut masking in one step.
 * 3. When an e‑commerce platform wants to create uniform catalog thumbnails by stripping unwanted borders from hundreds of PNG images, developers can use this batch routine to apply user‑defined stroke masks and save the results automatically.
 * 4. When a digital‑art studio needs to export layered artwork as isolated PNG assets, they can script the folder processing to apply Graph Cut auto‑masking based on artist‑drawn strokes, speeding up the asset pipeline.
 * 5. When a machine‑learning team prepares training data by extracting foreground objects from PNG samples, they can run the batch code to apply Graph Cut masking with predefined strokes, producing masked images ready for model ingestion.
 */