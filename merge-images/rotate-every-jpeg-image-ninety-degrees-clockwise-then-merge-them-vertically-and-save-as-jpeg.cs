using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputDirectory = "Input";
        string outputPath = "Output/merged.jpg";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Gather JPEG files from the input directory
        string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
        List<string> imagePaths = jpgFiles.Concat(jpegFiles).ToList();

        if (imagePaths.Count == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // First pass: determine canvas size after rotation
        List<Size> rotatedSizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                rotatedSizes.Add(img.Size);
            }
        }

        int canvasWidth = rotatedSizes.Max(s => s.Width);
        int canvasHeight = rotatedSizes.Sum(s => s.Height);

        // Create JPEG canvas bound to the output file
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;

            // Second pass: load, rotate, and copy each image onto the canvas
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound canvas (output file already specified in options)
            canvas.Save();
        }
    }
}