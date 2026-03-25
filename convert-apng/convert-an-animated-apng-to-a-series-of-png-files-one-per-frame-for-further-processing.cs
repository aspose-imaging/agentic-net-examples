using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input APNG file path
        string inputPath = "input.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output directory for extracted frames
        string outputDir = "frames";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        // Load the animated APNG
        using (Image image = Image.Load(inputPath))
        {
            // Check if the loaded image supports multiple pages/frames
            if (image is IMultipageImage multipage)
            {
                int frameCount = multipage.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.png");

                    // Ensure the directory for this output path exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Retrieve the frame and save it as a PNG
                    using (Image frame = multipage.Pages[i])
                    {
                        PngOptions pngOptions = new PngOptions();
                        frame.Save(outputPath, pngOptions);
                    }
                }
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not a multipage (animated) image.");
            }
        }
    }
}