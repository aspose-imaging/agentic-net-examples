using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var exportOptions = new PngOptions();

                if (image is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    exportOptions.VectorRasterizationOptions = vectorOptions;
                }

                image.Save(outputPath, exportOptions);
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
 * 1. When a web designer uses Aspose.Imaging for .NET to convert layered PSD artwork into PNG thumbnails for a website and needs high‑quality smoothing to keep edges anti‑aliased and crisp.
 * 2. When an e‑learning platform automatically processes instructor‑provided PSD slides in C# and saves them as PNG images with smoothing enabled to ensure clear, legible visuals on mobile devices.
 * 3. When a digital asset management system imports Photoshop files and generates PNG previews using Aspose.Imaging, applying smoothing to preserve smooth gradients and fine details for quick browsing.
 * 4. When a print‑to‑screen workflow rasterizes vector layers inside a PSD to PNG in C# and requires smoothing to avoid jagged lines and maintain visual fidelity on screen displays.
 * 5. When a batch‑processing utility written in C# converts a directory of PSD files to PNG for archival, enabling high‑quality smoothing to retain smooth color transitions and sharp image quality.
 */