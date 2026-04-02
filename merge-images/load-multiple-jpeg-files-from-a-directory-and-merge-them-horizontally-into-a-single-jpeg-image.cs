using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory and output file path
        string inputDirectory = "InputImages";
        string outputPath = "Output/merged.jpg";

        // Ensure input directory exists; create it and exit if it was missing
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Get JPEG files from the input directory
        string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        if (imageFiles.Length == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // Verify each file exists (redundant after GetFiles but required by rules)
        foreach (string file in imageFiles)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }
        }

        // Collect sizes of all images
        List<Size> sizes = new List<Size>();
        foreach (string file in imageFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(file))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Prepare JPEG options with bound output source
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = new FileCreateSource(outputPath, false),
            Quality = 100
        };

        // Create the output JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string file in imageFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound image (no path needed)
            canvas.Save();
        }
    }
}