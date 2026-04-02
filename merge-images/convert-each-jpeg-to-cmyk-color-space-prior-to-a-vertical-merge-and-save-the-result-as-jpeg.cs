using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine($"Input directory not found: {inputDirectory}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Gather JPEG files from input directory
        string[] allFiles = Directory.GetFiles(inputDirectory, "*.*");
        List<string> jpegFiles = new List<string>();
        foreach (var f in allFiles)
        {
            string ext = Path.GetExtension(f).ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg")
                jpegFiles.Add(f);
        }

        if (jpegFiles.Count == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // Collect sizes of all images
        List<Size> sizes = new List<Size>();
        foreach (var file in jpegFiles)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(file))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for vertical merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Prepare output path
        string outputPath = Path.Combine(outputDirectory, "merged.jpg");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create JPEG options for CMYK output
        Source src = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = src,
            Quality = 100,
            ColorType = JpegCompressionColorMode.Cmyk
        };

        // Create canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (var file in jpegFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound canvas (output file already specified in options)
            canvas.Save();
        }
    }
}