using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputJpgPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };

        // Directories for intermediate DNG files and final output
        string tempDir = "temp";
        string outputDir = "output";

        // Ensure directories exist
        Directory.CreateDirectory(tempDir);
        Directory.CreateDirectory(outputDir);

        // Output JPG path
        string outputJpgPath = Path.Combine(outputDir, "combined.jpg");

        // Lists to hold intermediate DNG paths and their sizes
        List<string> dngPaths = new List<string>();
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();

        // Convert each JPG to DNG and collect size information
        foreach (string jpgPath in inputJpgPaths)
        {
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }

            // Load JPG as raster image
            using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
            {
                // Define DNG path
                string dngFileName = Path.GetFileNameWithoutExtension(jpgPath) + ".dng";
                string dngPath = Path.Combine(tempDir, dngFileName);

                // Ensure output directory for DNG exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(dngPath));

                // Save as DNG (format inferred from extension)
                jpgImage.Save(dngPath);
                dngPaths.Add(dngPath);
            }

            // Load the saved DNG to obtain its size
            using (RasterImage dngImage = (RasterImage)Image.Load(dngPaths[dngPaths.Count - 1]))
            {
                sizes.Add(dngImage.Size);
            }
        }

        // Calculate canvas dimensions for horizontal concatenation
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Prepare JPEG options with bound source
        Source outputSource = new FileCreateSource(outputJpgPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 90
        };

        // Create JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string dngPath in dngPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(dngPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Ensure output directory exists before saving (already created)
            Directory.CreateDirectory(Path.GetDirectoryName(outputJpgPath));

            // Save the bound image
            canvas.Save();
        }
    }
}