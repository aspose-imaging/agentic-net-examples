using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    // Prepare vector rasterization options for high‑resolution output
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // JPEG output
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100,
                        VectorRasterizationOptions = vectorOptions
                    };
                    string jpegOutputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                    image.Save(jpegOutputPath, jpegOptions);

                    // PNG output
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };
                    string pngOutputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));
                    image.Save(pngOutputPath, pngOptions);
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
 * 1. When a developer needs to generate high‑resolution JPEG previews of a batch of vector drawings (e.g., SVG, AI) for web thumbnails while preserving the original dimensions.
 * 2. When a developer must create lossless PNG copies of each vector file for archival or print‑ready distribution alongside the JPEG versions.
 * 3. When a developer wants to automate rasterization of vector assets stored in an Input folder, applying a white background and specific smoothing settings before saving to an Output directory.
 * 4. When a developer requires a C# solution that loads any image type, uses VectorRasterizationOptions to control page width, height, and rendering hints, and outputs both JPEG and PNG formats in a single pass.
 * 5. When a developer is building a CI/CD pipeline that validates vector artwork by converting each file to JPEG (quality 100) and PNG to ensure visual fidelity across different platforms.
 */