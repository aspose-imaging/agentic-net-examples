using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output APNG file
        string outputPath = "output.apng";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Determine canvas size from the first image (assumes all images share the same dimensions)
        int canvasWidth = 0;
        int canvasHeight = 0;
        using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
        {
            canvasWidth = first.Width;
            canvasHeight = first.Height;
        }

        // Create APNG options with source bound to the output file
        ApngOptions createOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Create the APNG canvas and add each JPG as a frame
        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
        {
            apngImage.RemoveAllFrames();

            foreach (string path in inputPaths)
            {
                using (RasterImage frame = (RasterImage)Image.Load(path))
                {
                    apngImage.AddFrame(frame);
                }
            }

            // Save the bound APNG image
            apngImage.Save();
        }
    }
}