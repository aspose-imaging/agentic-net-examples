using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\output\sample_highres.png";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional call)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Perform resizing and export in one step
        ProcessEpsToHighResPng(inputPath, outputPath);
    }

    /// <summary>
    /// Loads an EPS image, resizes it to a high resolution, and saves it as PNG.
    /// </summary>
    /// <param name="inputPath">Path to the source EPS file.</param>
    /// <param name="outputPath">Path where the PNG will be saved.</param>
    static void ProcessEpsToHighResPng(string inputPath, string outputPath)
    {
        // Load the EPS image using Aspose.Imaging
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Resize to the desired high‑resolution dimensions.
            // Mitchell cubic interpolation provides good quality for up‑scaling.
            image.Resize(2000, 2000, ResizeType.Mitchell);

            // Prepare PNG save options (default settings are sufficient here)
            var pngOptions = new PngOptions();

            // Save the resized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}