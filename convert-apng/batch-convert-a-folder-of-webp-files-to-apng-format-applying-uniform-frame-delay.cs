// HOW-TO: Batch Convert WebP Images to APNG with Fixed Frame Delay in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (WebPImage webp = (WebPImage)Image.Load(inputPath))
                {
                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 100u, // uniform frame delay in milliseconds
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(createOptions, webp.Width, webp.Height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(webp);
                        apng.Save();
                    }
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
 * 1. When you need to convert a collection of animated WebP files into APNGs for browsers that support PNG animation while keeping a consistent frame speed.
 * 2. When automating the preparation of game assets, turning WebP sprite animations into APNGs with a uniform delay for use in Unity.
 * 3. When migrating a legacy web gallery, batch converting WebP animations to APNG to ensure compatibility with older image viewers.
 * 4. When generating email‑friendly animated images, converting WebP to APNG with a fixed frame time to meet email client constraints.
 * 5. When creating a CI pipeline that processes uploaded WebP animations into APNGs with a standard delay for consistent playback across platforms.
 */
